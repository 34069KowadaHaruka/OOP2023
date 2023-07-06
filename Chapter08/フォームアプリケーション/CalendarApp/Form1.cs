using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalendarApp {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btDayCalc_Click(object sender, EventArgs e) {
            var dtp = dtpDate.Value;
            var now = DateTime.Now;
            
            tbMessage.Text = "入力した日にちから" + (now - dtp).Days +"日経過";
        }

        private void Form1_Load(object sender, EventArgs e) {
            //tbTimeNow_TextChanged();
        }

        private void btAge_Click(object sender, EventArgs e) {
            var dtp = dtpDate.Value;
            var now = DateTime.Now;
            int range;
            if (dtp > now) {
                tbMessage.Text = "まだ生まれていません";
            }
            else if (true) {
                range = now.Year - dtp.Year;
                if (now.Month < dtp.Month) {
                    range--;
                }
                else if (now.Month == dtp.Month) {
                    if (now.Day < dtp.Day) {
                        range--;
                    }
                }
                tbMessage.Text = range + "歳です";
            }
        }

        private void tbTimeNow_TextChanged(object sender, EventArgs e) {
            var now = DateTime.Now;
            tbTimeNow.Text = now.ToString();
        }
    }
}
