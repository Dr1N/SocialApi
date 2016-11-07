using System;
using System.Windows.Forms;
using VkNet;

namespace VkApiNS
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test", "Test");
        }
    }
}
