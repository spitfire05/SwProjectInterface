using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace SwProjectInterface
{
    public partial class databaseForm : Form
    {
        public Project project;

        private SWFile currentContextFile;
        private List<SWFile> filesToUpdate = new List<SWFile>();
        private Timer aTimer;

        public databaseForm()
        {
            InitializeComponent();
            aTimer = new Timer();
            aTimer.Interval = 250;
            aTimer.Tick += new EventHandler(aTimer_Tick);
        }

        void aTimer_Tick(object sender, EventArgs e)
        {
            foreach (SWFile f in filesToUpdate)
            {
                Debug.WriteLine(String.Format("databaseForm timer tick: Updating file {0}", f.ToString()));
                updateFile(f);
            }
            filesToUpdate.Clear();
        }

        public void update()
        {
            dataGridView1.Columns[nameColumn.Name].HeaderText = Settings.Default.propertyName;
            dataGridView1.Rows.Clear();
            List<SWFile> files_s = project.files.OrderBy<SWFile, int>(x => x.number).ToList<SWFile>();
            foreach (SWFile f in files_s)
            {
                DataGridViewRow row = new DataGridViewRow();
                SWFileStatus s = f.getStatus();
                f.lastShownStatus = s;
                row.CreateCells(dataGridView1, f.typeString, f.prefix, SWFile.fourDigit(f.number), f.suffix, f.name, f.file, s.ToString());
                if (row.Cells.Count == 0)
                {
                    // Happens when updating closed form
                    continue;
                }
                row.Tag = f;
                row.Cells[dataGridView1.Columns["statusColumn"].Index].Style.ForeColor = s.Color;
                dataGridView1.Rows.Add(row);
            }
        }

        /// <summary>
        /// Schedules update of file's name, path and status in grid view. Use this if calling update from foreign thread.
        /// </summary>
        /// <param name="f">File to update</param>
        public void scheduleFileUpdate(SWFile f)
        {
            filesToUpdate.Add(f);
        }
        
        /// <summary>
        /// Updates file's name, path and status in grid view. Use only from thread that created the UI !!!
        /// </summary>
        /// <param name="f">File to update</param>
        public void updateFile(SWFile f)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Tag == f)
                {
                    row.Cells[typeColumn.Index].Value = f.typeString;
                    row.Cells[nameColumn.Index].Value = f.name;
                    row.Cells[filepath.Index].Value = f.file;

                    SWFileStatus s = f.getStatus();
                    if (s != f.lastShownStatus)
                    {
                        row.Cells[statusColumn.Index].Value = s.ToString();
                        row.Cells[dataGridView1.Columns["statusColumn"].Index].Style.ForeColor = s.Color;
                    }
                    f.lastShownStatus = s;
                    break;
                }
            }
        }

        private SWFile getFileByRowIndex(int rowIndex)
        {
            DataGridViewRow row = dataGridView1.Rows[rowIndex];
            return (SWFile)row.Tag;
        }

        private void dataGridView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo ht;
                ht = dataGridView1.HitTest(e.X, e.Y);
                if (ht.Type == DataGridViewHitTestType.Cell)
                {
                    currentContextFile = getFileByRowIndex(ht.RowIndex);

                    contextMenuStrip1.Items[changePropertyValueMenuItem.Name].Text = String.Format(contextMenuStrip1.Items[changePropertyValueMenuItem.Name].Text, Settings.Default.propertyName);

                    contextMenuStrip1.Items[chooseFileManuallyToolStripMenuItem.Name].Enabled = false;
                    if (currentContextFile.getStatus().Type == SWFileStatusType.FILE_MISSING)
                    {
                        contextMenuStrip1.Items[chooseFileManuallyToolStripMenuItem.Name].Enabled = true;
                    }
                    contextMenuStrip1.Show(dataGridView1, e.Location);
                }
            }
        }

        private void openFile(SWFile f)
        {
            int ret = f.open();
            if (ret == SWFile.RET_FILE_MISSING)
            {
                MessageBox.Show(String.Format("Can\'t find file {0}", f.file), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chooseFile(SWFile f)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Multiselect = false;
            fd.Filter = "SolidWorks Part|*.sldprt|Solidworks Assembly|*.sldasm";
            DialogResult r = fd.ShowDialog();
            if (r == DialogResult.OK)
            {
                if (!(fd.FileName.ToLower().StartsWith(project.workDir.ToLower())))
                {
                    MessageBox.Show("File is not in the workdir!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                f.file = Path.GetFileName(fd.FileName);
                updateFile(currentContextFile);
            }
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // Hide context menu
            contextMenuStrip1.Hide();

            if (e.ClickedItem == contextMenuStrip1.Items[openToolStripMenuItem.Name])
            {
                // Open
                openFile(currentContextFile);
            }
            else if (e.ClickedItem == contextMenuStrip1.Items[readNamePropertyFromFileToolStripMenuItem.Name])
            {
                // Read name
                currentContextFile.getNameFromFile();
                if (currentContextFile.getStatus().Type == SWFileStatusType.FILE_MISSING)
                {
                    MessageBox.Show(String.Format("Can not read from missing file!", currentContextFile.file), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                updateFile(currentContextFile);
            }
            else if (e.ClickedItem == contextMenuStrip1.Items[changePropertyValueMenuItem.Name])
            {
                // Change property value
                if (currentContextFile.getStatus().Type == SWFileStatusType.FILE_MISSING)
                {
                    MessageBox.Show("Changing property value of missing file!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                ChangePropertyForm cpf = new ChangePropertyForm(this.project, this.currentContextFile);
                DialogResult r = cpf.ShowDialog();
                if (r == DialogResult.OK && currentContextFile.getStatus().Type != SWFileStatusType.FILE_MISSING)
                {
                    this.currentContextFile.setName(cpf.valueTextBox.Text.Trim());
                }
                else if (currentContextFile.getStatus().Type == SWFileStatusType.FILE_MISSING)
                {
                    this.currentContextFile.name = cpf.valueTextBox.Text.Trim();
                    this.updateFile(this.currentContextFile);
                }
            }
            else if (e.ClickedItem == contextMenuStrip1.Items[removeToolStripMenuItem.Name])
            {
                // Remove
                DialogResult r = MessageBox.Show(String.Format("Remove file {0} ?", currentContextFile.file), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.No)
                {
                    return;
                }
                if (currentContextFile.getStatus().Type != SWFileStatusType.FILE_MISSING)
                {
                    r = MessageBox.Show(String.Format("Remove file {0} also from disk?", currentContextFile.file), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        currentContextFile.removeFromDisk();
                    }
                }
                currentContextFile.removeFromProject();
                update();
            }
            else if (e.ClickedItem == contextMenuStrip1.Items[chooseFileManuallyToolStripMenuItem.Name])
            {
                // Choose manually
                chooseFile(currentContextFile);
            }
            // Re-disable menus that should be disabled by default
            contextMenuStrip1.Items[chooseFileManuallyToolStripMenuItem.Name].Enabled = false;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            currentContextFile = getFileByRowIndex(e.RowIndex);
            openFile(currentContextFile);
        }

        private void databaseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            aTimer.Stop();
        }

        private void databaseForm_Shown(object sender, EventArgs e)
        {
            aTimer.Start();
        }
    }
}
