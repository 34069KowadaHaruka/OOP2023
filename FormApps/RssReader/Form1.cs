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

        List<ItemData> nodes;

        public Form1() {
            InitializeComponent();
        }

        private void btGet_Click(object sender, EventArgs e) {
            lbRssTitle.Items.Clear();
            if (!tbUrl.Text.Contains(".xml"))
                return;

            using (var wc = new WebClient()) {
                var url = wc.OpenRead(tbUrl.Text);
                XDocument xdoc = XDocument.Load(url);

                nodes = xdoc.Root.Descendants("item").Select(x => new ItemData {
                    Title = (string)x.Element("title"),
                    Link = (string)x.Element("link")
                }).ToList();

                //nodesの各要素にはRssReader.ItemDataが入っていて、Itemの要素としてTitleがあるので、Titleを指定すればよい

                foreach (var node in nodes) {
                    lbRssTitle.Items.Add(node.Title);
                }
            }
        }

        private void lbRssTitle_DoubleClick(object sender, EventArgs e) {
            using (var wc = new WebClient()) {
                var target = lbRssTitle.SelectedIndex;
                wbBrowser.Navigate(nodes[target].Link);
            }
        }

        private void btAddComboBox_Click(object sender, EventArgs e) {
            if (tbUrl.Text == "")
                return;
            
            if (cbLink.FindStringExact(tbUrl.Text) < 0)
                cbLink.Items.Add(tbUrl.Text);
                
        }

        private void cbLink_SelectedIndexChanged(object sender, EventArgs e) {
            tbUrl.Text = (string)cbLink.SelectedItem;
        }
    }
}
