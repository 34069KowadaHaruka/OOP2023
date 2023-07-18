using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarReportSystem {
    public partial class Form1 : Form {
        //管理用データ
        BindingList<CarReport> CarReports = new BindingList<CarReport>();

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
            dgvCarReports.Rows[CarReports.Count() - 1].Selected = true;

            //コンボボックスに追加
            if(cbAuthor.FindStringExact(cbAuthor.Text) < 0)
            cbAuthor.Items.Add(cbAuthor.Text);
            if(cbCarName.FindStringExact(cbCarName.Text) < 0)
            cbCarName.Items.Add(cbCarName.Text);

            dgvCarReports.Rows[CarReports.Count()-1].Selected = false;

            if (CarReports.Count() > 0) {
                btModifyReport.Enabled = true;
                btDeleteReport.Enabled = true;
            }
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
            ofdImageFileOpen.ShowDialog();
            pbCarImage.Image = Image.FromFile(ofdImageFileOpen.FileName);
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
            if (CarReports.Count <= 0) {
                btModifyReport.Enabled = false;
                btDeleteReport.Enabled = false;
            }
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
        }

        private void Form1_Load(object sender, EventArgs e) {
            dgvCarReports.Columns[5].Visible = false;
            btModifyReport.Enabled = false; //マスクする
            btDeleteReport.Enabled = false;


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

        //追加時コントロールクリアメソッド
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
            DialogResult dr = cdColor.ShowDialog();
            if (dr == DialogResult.OK) {
                BackColor = cdColor.Color;
            }
        }
    }
}
