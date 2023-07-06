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
            tbTimeNow.Text = DateTime.Now.ToString("yyyy年M月d日(dddd)　HH:mm:ss");
            tmTimeDisp.Start();
        }

        private void btAge_Click(object sender, EventArgs e) {
            #region
#if false
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
#endif
            #endregion
            var dtp = dtpDate.Value;
            var age = GetAge(dtp, DateTime.Now);
            tbMessage.Text = age+"歳です";
        }

        public static int GetAge(DateTime birthday, DateTime targetDay) {
            var age = targetDay.Year - birthday.Year;
            if (targetDay < birthday.AddYears(age)) {
                age--;
            }
            return age;
        }

        //タイマーイベントハンドラ
        private void tmTimeDisp_Tick(object sender, EventArgs e) {
            tbTimeNow.Text = DateTime.Now.ToString("yyyy年M月d日(dddd)　HH:mm:ss");
        }

        private void btNextYear_Click(object sender, EventArgs e) {
            tbMessage.Text = "一年後：" + dtpDate.Value.AddYears(1);
        }

        private void btNextMonth_Click(object sender, EventArgs e) {
            tbMessage.Text = "一ヵ月後：" + dtpDate.Value.AddMonths(1);
        }

        private void btNextDay_Click(object sender, EventArgs e) {
            tbMessage.Text = "一日後：" + dtpDate.Value.AddDays(1);
        }
    }
}
