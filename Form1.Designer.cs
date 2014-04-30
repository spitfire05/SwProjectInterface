namespace SwProjectInterface
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.createPartButton = new System.Windows.Forms.Button();
            this.partTemplateTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.partTemplateBrowseButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.assyTemplateTextBox = new System.Windows.Forms.TextBox();
            this.assyTemplateBrowseButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.partSuffixTextBox = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.partPrefixTextBox = new System.Windows.Forms.TextBox();
            this.fileImportButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.assyPrefixTextBox = new System.Windows.Forms.TextBox();
            this.createAssyButton = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.assySuffixTextBox = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.workDirBrowseButton = new System.Windows.Forms.Button();
            this.workDirTextBox = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.projectTextBox = new System.Windows.Forms.TextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.batchSearchMissingButton = new System.Windows.Forms.Button();
            this.removeMissingBatchButton = new System.Windows.Forms.Button();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.propertyNameTextBox = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.recentProjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showDatabaseFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registerswpiFilesWithSwProjectInterfaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // createPartButton
            // 
            this.createPartButton.Location = new System.Drawing.Point(7, 132);
            this.createPartButton.Name = "createPartButton";
            this.createPartButton.Size = new System.Drawing.Size(194, 23);
            this.createPartButton.TabIndex = 0;
            this.createPartButton.Text = "Create Part";
            this.createPartButton.UseVisualStyleBackColor = true;
            this.createPartButton.Click += new System.EventHandler(this.createPartButton_Click);
            // 
            // partTemplateTextBox
            // 
            this.partTemplateTextBox.Location = new System.Drawing.Point(68, 19);
            this.partTemplateTextBox.Name = "partTemplateTextBox";
            this.partTemplateTextBox.Size = new System.Drawing.Size(265, 20);
            this.partTemplateTextBox.TabIndex = 1;
            this.partTemplateTextBox.TextChanged += new System.EventHandler(this.partTemplateTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Part";
            // 
            // partTemplateBrowseButton
            // 
            this.partTemplateBrowseButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.partTemplateBrowseButton.Location = new System.Drawing.Point(339, 16);
            this.partTemplateBrowseButton.Name = "partTemplateBrowseButton";
            this.partTemplateBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.partTemplateBrowseButton.TabIndex = 3;
            this.partTemplateBrowseButton.Text = "Browse...";
            this.partTemplateBrowseButton.UseVisualStyleBackColor = true;
            this.partTemplateBrowseButton.Click += new System.EventHandler(this.partTemplateBrowseButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Assmebly";
            // 
            // assyTemplateTextBox
            // 
            this.assyTemplateTextBox.Location = new System.Drawing.Point(68, 45);
            this.assyTemplateTextBox.Name = "assyTemplateTextBox";
            this.assyTemplateTextBox.Size = new System.Drawing.Size(265, 20);
            this.assyTemplateTextBox.TabIndex = 5;
            this.assyTemplateTextBox.TextChanged += new System.EventHandler(this.assyTemplateTextBox_TextChanged);
            // 
            // assyTemplateBrowseButton
            // 
            this.assyTemplateBrowseButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.assyTemplateBrowseButton.Location = new System.Drawing.Point(339, 44);
            this.assyTemplateBrowseButton.Name = "assyTemplateBrowseButton";
            this.assyTemplateBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.assyTemplateBrowseButton.TabIndex = 6;
            this.assyTemplateBrowseButton.Text = "Browse...";
            this.assyTemplateBrowseButton.UseVisualStyleBackColor = true;
            this.assyTemplateBrowseButton.Click += new System.EventHandler(this.assyTemplateBrowseButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.partTemplateTextBox);
            this.groupBox1.Controls.Add(this.assyTemplateBrowseButton);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.assyTemplateTextBox);
            this.groupBox1.Controls.Add(this.partTemplateBrowseButton);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 441);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(427, 75);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Templates";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox6);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.createPartButton);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(12, 134);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(209, 161);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Part";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.partSuffixTextBox);
            this.groupBox6.Location = new System.Drawing.Point(7, 76);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(194, 50);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Suffix";
            // 
            // partSuffixTextBox
            // 
            this.partSuffixTextBox.Location = new System.Drawing.Point(7, 19);
            this.partSuffixTextBox.Name = "partSuffixTextBox";
            this.partSuffixTextBox.Size = new System.Drawing.Size(181, 20);
            this.partSuffixTextBox.TabIndex = 0;
            this.partSuffixTextBox.TextChanged += new System.EventHandler(this.partSuffixTextBox_TextChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.partPrefixTextBox);
            this.groupBox5.Location = new System.Drawing.Point(7, 20);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(194, 50);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Prefix";
            // 
            // partPrefixTextBox
            // 
            this.partPrefixTextBox.Location = new System.Drawing.Point(7, 19);
            this.partPrefixTextBox.Name = "partPrefixTextBox";
            this.partPrefixTextBox.Size = new System.Drawing.Size(181, 20);
            this.partPrefixTextBox.TabIndex = 0;
            this.partPrefixTextBox.TextChanged += new System.EventHandler(this.partPrefixTextBox_TextChanged);
            // 
            // fileImportButton
            // 
            this.fileImportButton.Enabled = false;
            this.fileImportButton.Location = new System.Drawing.Point(19, 301);
            this.fileImportButton.Name = "fileImportButton";
            this.fileImportButton.Size = new System.Drawing.Size(411, 23);
            this.fileImportButton.TabIndex = 3;
            this.fileImportButton.Text = "Add existing file(s)";
            this.fileImportButton.UseVisualStyleBackColor = true;
            this.fileImportButton.Click += new System.EventHandler(this.fileImportButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox10);
            this.groupBox3.Controls.Add(this.createAssyButton);
            this.groupBox3.Controls.Add(this.groupBox9);
            this.groupBox3.Enabled = false;
            this.groupBox3.Location = new System.Drawing.Point(230, 134);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(209, 161);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Assembly";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.assyPrefixTextBox);
            this.groupBox10.Location = new System.Drawing.Point(9, 20);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(194, 50);
            this.groupBox10.TabIndex = 1;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Prefix";
            // 
            // assyPrefixTextBox
            // 
            this.assyPrefixTextBox.Location = new System.Drawing.Point(7, 19);
            this.assyPrefixTextBox.Name = "assyPrefixTextBox";
            this.assyPrefixTextBox.Size = new System.Drawing.Size(181, 20);
            this.assyPrefixTextBox.TabIndex = 0;
            this.assyPrefixTextBox.TextChanged += new System.EventHandler(this.assyPrefixTextBox_TextChanged);
            // 
            // createAssyButton
            // 
            this.createAssyButton.Location = new System.Drawing.Point(6, 132);
            this.createAssyButton.Name = "createAssyButton";
            this.createAssyButton.Size = new System.Drawing.Size(194, 23);
            this.createAssyButton.TabIndex = 0;
            this.createAssyButton.Text = "Create Assembly";
            this.createAssyButton.UseVisualStyleBackColor = true;
            this.createAssyButton.Click += new System.EventHandler(this.createAssyButton_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.assySuffixTextBox);
            this.groupBox9.Location = new System.Drawing.Point(9, 76);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(194, 50);
            this.groupBox9.TabIndex = 2;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Suffix";
            // 
            // assySuffixTextBox
            // 
            this.assySuffixTextBox.Location = new System.Drawing.Point(7, 19);
            this.assySuffixTextBox.Name = "assySuffixTextBox";
            this.assySuffixTextBox.Size = new System.Drawing.Size(181, 20);
            this.assySuffixTextBox.TabIndex = 0;
            this.assySuffixTextBox.TextChanged += new System.EventHandler(this.assySuffixTextBox_TextChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.workDirBrowseButton);
            this.groupBox4.Controls.Add(this.workDirTextBox);
            this.groupBox4.Enabled = false;
            this.groupBox4.Location = new System.Drawing.Point(12, 78);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(424, 50);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Work Dir";
            // 
            // workDirBrowseButton
            // 
            this.workDirBrowseButton.Location = new System.Drawing.Point(339, 17);
            this.workDirBrowseButton.Name = "workDirBrowseButton";
            this.workDirBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.workDirBrowseButton.TabIndex = 1;
            this.workDirBrowseButton.Text = "Browse...";
            this.workDirBrowseButton.UseVisualStyleBackColor = true;
            this.workDirBrowseButton.Click += new System.EventHandler(this.workDirBrowseButton_Click);
            // 
            // workDirTextBox
            // 
            this.workDirTextBox.Location = new System.Drawing.Point(7, 20);
            this.workDirTextBox.Name = "workDirTextBox";
            this.workDirTextBox.Size = new System.Drawing.Size(326, 20);
            this.workDirTextBox.TabIndex = 0;
            this.workDirTextBox.TextChanged += new System.EventHandler(this.workDirTextBox_TextChanged);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.projectTextBox);
            this.groupBox7.Location = new System.Drawing.Point(12, 27);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(427, 45);
            this.groupBox7.TabIndex = 11;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Project";
            // 
            // projectTextBox
            // 
            this.projectTextBox.Location = new System.Drawing.Point(7, 19);
            this.projectTextBox.Name = "projectTextBox";
            this.projectTextBox.ReadOnly = true;
            this.projectTextBox.Size = new System.Drawing.Size(407, 20);
            this.projectTextBox.TabIndex = 3;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.batchSearchMissingButton);
            this.groupBox8.Controls.Add(this.removeMissingBatchButton);
            this.groupBox8.Enabled = false;
            this.groupBox8.Location = new System.Drawing.Point(12, 331);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(427, 49);
            this.groupBox8.TabIndex = 12;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Batch";
            // 
            // batchSearchMissingButton
            // 
            this.batchSearchMissingButton.Location = new System.Drawing.Point(219, 20);
            this.batchSearchMissingButton.Name = "batchSearchMissingButton";
            this.batchSearchMissingButton.Size = new System.Drawing.Size(202, 23);
            this.batchSearchMissingButton.TabIndex = 1;
            this.batchSearchMissingButton.Text = "Auto search for missing files";
            this.batchSearchMissingButton.UseVisualStyleBackColor = true;
            this.batchSearchMissingButton.Click += new System.EventHandler(this.batchSearchMissingButton_Click);
            // 
            // removeMissingBatchButton
            // 
            this.removeMissingBatchButton.Location = new System.Drawing.Point(7, 20);
            this.removeMissingBatchButton.Name = "removeMissingBatchButton";
            this.removeMissingBatchButton.Size = new System.Drawing.Size(202, 23);
            this.removeMissingBatchButton.TabIndex = 0;
            this.removeMissingBatchButton.Text = "Remove missing files";
            this.removeMissingBatchButton.UseVisualStyleBackColor = true;
            this.removeMissingBatchButton.Click += new System.EventHandler(this.removeMissingBatchButton_Click);
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.propertyNameTextBox);
            this.groupBox11.Location = new System.Drawing.Point(12, 387);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(427, 48);
            this.groupBox11.TabIndex = 13;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Custom property name";
            // 
            // propertyNameTextBox
            // 
            this.propertyNameTextBox.Location = new System.Drawing.Point(7, 19);
            this.propertyNameTextBox.Name = "propertyNameTextBox";
            this.propertyNameTextBox.Size = new System.Drawing.Size(414, 20);
            this.propertyNameTextBox.TabIndex = 0;
            this.propertyNameTextBox.TextChanged += new System.EventHandler(this.propertyNameTextBox_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projectToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(449, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // projectToolStripMenuItem
            // 
            this.projectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.closeProjectToolStripMenuItem,
            this.toolStripSeparator1,
            this.recentProjectsToolStripMenuItem});
            this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            this.projectToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.projectToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.projectNewButton_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.projectOpenButton_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.projectSaveButton_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.importToolStripMenuItem.Text = "Import";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importButton_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Enabled = false;
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // closeProjectToolStripMenuItem
            // 
            this.closeProjectToolStripMenuItem.Enabled = false;
            this.closeProjectToolStripMenuItem.Name = "closeProjectToolStripMenuItem";
            this.closeProjectToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.closeProjectToolStripMenuItem.Text = "Close";
            this.closeProjectToolStripMenuItem.Click += new System.EventHandler(this.closeProjectToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(159, 6);
            // 
            // recentProjectsToolStripMenuItem
            // 
            this.recentProjectsToolStripMenuItem.Name = "recentProjectsToolStripMenuItem";
            this.recentProjectsToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.recentProjectsToolStripMenuItem.Text = "Recently opened";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDatabaseFormToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // showDatabaseFormToolStripMenuItem
            // 
            this.showDatabaseFormToolStripMenuItem.Enabled = false;
            this.showDatabaseFormToolStripMenuItem.Name = "showDatabaseFormToolStripMenuItem";
            this.showDatabaseFormToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.showDatabaseFormToolStripMenuItem.Text = "Show/Refresh Database Window";
            this.showDatabaseFormToolStripMenuItem.Click += new System.EventHandler(this.databaseShowButton_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showInfoToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // showInfoToolStripMenuItem
            // 
            this.showInfoToolStripMenuItem.Name = "showInfoToolStripMenuItem";
            this.showInfoToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.showInfoToolStripMenuItem.Text = "Show info...";
            this.showInfoToolStripMenuItem.Click += new System.EventHandler(this.showInfoToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registerswpiFilesWithSwProjectInterfaceToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // registerswpiFilesWithSwProjectInterfaceToolStripMenuItem
            // 
            this.registerswpiFilesWithSwProjectInterfaceToolStripMenuItem.Name = "registerswpiFilesWithSwProjectInterfaceToolStripMenuItem";
            this.registerswpiFilesWithSwProjectInterfaceToolStripMenuItem.Size = new System.Drawing.Size(297, 22);
            this.registerswpiFilesWithSwProjectInterfaceToolStripMenuItem.Text = "Register .swpi files with SwProjectInterface";
            this.registerswpiFilesWithSwProjectInterfaceToolStripMenuItem.Click += new System.EventHandler(this.registerswpiFilesWithSwProjectInterfaceToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 527);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox11);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.fileImportButton);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "SwProjectInterface";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createPartButton;
        private System.Windows.Forms.TextBox partTemplateTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button partTemplateBrowseButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox assyTemplateTextBox;
        private System.Windows.Forms.Button assyTemplateBrowseButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button workDirBrowseButton;
        private System.Windows.Forms.TextBox workDirTextBox;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox partSuffixTextBox;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox partPrefixTextBox;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox projectTextBox;
        private System.Windows.Forms.Button fileImportButton;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.TextBox assyPrefixTextBox;
        private System.Windows.Forms.Button createAssyButton;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.TextBox assySuffixTextBox;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button removeMissingBatchButton;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.TextBox propertyNameTextBox;
        private System.Windows.Forms.Button batchSearchMissingButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showDatabaseFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recentProjectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registerswpiFilesWithSwProjectInterfaceToolStripMenuItem;
    }
}

