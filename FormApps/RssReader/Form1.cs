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
        ChannelData cData;

        public Form1() {
            InitializeComponent();
        }

        private void btGet_Click(object sender, EventArgs e) {

            if (tbUrl.Text == "")
                return;
            if (tbUrl.Text.Contains(".xml") || tbUrl.Text.Contains("/feed")) {

                lbRssTitle.Items.Clear();
                //if (!Uri.IsWellFormedUriString(tbUrl.Text, UriKind.))
                //    return;

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
        }

        private void lbRssTitle_DoubleClick(object sender, EventArgs e) {
            if (nodes != null) {
                var target = lbRssTitle.SelectedIndex;

                if (target >= 0 && target < lbRssTitle.Items.Count)
                    wbBrowser.Navigate(nodes[target].Link);

            }
            else {
                return;
            }
        }

        private void btAddComboBox_Click(object sender, EventArgs e) {

            if (tbUrl.Text == "")
                return;
            if (!tbUrl.Text.Contains(".xml") || tbUrl.Text.Contains("/feed")) {

                if (cbLink.FindStringExact(tbUrl.Text) < 0) {
                    var acn = new AddContentName();
                    acn.ShowDialog(); //モーダルダイアログとして表示
                    cData = new ChannelData {
                        Title = acn.tbrRegisteredName.Text,
                        Url = tbUrl.Text
                    };
                    cbLink.Items.Add(cData);
                }
            }
        }

        private void cbLink_SelectedIndexChanged(object sender, EventArgs e) {
            tbUrl.Text = (string)cbLink.SelectedItem;
        }

        private void Form1_Load(object sender, EventArgs e) {
            cbLink.Items.Add();
        }
    }
}
