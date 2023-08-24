using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace CarReportSystem {
    public partial class Form1 : Form {
        //管理用データ
        BindingList<CarReport> CarReports = new BindingList<CarReport>();

        //設定情報保存用オブジェクト
        Settings settings = new Settings();

        Timer timer;
        DateTime dt;

        public Form1() {
            InitializeComponent();
            dgvCarReports.DataSource = CarReports; //Binding
        }

        //ステータスラベルのテキスト表示・非表示
        private void statusLabelDisp(string msg = "") { //←オプション引数
            tsInfoText.Text = msg;
            //MessageBox.Show(msg);
        }

        //追加ボタンイベントハンドラ
        private void btAddReport_Click(object sender, EventArgs e) {
            if (cbAuthor.Text.Equals("")) {
                statusLabelDisp("記録者が入力されていません");
                return;
            }
            else if (cbCarName.Text.Equals("")) {
                statusLabelDisp("車名が入力されていません");
                return;
            }
            statusLabelDisp();


            CarReport carReport = new CarReport {
                Date = dtpDate.Value, 
                Author = cbAuthor.Text, 
                Maker = getSelectedMaker(), 
                CarName = cbCarName.Text, 
                Report =  tbReport.Text, 
                CarImage = pbCarImage.Image, 
            };
            CarReports.Add(carReport);
            //dgvCarReports.Rows[CarReports.Count() - 1].Selected = true;

            #region //コンボボックスに追加
#if true
            if(cbAuthor.FindStringExact(cbAuthor.Text) < 0)
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
            CarReports.RemoveAt(dgvCarReports.CurrentRow.Index);
#if true
            ControlsClear();
#else
            //次に選択されるところのデータをコントロールに反映させる
#endif
        }

        //修正ボタンイベントハンドラ
        private void btModifyReport_Click(object sender, EventArgs e) {
            if (cbAuthor.Text.Equals("")) {
                statusLabelDisp("記録者が入力されていません");
                return;
            }
            else if (cbCarName.Text.Equals("")) {
                statusLabelDisp("車名が入力されていません");
                return;
            }
            statusLabelDisp();

            CarReports[dgvCarReports.CurrentRow.Index] = new CarReport {
                Date = dtpDate.Value,
                Author = cbAuthor.Text,
                Maker = getSelectedMaker(), 
                CarName = cbCarName.Text,
                Report = tbReport.Text,
                CarImage = pbCarImage.Image,
            };
            //dgvCarReports.Refresh(); //インスタンスそのまま、中身の上書きにしたとき　一覧更新

            ControlsClear();
        }

        //Form1をロード
        private void Form1_Load(object sender, EventArgs e) {
            dgvCarReports.Columns[5].Visible = false;
            DeleteModifyMasking();

            //設定ファイルを逆シリアル化して背景を設定
            try {
                using (var reader = XmlReader.Create("settings.xml")) {
                    var serializer = new XmlSerializer(typeof(Settings));
                    settings = serializer.Deserialize(reader) as Settings;
                    BackColor = Color.FromArgb(settings.MainFormColor);
                }
            }
            catch (System.ArgumentException) {

            }
            catch (System.IO.FileNotFoundException) {
                
            }

            #region Timer
            dt = DateTime.Now;
            tsslTimeLabel.Text = string.Format("{0:0000}/{1:00}/{2:00} {3:00}:{4:00}:{5:00}", dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second);


            // timerの設定
            timer = new Timer();
            timer.Interval = 100;
            timer.Enabled = true;
            timer.Tick += Timer_Tick;


            //Controls.Add(tsslTimeLabel);
            #endregion
        }

        //データグリッドビュー クリック
        private void dgvCarReports_Click(object sender, EventArgs e) {
            if (CarReports.Count() <= 0)
                return;

            dtpDate.Value = CarReports[dgvCarReports.CurrentRow.Index].Date;
            cbAuthor.Text = CarReports[dgvCarReports.CurrentRow.Index].Author;
            setSelectedMaker((CarReport.MakerGroup)dgvCarReports.CurrentRow.Cells[2].Value);
            cbCarName.Text = CarReports[dgvCarReports.CurrentRow.Index].CarName;
            tbReport.Text = CarReports[dgvCarReports.CurrentRow.Index].Report;
            pbCarImage.Image = CarReports[dgvCarReports.CurrentRow.Index].CarImage;

            //修正・削除ボタンマスク解除
            if (CarReports.Count() > 0) {
                btModifyReport.Enabled = true;
                btDeleteReport.Enabled = true;
            }
        }

        //指定したメーカーのラジオボタンを押す
        private void setSelectedMaker(CarReport.MakerGroup maker) {

            switch (maker) {
                case CarReport.MakerGroup.トヨタ:
                    rbToyota.Checked = true;
                    break;
                case CarReport.MakerGroup.日産:
                    rbNissan.Checked = true;
                    break;
                case CarReport.MakerGroup.ホンダ:
                    rbHonda.Checked = true;
                    break;
                case CarReport.MakerGroup.輸入車:
                    rbImported.Checked = true;
                    break;
                case CarReport.MakerGroup.スバル:
                    rbSubaru.Checked = true;
                    break;
                case CarReport.MakerGroup.スズキ:
                    rbSuzuki.Checked = true;
                    break;
                case CarReport.MakerGroup.ダイハツ:
                    rbDaihatsu.Checked = true;
                    break;
                case CarReport.MakerGroup.その他:
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
            foreach (RadioButton maker in gbMaker.Controls) {
                if (maker.Checked) {
                    maker.Checked = false;
                }
            }
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

        private void Timer_Tick(object sender, EventArgs e) {
            dt = DateTime.Now;
            tsslTimeLabel.Text = string.Format("{0:0000}/{1:00}/{2:00} {3:00}:{4:00}:{5:00}", dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second);
        }

    }
}
