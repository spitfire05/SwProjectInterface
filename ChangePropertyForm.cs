using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SwProjectInterface
{
    public partial class ChangePropertyForm : Form
    {
        private Project project;
        private SWFile file;

        public ChangePropertyForm(Project Project, SWFile File)
        {
            InitializeComponent();
            project = Project;
            file = File;
            this.valueGroupBox.Text = Settings.Default.propertyName;
            this.valueTextBox.Text = this.file.name;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
