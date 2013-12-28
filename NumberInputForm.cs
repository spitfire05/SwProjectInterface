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
    public partial class NumberInputForm : Form
    {
        public int number;
        public string prefix;
        public string suffix;
        public string name;
        public bool OK = false;
        public bool working = true;

        private Project _project;

        public NumberInputForm(Project project, string prefix, string suffix)
        {
            InitializeComponent();
            _project = project;
            nameGroupBox.Text = Settings.Default.propertyName;
            prefixTextBox.Text = prefix;
            suffixTextBox.Text = suffix;
            for (int i = 1; i <= 9999; i++)
            {
                if (!_project.numbers.Exists(element => element == i))
                {
                    numericUpDown1.Value = i;
                    break;
                }
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            number = (int)numericUpDown1.Value;
            prefix = prefixTextBox.Text.Trim();
            suffix = suffixTextBox.Text.Trim();
            if (number < 1 || number > 9999)
            {
                MessageBox.Show("Number has to be in range (1; 9999)!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            name = nameTextBox.Text;
            OK = true;
            working = false;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            working = false;
            this.Close();
        }
    }
}
