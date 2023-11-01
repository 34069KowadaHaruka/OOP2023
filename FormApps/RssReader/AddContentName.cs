using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RssReader {
    public partial class AddContentName : Form {
        public AddContentName() {
            InitializeComponent();
        }

        private void btEnter_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.OK;
        }

        private void btCancel_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
        }
    }
}
