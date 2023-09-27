using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RssReader {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btGet_Click(object sender, EventArgs e) {
            using (var wc = new WebClient()) {
                var url = wc.OpenRead(tbUrl.Text);
                XDocument xdoc = XDocument.Load(url);
                
                var nodes = xdoc.Root.Descendants("item").Elements("title"); //RootのDescendants(子孫)であるitemのElements(要素)title
                //T:子孫の要素　がわかりやすいだけでtitleはitemの子孫でもあるからRootの子孫の子孫でも通じる　要素の要素は通じないらしい

                foreach (var node in nodes) {
                    lbRssTitle.Items.Add(node.Value);
                }
            }
        }
    }
}
