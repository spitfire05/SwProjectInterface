using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace SwProjectInterface
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            infoLabel.Text = String.Format(infoLabel.Text, Assembly.GetExecutingAssembly().GetName().Version.ToString().Substring(0, 5));
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://spitfire05.github.io/SwProjectInterface/index.html");
        }
    }
}
