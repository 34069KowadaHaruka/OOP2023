﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btButton_Click(object sender, EventArgs e) { //ボタンをクリックすると
            //であって、ボタンの何かでは　ない
            //thisはプロジェクト名にもある通り、Formを指す
            //単純なプログラムのthisはC#だと省略すべきとされる

            int ans = int.Parse(tbNum1.Text) + int.Parse(tbNum2.Text);
            tbAns.Text = ans.ToString();
            tbAns.Text = (int.Parse(tbNum1.Text) + int.Parse(tbNum2.Text)).ToString();
        }
    }
}
