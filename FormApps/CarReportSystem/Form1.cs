﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace CarReportSystem {
    public partial class Form1 : Form {
        //設定情報保存用オブジェクト
        Settings settings = Settings.getInstance();

        DateTime dt;

        public Form1() {
            InitializeComponent();
            //dgvCarReports.DataSource = CarReports; //Binding
        }

        //ステータスラベルのテキスト表示・非表示
        private void statusLabelDisp(string msg = "") { //←オプション引数
            tsslInformation.Text = msg;
            //MessageBox.Show(msg);
        }

        //追加ボタンイベントハンドラ
        private void btAddReport_Click(object sender, EventArgs e) {
            DataLackCaution();
            if (tsslInformation.Text != "")
                return;

            DataRow newRow = infosys202330DataSet.CarReportTable.NewRow();
            newRow[1] = dtpDate.Value;
            newRow[2] = cbAuthor.Text;
            newRow[3] = getSelectedMaker();
            newRow[4] = cbCarName.Text;
            newRow[5] = tbReport.Text;
            newRow[6] = ImageToByteArray(pbCarImage.Image);

            infosys202330DataSet.CarReportTable.Rows.Add(newRow);
            this.carReportTableTableAdapter.Update(infosys202330DataSet.CarReportTable);

            #region //コンボボックスに追加
#if true
            if (cbAuthor.FindStringExact(cbAuthor.Text) < 0)
                cbAuthor.Items.Add(cbAuthor.Text);
            if(cbCarName.FindStringExact(cbCarName.Text) < 0)
                cbCarName.Items.Add(cbCarName.Text);
#else

            if (!cbAuthor.Items.Contains(cbAuthor.Text))
                cbAuthor.Items.Add(cbAuthor.Text);
            if (!cbCarName.Items.Contains(cbCarName.Text))
                cbCarName.Items.Add(cbCarName.Text);
#endif
            #endregion


            //GridView選択解除・項目クリア処理・マスク処理
            //dgvCarReports.Rows[CarReports.Count()-1].Selected = false;
            ControlsClear();
        }

        //ラジオボタンで選択されているメーカーを返す
        public CarReport.MakerGroup getSelectedMaker() {
#region メーカーグループチェックボックス
#if true
            foreach (RadioButton maker in gbMaker.Controls) {
                if (maker.Checked) {
                    return(CarReport.MakerGroup)(int.Parse(maker.Tag.ToString()));
                }
            }
            return CarReport.MakerGroup.その他;
#else
            if (rbToyota.Checked) {
                return CarReport.MakerGroup.トヨタ;
            }
            else if (rbNissan.Checked) {
                return CarReport.MakerGroup.日産;
            }
            else if (rbHonda.Checked) {
                return CarReport.MakerGroup.ホンダ;
            }
            else if (rbImported.Checked) {
                return CarReport.MakerGroup.輸入車;
            }
            else if (rbSubaru.Checked) {
                return CarReport.MakerGroup.スバル;
            }
            else if (rbSuzuki.Checked) {
                return CarReport.MakerGroup.スズキ;
            }
            else if (rbDaihatsu.Checked) {
                return CarReport.MakerGroup.ダイハツ;
            }
            else {
                return CarReport.MakerGroup.その他;
            }
#endif
#endregion
        }

        //画像開く...イベントハンドラ
        private void btImageOpen_Click(object sender, EventArgs e) {
            if (ofdImageFileOpen.ShowDialog() == DialogResult.OK) {
                pbCarImage.Image = Image.FromFile(ofdImageFileOpen.FileName);
            }
        }

        //画像削除イベントハンドラ
        private void btImageDelete_Click(object sender, EventArgs e) {
            if (pbCarImage.Image != null) {
                pbCarImage.Image.Dispose();
                pbCarImage.Image = null;
            }
        }

        //削除ボタンイベントハンドラ
        private void btDeleteReport_Click(object sender, EventArgs e) {
            dgvCarReports.Rows.RemoveAt(dgvCarReports.CurrentRow.Index);
            this.carReportTableTableAdapter.Update(infosys202330DataSet.CarReportTable);
#if true
            ControlsClear();
#else
            //次に選択されるところのデータをコントロールに反映させる
#endif
        }

        //修正ボタンイベントハンドラ
        private void btModifyReport_Click(object sender, EventArgs e) {
            DataLackCaution();
            if (tsslInformation.Text != "")
                return;

            DgvRenewal();

            this.Validate();
            this.carReportTableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.infosys202330DataSet);

            ControlsClear();
        }

        //Form1をロード
        private void Form1_Load(object sender, EventArgs e) {
            dgvCarReports.Columns[6].Visible = false;
            DeleteModifyMasking();
            tsslInformation.Text = ""; //情報表示領域のテキストを初期化
            rbOther.Checked = true;

            dgvCarReports.RowsDefaultCellStyle.BackColor = Color.PeachPuff;
            dgvCarReports.AlternatingRowsDefaultCellStyle.BackColor = Color.AntiqueWhite;

            //設定ファイルを逆シリアル化して背景を設定
            try {
                using (var reader = XmlReader.Create("settings.xml")) {
                    var serializer = new XmlSerializer(typeof(Settings));
                    settings = serializer.Deserialize(reader) as Settings;
                    BackColor = Color.FromArgb(settings.MainFormColor);
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

            #region Timer
            dt = DateTime.Now;
            //tsslTimeLabel.Text = string.Format("{0:0000}/{1:00}/{2:00} {3:00}:{4:00}:{5:00}", dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second);
            tmTimeUpdate.Start();

            //Controls.Add(tsslTimeLabel);
            #endregion

        }

        //指定したメーカーのラジオボタンを押す

        private void setSelectedMaker(string maker) {

            switch (maker) {
                case "トヨタ":
                    rbToyota.Checked = true;
                    break;
                case "日産":
                    rbNissan.Checked = true;
                    break;
                case "ホンダ":
                    rbHonda.Checked = true;
                    break;
                case "輸入車":
                    rbImported.Checked = true;
                    break;
                case "スバル":
                    rbSubaru.Checked = true;
                    break;
                case "スズキ":
                    rbSuzuki.Checked = true;
                    break;
                case "ダイハツ":
                    rbDaihatsu.Checked = true;
                    break;
                case "その他":
                    rbOther.Checked = true;
                    break;
                default:
                    rbOther.Checked = true;
                    break;
            }
        }

        //コントロールクリアメソッド
        private void ControlsClear() {
            dtpDate.Value = DateTime.Today;
            cbAuthor.Text = "";
            rbOther.Checked = true;
            cbCarName.Text = "";
            tbReport.Text = "";
            pbCarImage.Image = null;

            dgvCarReports.ClearSelection();

            DeleteModifyMasking();
        }

        //修正ボタン・削除ボタンをマスクする
        private void DeleteModifyMasking() {
            btModifyReport.Enabled = false;
            btDeleteReport.Enabled = false;
        }

        //記録者や車名が抜けているときステータスラベルで知らせる
        private void DataLackCaution() {
            if (cbAuthor.Text.Equals("")) {
                statusLabelDisp("記録者が入力されていません");
                return;
            }
            else if (cbCarName.Text.Equals("")) {
                statusLabelDisp("車名が入力されていません");
                return;
            }
            statusLabelDisp();
        }

        private void DgvRenewal() {
            dgvCarReports.CurrentRow.Cells[1].Value = dtpDate.Value;
            dgvCarReports.CurrentRow.Cells[2].Value = cbAuthor.Text;
            dgvCarReports.CurrentRow.Cells[3].Value = getSelectedMaker();
            dgvCarReports.CurrentRow.Cells[4].Value = cbCarName.Text;
            dgvCarReports.CurrentRow.Cells[5].Value = tbReport.Text;
            dgvCarReports.CurrentRow.Cells[6].Value = pbCarImage.Image;
            //dgvCarReports.Refresh(); //インスタンスそのまま、中身の上書きにしたとき　一覧更新
        }

        //終了
        private void 終了XToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void バージョン情報ToolStripMenuItem_Click(object sender, EventArgs e) {
            var vf = new VersionForm();
            vf.ShowDialog(); //モーダルダイアログとして表示
        }

        private void 背景色設定ToolStripMenuItem_Click(object sender, EventArgs e) {
            if (cdColor.ShowDialog() == DialogResult.OK) {
                BackColor = cdColor.Color;
                settings.MainFormColor = cdColor.Color.ToArgb();
            }
        }

        //画像サイズ変更
        private void btScaleChange_Click(object sender, EventArgs e) {
#if false
            PictureBoxSizeMode mode;
            pbCarImage.SizeMode = mode < PictureBoxSizeMode.Zoom ? ((mode == PictureBoxSizeMode.StretchImage) ? PictureBoxSizeMode.CenterImage : ++mode) : PictureBoxSizeMode.Normal;
#else
            int mode = (int)pbCarImage.SizeMode;
            //mode = mode < 4 ? ++mode : 0;
            //mode = mode == 2 ? ++mode : mode;

            mode = mode < 4 ? ((mode == 1) ? 3 : ++mode) : 0;

            pbCarImage.SizeMode = (PictureBoxSizeMode)mode;
            /*
            if (mode + 1 == 5) {
                pbCarImage.SizeMode = 0;
            }
            else if (mode + 1 == 2) {
                pbCarImage.SizeMode += 2;
            }
            else {
                pbCarImage.SizeMode++;
            }
            */
            //pbCarImageの表示方法についての変更であり、CarReportsに保存される画像が変わるわけではない
#endif
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            //設定ファイルのシリアル化
            using (var writer = XmlWriter.Create("settings.xml")) {
                var serializer = new XmlSerializer(settings.GetType());
                serializer.Serialize(writer, settings);
            }
        }

        private void tmTimeUpdate_Tick(object sender, EventArgs e) {
            dt = DateTime.Now;
            tsslTimeLabel.Text = string.Format("{0:0000}/{1:00}/{2:00} {3:00}:{4:00}:{5:00}", dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second);
        }

        //dgvセルクリック(セル以外のクリックを無視)
        private void dgvCarReports_CellClick(object sender, DataGridViewCellEventArgs e) {
            dtpDate.Value = (DateTime)dgvCarReports.CurrentRow.Cells[1].Value;
            cbAuthor.Text = dgvCarReports.CurrentRow.Cells[2].Value.ToString();
            setSelectedMaker(dgvCarReports.CurrentRow.Cells[3].Value.ToString());
            cbCarName.Text = dgvCarReports.CurrentRow.Cells[4].Value.ToString();
            tbReport.Text = dgvCarReports.CurrentRow.Cells[5].Value.ToString();
            pbCarImage.Image = !dgvCarReports.CurrentRow.Cells[6].Value.Equals(DBNull.Value) 
                                    &&((byte[])dgvCarReports.CurrentRow.Cells[6].Value).Length != 0?
                                ByteArrayToImage((byte[])dgvCarReports.CurrentRow.Cells[6].Value) : null;
            
            //修正・削除ボタンマスク解除
            btModifyReport.Enabled = true;
            btDeleteReport.Enabled = true;
        }

        public void ComboBoxAdds(string Author, string CarName) {
            if (!cbAuthor.Items.Contains(Author)) {
                cbAuthor.Items.Add(Author);
            }
            if (!cbCarName.Items.Contains(CarName)) {
                cbCarName.Items.Add(CarName);
            }
        }

        // バイト配列をImageオブジェクトに変換
        public static Image ByteArrayToImage(byte[] b) {
            ImageConverter imgconv = new ImageConverter();
            Image img = (Image)imgconv.ConvertFrom(b);
            return img;
        }

        // Imageオブジェクトをバイト配列に変換
        public static byte[] ImageToByteArray(Image img) {
            ImageConverter imgconv = new ImageConverter();
            byte[] b = (byte[])imgconv.ConvertTo(img, typeof(byte[]));
            return b;
        }

        private void 接続KToolStripMenuItem_Click(object sender, EventArgs e) {
            // TODO: このコード行はデータを 'infosys202330DataSet.CarReportTable' テーブルに読み込みます。必要に応じて移動、または削除をしてください。
            this.carReportTableTableAdapter.Fill(this.infosys202330DataSet.CarReportTable);

            foreach (var CarReports in infosys202330DataSet.CarReportTable) {
                ComboBoxAdds(CarReports.Author, CarReports.CarName);
            }

            dgvCarReports.ClearSelection();
        }
    }
}