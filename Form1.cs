using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Diagnostics;

namespace SwProjectInterface
{
    public partial class Form1 : Form
    {
        public databaseForm dbForm;
        public int n = 0;
        private Project project = new Project();
        public Form1()
        {
            InitializeComponent();

            if (Settings.Default.UpgradeRequired)
            {
                Settings.Default.Upgrade();
                Settings.Default.UpgradeRequired = false;
                Settings.Default.Save();
            }

            this.Text = this.Text + " " + Assembly.GetExecutingAssembly().GetName().Version.ToString().Substring(0, 5);

            prep_DBForm();

            // Load default settings
            assyTemplateTextBox.Text = Settings.Default.assyTemplate;
            partTemplateTextBox.Text = Settings.Default.partTemplate;
            propertyNameTextBox.Text = Settings.Default.propertyName;

            string[] args = Environment.GetCommandLineArgs();

            if (args.Length > 1)
            {
                try
                {
                    project.open(args[1]);
                }
                catch (ProjectReadException exception)
                {
                    MessageBox.Show("XML parse error: " + exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                workDirTextBox.Text = project.workDir;
                partPrefixTextBox.Text = project.partPrefix;
                partSuffixTextBox.Text = project.partSuffix;
                assyPrefixTextBox.Text = project.assyPrefix;
                assySuffixTextBox.Text = project.assySuffix;
                activateUI();
                if (!dbForm.Visible)
                {
                    prep_DBForm();
                }
                dbForm.update();
                dbForm.Show();
            }
        }

        public void prep_DBForm()
        {
            dbForm = new databaseForm();
            dbForm.project = project;
        }
        
        public void activateUI(bool deactivate = false)
        {
            projectTextBox.Text = deactivate ? "" : project.file;
            groupBox2.Enabled = deactivate ? false : true;
            groupBox3.Enabled = deactivate ? false : true;
            groupBox4.Enabled = deactivate ? false : true;
            groupBox5.Enabled = deactivate ? false : true;
            groupBox6.Enabled = deactivate ? false : true;
            groupBox8.Enabled = deactivate ? false : true;
            saveToolStripMenuItem.Enabled = deactivate ? false : true;
            exportToolStripMenuItem.Enabled = deactivate ? false : true;
            showDatabaseFormToolStripMenuItem.Enabled = deactivate ? false : true;
            fileImportButton.Enabled = deactivate ? false : true;
            propertyNameTextBox.Enabled = deactivate ? true : false;
            importToolStripMenuItem.Enabled = deactivate ? true : false;
            closeProjectToolStripMenuItem.Enabled = deactivate ? false : true;
        }
        
        private void createPartButton_Click(object sender, EventArgs e)
        {
            if (propertyNameTextBox.Text == "")
            {
                MessageBox.Show("Enter property name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (partTemplateTextBox.Text == "")
            {
                MessageBox.Show("Enter part template path", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (workDirTextBox.Text == "")
            {
                MessageBox.Show("Enter work dir path", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            NumberInputForm nif = new NumberInputForm(project, project.partPrefix, project.partSuffix);
            nif.ShowDialog();
            if (!nif.OK)
            {
                return;
            }
            SWPart f = new SWPart()
            {
                project = project,
                number = nif.number,
                name = nif.name,
                prefix = nif.prefix,
                suffix = nif.suffix,
                template = partTemplateTextBox.Text,
            };
            int ret = f.create();
            if (ret == SWFile.RET_DUPLICATE_NUMBER)
            {
                DialogResult r = MessageBox.Show("Part or Assembly with number entered already exists in database. Create anyway?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (r == DialogResult.Yes)
                {
                    ret = SWFile.RET_OK;
                }
            }
            if (ret == SWFile.RET_NAME_EXISTS)
            {
                MessageBox.Show("Part or Assembly with this name already exists!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (ret == SWFile.RET_FILE_EXISTS)
            {
                MessageBox.Show("File already exists!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
            if (ret == SWFile.RET_OK)
            {
                f.save();
                f.addToProject();
            }
            dbForm.update();
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Save settings
            Settings.Default.Save();
            askSave();
        }

        private void askSave()
        {
            if (project.openedOK)
            {
                DialogResult r = MessageBox.Show("Save recent changes to the project?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    projectSaveButton_Click(null, null);
                }
            }
        }

        private void partTemplateTextBox_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.partTemplate = partTemplateTextBox.Text;
        }

        private void assyTemplateTextBox_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.assyTemplate = assyTemplateTextBox.Text;
        }

        private bool propertyNameTextBoxOK()
        {
            if (propertyNameTextBox.Text.Trim() == "")
            {
                propertyNameTextBox.BackColor = Color.IndianRed;
                MessageBox.Show("Please enter custom property name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void projectNewButton_Click(object sender, EventArgs e)
        {
            if (!propertyNameTextBoxOK())
            {
                return;
            }
            project.createNew();
            activateUI();
            if (!dbForm.Visible)
            {
                prep_DBForm();
            }
            dbForm.update();
            dbForm.Show();
        }

        private void projectOpenButton_Click(object sender, EventArgs e)
        {
            if (!propertyNameTextBoxOK())
            {
                return;
            }
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "SWPI project file|*.swpi";
            fd.Multiselect = false;
            DialogResult result = fd.ShowDialog();
            if (result == DialogResult.OK)
            {
                askSave();
                try
                {
                    project.open(fd.FileName);
                }
                catch (ProjectReadException exception)
                {
                    MessageBox.Show("Invalid XML: " + exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                workDirTextBox.Text = project.workDir;
                partPrefixTextBox.Text = project.partPrefix;
                partSuffixTextBox.Text = project.partSuffix;
                assyPrefixTextBox.Text = project.assyPrefix;
                assySuffixTextBox.Text = project.assySuffix;
                activateUI();
                if (!dbForm.Visible)
                {
                    prep_DBForm();
                }
                dbForm.update();
                dbForm.Show();
            }
        }

        private void projectSaveButton_Click(object sender, EventArgs e)
        {
            if (project.file == null)
            {
                SaveFileDialog fd = new SaveFileDialog();
                fd.Filter = "SWPI project file|*.swpi";
                DialogResult result = fd.ShowDialog();
                if (result == DialogResult.OK)
                {
                    project.file = fd.FileName;
                }
                else
                {
                    return;
                }
            }
            project.save();
            activateUI();
        }

        private void workDirTextBox_TextChanged(object sender, EventArgs e)
        {
            project.workDir = workDirTextBox.Text;
        }

        private void workDirBrowseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            DialogResult result = fd.ShowDialog();
            if (result == DialogResult.OK)
            {
                workDirTextBox.Text = fd.SelectedPath;
            }
        }

        private void partPrefixTextBox_TextChanged(object sender, EventArgs e)
        {
            project.partPrefix = partPrefixTextBox.Text.Trim();
        }

        private void partSuffixTextBox_TextChanged(object sender, EventArgs e)
        {
            project.partSuffix = partSuffixTextBox.Text.Trim();
        }

        private void partTemplateBrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "Solidworks Part Template|*.prtdot";
            fd.Multiselect = false;
            DialogResult result = fd.ShowDialog();
            if (result == DialogResult.OK)
            {
                partTemplateTextBox.Text = fd.FileName;
            }
        }

        private void assyTemplateBrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "Solidworks assembly Template|*.asmdot";
            fd.Multiselect = false;
            DialogResult result = fd.ShowDialog();
            if (result == DialogResult.OK)
            {
                assyTemplateTextBox.Text = fd.FileName;
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "CSV File|*.csv";
            fd.FileName = Path.GetFileNameWithoutExtension(project.file);
            DialogResult r = fd.ShowDialog();
            if (r == DialogResult.OK)
            {
                CSVExporter ex = new CSVExporter(project);
                ex.Export(fd.FileName);
                MessageBox.Show("CSV file written!\n\nField delimiter: \";\"\nText delimiter: None", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        private void databaseShowButton_Click(object sender, EventArgs e)
        {
            if (!dbForm.Visible)
            {
                prep_DBForm();
            }
            dbForm.update();
            dbForm.Show();
        }

        private void createAssyButton_Click(object sender, EventArgs e)
        {
            if (propertyNameTextBox.Text == "")
            {
                MessageBox.Show("Enter property name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (assyTemplateTextBox.Text == "")
            {
                MessageBox.Show("Enter assembly template path", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (workDirTextBox.Text == "")
            {
                MessageBox.Show("Enter work dir path", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            NumberInputForm nif = new NumberInputForm(project, project.assyPrefix, project.assySuffix);
            nif.ShowDialog();
            if (!nif.OK)
            {
                return;
            }
            SWAssy f = new SWAssy()
            {
                project = project,
                number = nif.number,
                name = nif.name,
                prefix = nif.prefix,
                suffix = nif.suffix,
                template = assyTemplateTextBox.Text,
            };
            int ret = f.create();
            if (ret == SWFile.RET_DUPLICATE_NUMBER)
            {
                DialogResult r = MessageBox.Show("Part or Assembly with number entered already exists in database. Create anyway?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (r == DialogResult.Yes)
                {
                    ret = SWFile.RET_OK;
                }
            }
            if (ret == SWFile.RET_NAME_EXISTS)
            {
                MessageBox.Show("Part or Assembly with this name already exists!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (ret == SWFile.RET_FILE_EXISTS)
            {
                MessageBox.Show("File already exists!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (ret == SWFile.RET_OK)
            {
                f.save();
                f.addToProject();
            }
            dbForm.update();
        }

        private void assyPrefixTextBox_TextChanged(object sender, EventArgs e)
        {
            project.assyPrefix = assyPrefixTextBox.Text.Trim();
        }

        private void assySuffixTextBox_TextChanged(object sender, EventArgs e)
        {
            project.assySuffix = assySuffixTextBox.Text.Trim();
        }

        private void fileImportButton_Click(object sender, EventArgs e)
        {
            if (propertyNameTextBox.Text == "")
            {
                MessageBox.Show("Enter property name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            OpenFileDialog fd = new OpenFileDialog();
            fd.Multiselect = false;
            fd.Filter = "SolidWorks Part|*.sldprt|Solidworks Assembly|*.sldasm";
            DialogResult result = fd.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (!(fd.FileName.ToLower().StartsWith(project.workDir.ToLower())))
                {
                    MessageBox.Show("File is not in the workdir!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string[] p = SWFile.getFileParams(Path.GetFileNameWithoutExtension(fd.FileName));
                if (p[1] == "")
                {
                    MessageBox.Show("File name has to include a four-digit part number!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //FilePropsForm fpf = new FilePropsForm();
                //fpf.prefixTextBox.Text = p[0];
                //fpf.numericUpDown1.Value = Convert.ToInt32(p[1]);
                //fpf.suffixTextBox.Text = p[2];
                //fpf.ShowDialog();
                //if (!fpf.OK)
                //{
                //    return;
                //}
                //p[0] = fpf.prefixTextBox.Text;
                //p[1] = fpf.numericUpDown1.Value.ToString();
                //p[2] = fpf.suffixTextBox.Text;
                SWFile f = null;

                if (fd.FileName.ToLower().EndsWith(".sldprt"))
                {

                    f = new SWPart()
                    {
                        project = project,
                        number = Convert.ToInt32(p[1]),
                        name = "",
                        prefix = p[0],
                        suffix = p[2],
                        template = null,
                    };
                }
                else if (fd.FileName.ToLower().EndsWith(".sldasm"))
                {
                    f = new SWAssy()
                    {
                        project = project,
                        number = Convert.ToInt32(p[1]),
                        name = "",
                        prefix = p[0],
                        suffix = p[2],
                        template = null,
                    };
                }
                else
                {
                    MessageBox.Show("This is not SolidWorks Part or Assembly!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int ret = f.create();
                if (ret == SWFile.RET_DUPLICATE_NUMBER)
                {
                    DialogResult r = MessageBox.Show("Part or Assembly with number entered already exists in database. Add anyway?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (r == DialogResult.Yes)
                    {
                        ret = SWFile.RET_OK;
                    }
                }
                if (ret == SWFile.RET_NAME_EXISTS)
                {
                    MessageBox.Show("Part or Assembly with this name already exists!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (ret == SWFile.RET_FILE_EXISTS)
                {
                    // Yes, we are adding it right now:)
                    ret = SWFile.RET_OK;
                }
                if (ret == SWFile.RET_OK)
                {
                    f.getNameFromFile();
                    f.addToProject();
                }
            }
            dbForm.update();
        }

        private void removeMissingBatchButton_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("You\'re about to remove every file that is missing on disk from the database. Continue?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                project.removeMissingFiles();
                MessageBox.Show("Missing file removed!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            dbForm.update();
        }

        private void propertyNameTextBox_TextChanged(object sender, EventArgs e)
        {
            propertyNameTextBox.BackColor = Color.White;
            Settings.Default.propertyName = propertyNameTextBox.Text.Trim();
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            if (!propertyNameTextBoxOK())
            {
                return;
            }
            CSVImportForm cif = new CSVImportForm()
            {
                project = project,
            };
            cif.ShowDialog();
        }

        public static Form1 getForm()
        {
            return (Form1)Application.OpenForms.OfType<Form1>().FirstOrDefault();
        }

        private void batchSearchMissingButton_Click(object sender, EventArgs e)
        {
            if (workDirTextBox.Text == "")
            {
                MessageBox.Show("Enter work dir path", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int numFound;
            project.searchForMissingAssemblyFiles(out numFound);
            dbForm.update();
            MessageBox.Show(String.Format("Done. {0} missing files were found as assemblies on disk.", numFound), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            new AboutForm().ShowDialog();
        }

        private void closeProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.workDirTextBox.Text = "";
            this.partPrefixTextBox.Text = "";
            this.partSuffixTextBox.Text = "";
            this.assyPrefixTextBox.Text = "";
            this.assySuffixTextBox.Text = "";
            this.activateUI(true);
            this.project = new Project();
            if (this.dbForm.Visible)
            {
                this.dbForm.Close();
            }
        }
    }
}
