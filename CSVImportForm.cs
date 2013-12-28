using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SwProjectInterface
{
    public partial class CSVImportForm : Form
    {
        public Project project;

        private ComboBox[] comboBoxes;
        private NumericUpDown[] numericUpDowns;
        private CSVReader reader;
        private Dictionary<decimal, importFieldValue> mapping;

        public CSVImportForm()
        {
            InitializeComponent();

            BindingList<importField> fields;
            fields = new BindingList<importField>();
            fields.Add(new importField("None", importFieldValue.NONE));
            fields.Add(new importField("Prefix + Name + Suffix", importFieldValue.PREFIX_NUMBER_SUFFIX));
            fields.Add(new importField("Name", importFieldValue.NAME));
            fields.Add(new importField("Prefix", importFieldValue.PREFIX));
            fields.Add(new importField("Suffix", importFieldValue.SUFFIX));
            fields.Add(new importField("Number", importFieldValue.NUMBER));
            fields.Add(new importField("File path (relative to work dir)", importFieldValue.PATH_RELATIVE));
            //fields.Add(new importField("File path (absolute)", importFieldValue.PATH_ABSOLUTE));

            comboBoxes = new ComboBox[] { columnComboBox1, columnComboBox2, columnComboBox3, columnComboBox4, columnComboBox5 };
            numericUpDowns = new NumericUpDown[] { columnNumericUpDown1, columnNumericUpDown2, columnNumericUpDown3, columnNumericUpDown4, columnNumericUpDown5 };

            foreach (ComboBox cb in comboBoxes)
            {
                cb.BindingContext = new System.Windows.Forms.BindingContext();
                cb.DataSource = fields;
            }
        }

        /// <summary>
        /// Enables or disables some of the gui elements
        /// </summary>
        /// <param name="enable">Set to true to enable, false to disable.</param>
        private void enableLowerGUI(bool enable)
        {
            //omitRowsWithoutFilePathsCheckBox.Enabled = enable;
            omitRowsWithoutNamesCheckBox.Enabled = enable;
            newProjectButton.Enabled = enable;
        }

        /// <summary>
        /// Enables some of the gui elements
        /// </summary>
        private void enableLowerGUI()
        {
            enableLowerGUI(true);
        }

        private void validateComboBoxSelections()
        {
            List<importFieldValue> used = new List<importFieldValue>();
            foreach (ComboBox cb in comboBoxes)
            {
                if (cb.Items.Count == 0)
                {
                    // not initalized yet
                    continue;
                }
                if (!cb.Enabled || (importFieldValue)cb.SelectedValue == importFieldValue.NONE)
                {
                    continue;
                }
                if (used.Contains((importFieldValue)cb.SelectedValue))
                {
                    //MessageBox.Show("Duplicated columns found!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    enableLowerGUI(false);
                    return;
                }
                enableLowerGUI();
                used.Add((importFieldValue)cb.SelectedValue);
            }
        }

        private void validateNumericUpDownSelections()
        {
            List<decimal> used = new List<decimal>();
            foreach (NumericUpDown nud in numericUpDowns)
            {
                if (!nud.Enabled)
                {
                    continue;
                }
                if (used.Contains(nud.Value))
                {
                    enableLowerGUI(false);
                    return;
                }
                enableLowerGUI();
                used.Add(nud.Value);
            }
        }
        
        private void importButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Multiselect = false;
            fd.Filter = "Comma Separated Values file|*.csv|Text file|*.txt";
            DialogResult r = fd.ShowDialog();
            if (r == DialogResult.OK)
            {
                if (!File.Exists(fd.FileName))
                {
                    MessageBox.Show("Can\'t find file " + fd.FileName, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                reader = new CSVReader(fieldDelimiterTextBox.Text.Trim());
                reader.readFile(fd.FileName, firstRowNamesCheckBox.Checked ? 1 : 0);
                updateMapping();
                updateDGV(reader.Matrix);

                // Set up numeric up downs
                int n = 1;
                foreach (NumericUpDown nud in numericUpDowns)
                {
                    nud.Maximum = dataGridView1.ColumnCount;
                    if (n > dataGridView1.ColumnCount)
                    {
                        nud.Enabled = false;
                    }
                    else
                    {
                        nud.Enabled = true;
                        nud.Value = n;
                    }
                    n += 1;
                }

                // Set up combo boxes
                n = 1;
                foreach (ComboBox cb in comboBoxes)
                {
                    if (n > dataGridView1.ColumnCount)
                    {
                        cb.Enabled = false;
                    }
                    else
                    {
                        cb.Enabled = true;
                    }
                    n += 1;
                }

                // Enable rest of interface
                dataGridView1.Enabled = true;
                groupBox3.Enabled = true;
                enableLowerGUI(true);
            }
        }

        private void updateDGV(List<List<string>> matrix)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 0;
            foreach (List<string> row in matrix)
            {
                // Add columns if needed
                // ColumnCount should always be equal to number of columns in csv file
                if (row.Count > dataGridView1.ColumnCount)
                {
                    dataGridView1.ColumnCount = row.Count;
                }
                int columnNo = 1;
                bool omit = false;
                // omit rows according to checkboxes
                foreach (string column in row)
                {
                    importFieldValue columnMapping;
                    if (mapping.TryGetValue(columnNo, out columnMapping))
                    {
                        if (columnMapping == importFieldValue.NAME &&
                            omitRowsWithoutNamesCheckBox.Checked &&
                            column == "")
                        {
                            omit = true;
                            break;
                        }
                    }
                    columnNo += 1;
                }
                if (omit)
                {
                    continue;
                }
                dataGridView1.Rows.Add(row.ToArray());
            }

            // Set up column names
            int n = 1;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.HeaderText = String.Format("Column{0}", n.ToString());
                n += 1;
            }

            // Needed for scrollbar to update properly. Workaround haxing FTW!
            dataGridView1.Scale(new SizeF());
        }

        private void updateMapping()
        {
            mapping = new Dictionary<decimal, importFieldValue>();
            mapping[columnNumericUpDown1.Value] = (importFieldValue)columnComboBox1.SelectedValue;
            mapping[columnNumericUpDown2.Value] = (importFieldValue)columnComboBox2.SelectedValue;
        }

        private void columnComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (reader != null)
            {
                validateComboBoxSelections();
                updateMapping();
                updateDGV(reader.Matrix);
            }
        }

        private void omitRowsWithoutNamesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (reader != null)
            {
                updateDGV(reader.Matrix);
            }
        }

        private void columnNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (reader != null)
            {
                validateNumericUpDownSelections();
                updateMapping();
                updateDGV(reader.Matrix);
            }
        }

        private void newProjectButton_Click(object sender, EventArgs e)
        {
            project.createNew();
            project.workDir = "";
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                SWPart f = new SWPart();
                f.project = project;
                f.file = "";
                int cellNo = 1;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value == null)
                    {
                        continue;
                    }
                    importFieldValue cellMapping;
                    if (mapping.TryGetValue(cellNo, out cellMapping))
                    {
                        switch (cellMapping)
                        {
                            case importFieldValue.PREFIX_NUMBER_SUFFIX:
                                string[] p = SWFile.getFileParams(cell.Value.ToString());
                                if (p[1] == "")
                                {
                                    MessageBox.Show(String.Format("{0} is wrong format for PREFIX_NUMBER_SUFFIX", cell.Value.ToString()), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                f.prefix = p[0];
                                f.number = Convert.ToInt32(p[1]);
                                f.suffix = p[2];
                                break;
                            case importFieldValue.NAME:
                                f.name = cell.Value.ToString();
                                break;
                            case importFieldValue.PREFIX:
                                f.prefix = cell.Value.ToString();
                                break;
                            case importFieldValue.SUFFIX:
                                f.suffix = cell.Value.ToString();
                                break;
                            case importFieldValue.NUMBER:
                                try
                                {
                                    f.number = Convert.ToInt32(cell.Value.ToString());
                                }
                                catch (FormatException)
                                {
                                    MessageBox.Show(String.Format("Can\'t convert {0} to a number!", cell.Value.ToString()), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                break;
                            case importFieldValue.PATH_RELATIVE:
                                f.file = cell.Value.ToString();
                                break;
                        }
                    }
                    cellNo += 1;
                }
                if (f.number > 0 && f.number <= 9999)
                {
                    if (f.file == "")
                    {
                        // Guess file name
                        f.file = f.prefix + SWFile.fourDigit(f.number) + f.suffix + f.extension;
                    }

                    if (f.file.ToLower().EndsWith(".sldasm"))
                    {
                        SWAssy fa = (SWAssy)f;
                        fa.addToProject();
                    }
                    else
                    {
                        f.addToProject();
                    }
                }
            }
            Form1 form = Form1.getForm();
            form.activateUI();
            if (!form.dbForm.Visible)
            {
                form.prep_DBForm();
            }
            form.dbForm.update();
            form.dbForm.Show();
            MessageBox.Show(String.Format("Imported {0} files.", dataGridView1.RowCount.ToString()), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }
    }
}
