﻿using System;
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
            if (tbUrl.Text.Contains(".xml") || tbUrl.Text.Contains("/feed")) {
                int sameData = -1;
                int count = -1;
                foreach (ChannelData item in cbLink.Items) {
                    count++;
                    if (item.Url == tbUrl.Text) {
                        sameData = count;
                        break;
                    }
                }
                
                if (sameData >= 0) { //登録名の更新
                    var acn = new AddContentName();
                    DialogResult dr = acn.ShowDialog(); //モーダルダイアログとして表示
                    cData = (ChannelData)cbLink.Items[sameData];
                    if (dr == DialogResult.OK) {
                        cData.Title = acn.tbrRegisteredName.Text;
                        cbLink.Items[sameData] = cData;
                        cbLink.SelectedItem = cbLink.Items[sameData];
                        tbUrl.Text = cData.Url;
                    }
                }else if (sameData < 0) {
                    var acn = new AddContentName();
                    DialogResult dr = acn.ShowDialog(); //モーダルダイアログとして表示
                    if (dr == DialogResult.OK) {
                        cData = new ChannelData {
                            Title = acn.tbrRegisteredName.Text,
                            Url = tbUrl.Text
                        };
                        cbLink.Items.Add(cData).ToString();
                        cbLink.SelectedItem = cbLink.Items[cbLink.Items.Count - 1];
                        tbUrl.Text = cData.Url;
                    }
                }
            }
        }

        private void cbLink_SelectedIndexChanged(object sender, EventArgs e) {
            var data = (ChannelData)cbLink.SelectedItem;
            tbUrl.Text = data.Url;
        }

        private void Form1_Load(object sender, EventArgs e) {
            cData = new ChannelData {
                Title = "Yahoo 国内ニュース",
                Url = @"https://news.yahoo.co.jp/rss/categories/domestic.xml"
            };
            cbLink.Items.Add(cData).ToString();

            cData = new ChannelData {
                Title = "Yahoo 国際ニュース",
                Url = @"https://news.yahoo.co.jp/rss/categories/world.xml"
            };
            cbLink.Items.Add(cData).ToString();

            cData = new ChannelData {
                Title = "Yahoo 経済ニュース",
                Url = @"https://news.yahoo.co.jp/rss/categories/business.xml"
            };
            cbLink.Items.Add(cData).ToString();

            cData = new ChannelData {
                Title = "Yahoo ITニュース",
                Url = @"https://news.yahoo.co.jp/rss/categories/it.xml"
            };
            cbLink.Items.Add(cData).ToString();
        }

        private void cbLink_KeyUp(object sender, KeyEventArgs e){
            if (e.KeyData == Keys.Enter) {
                foreach (ChannelData item in cbLink.Items) {
                    if (cbLink.Text == item.Title) {
                        tbUrl.Text = item.Url;
                        return;
                    }
                }
                tbUrl.Text = "";
            }
            
        }
    }
}
