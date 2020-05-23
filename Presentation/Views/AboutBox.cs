using System.Windows.Forms;
using System.Diagnostics;

namespace Presentation
{
    partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();
        }

        private void linkLabel2_Click(object sender, System.EventArgs e)
        {
            Process.Start("http://prodplanning.com.ua/");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
