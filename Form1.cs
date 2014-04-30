using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.Win32;

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

            this.populateRecent();

            string[] args = Environment.GetCommandLineArgs();

            if (args.Length > 1)
            {
                loadProject(args[1].ToString());
            }
        }

        private void populateRecent()
        {
            recentProjectsToolStripMenuItem.Enabled = false;
            recentProjectsToolStripMenuItem.DropDownItems.Clear();
            if (Settings.Default.RecentProjects == null)
            {
                Settings.Default.RecentProjects = new System.Collections.Specialized.StringCollection();
            }
            foreach (String path in Settings.Default.RecentProjects)
            {
                recentProjectsToolStripMenuItem.DropDownItems.Add(path, null, onRecentClick);
                recentProjectsToolStripMenuItem.Enabled = true;
            }
        }

        private void loadProject(String path)
        {
            if (this.project != new Project())
            {
                this.askSave();
                this.project = new Project();
                this.onProjectCloseUI();
            }
            try
            {
                this.project.open(path);
            }
            catch (ProjectReadException exception)
            {
                MessageBox.Show("XML parse error: " + exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.populateRecent();
            this.onProjectOpenUI();
        }

        private void onProjectOpenUI()
        {
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

        private void onProjectCloseUI()
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

        private void onRecentClick(object sender, EventArgs e)
        {
            this.loadProject(sender.ToString());
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
            if (project.file == null || project.file == "")
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
            fd.Multiselect = true;
            fd.Filter = "SolidWorks Part|*.sldprt|Solidworks Assembly|*.sldasm";
            DialogResult result = fd.ShowDialog();
            if (result == DialogResult.OK)
            {
                foreach (String FileName in fd.FileNames)
                {
                    if (!(FileName.ToLower().StartsWith(project.workDir.ToLower())))
                    {
                        MessageBox.Show(String.Format("File {0} is not in the workdir! Not adding this file.", FileName), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        continue;
                    }

                    string[] p = SWFile.getFileParams(Path.GetFileNameWithoutExtension(FileName));
                    if (p[1] == "")
                    {
                        MessageBox.Show(String.Format("File {0} name does not include a four-digit part number! Not adding this file.", FileName), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        continue;
                    }
                    SWFile f = null;

                    if (FileName.ToLower().EndsWith(".sldprt"))
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
                    else if (FileName.ToLower().EndsWith(".sldasm"))
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
                        MessageBox.Show(String.Format("{0} is not SolidWorks Part or Assembly!", FileName), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        continue;
                    }

                    int ret = f.create();
                    if (ret == SWFile.RET_DUPLICATE_NUMBER)
                    {
                        DialogResult r = MessageBox.Show(String.Format("{0}: Part or Assembly with this number already exists in database. Add anyway?", FileName), "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (r == DialogResult.Yes)
                        {
                            ret = SWFile.RET_OK;
                        }
                    }
                    if (ret == SWFile.RET_NAME_EXISTS)
                    {
                        MessageBox.Show(String.Format("{0}: Part or Assembly with this prefix number suffix combination already exists! Not adding this file.", FileName), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue;
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

        private void closeProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.askSave();
            this.onProjectCloseUI();
        }

        private void showInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutForm().ShowDialog();
        }

        private void registerswpiFilesWithSwProjectInterfaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String path = Environment.GetCommandLineArgs()[0];
            Registry.ClassesRoot.CreateSubKey(".swpi").SetValue("", "SwProjectInterface.swpi", RegistryValueKind.String);
            Registry.ClassesRoot.CreateSubKey("SwProjectInterface.swpi").CreateSubKey("shell").CreateSubKey("open").CreateSubKey("command").SetValue("", String.Format("{0} %1", path));
            MessageBox.Show(String.Format(".swpi extension registered with this copy of SwProjectInterface!\n\n[{0}]", path), "Extension registered.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
