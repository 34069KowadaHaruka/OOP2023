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

        //レポート追加
        private void btAddReport_Click(object sender, EventArgs e) {
            CarReport carReport = new CarReport {
                Date = dtpDate.Value, 
                Author = cbAuthor.Text, 
                Maker = getSelectedMaker() , 
                CarName = cbCarName.Text, 
                Report =  tbReport.Text, 
                CarImage = pbCarImage.Image, 
            };
            CarReports.Add(carReport);
            //dgvCarReports.Update();
            
        }

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

        private void btImageOpen_Click(object sender, EventArgs e) {
            ofdImageFileOpen.ShowDialog();
            pbCarImage.Image = Image.FromFile(ofdImageFileOpen.FileName);
        }

        private void btDeleteReport_Click(object sender, EventArgs e) {
            CarReports.RemoveAt(dgvCarReports.CurrentRow.Index);
        }
        
        private void btModifyReport_Click(object sender, EventArgs e) {

        }

        private void Form1_Load(object sender, EventArgs e) {
            dgvCarReports.Columns[5].Visible = false;
        }

        private void dgvCarReports_Click(object sender, EventArgs e) {
            dtpDate.Value = (DateTime)dgvCarReports.CurrentRow.Cells[0].Value;
            cbAuthor.Text = dgvCarReports.CurrentRow.Cells[1].Value.ToString();
            var maker = dgvCarReports.CurrentRow.Cells[2].Value.ToString();
            foreach (var item in CarReports) {
                //(CarReport.MakerGroup)int.Parse(maker.Tag.ToString());
            }
            cbCarName.Text = dgvCarReports.CurrentRow.Cells[3].Value.ToString();
            tbReport.Text = dgvCarReports.CurrentRow.Cells[4].Value.ToString();
            pbCarImage.Image = (Image)dgvCarReports.CurrentRow.Cells[5].Value;
        }
    }
}
