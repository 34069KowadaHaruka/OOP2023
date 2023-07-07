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
            CarReport.MakerGroup makerGroup;
            
            makerGroup = CarReport.MakerGroup.その他;
            return makerGroup;
        }
    }
}
