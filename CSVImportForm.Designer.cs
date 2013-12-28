namespace SwProjectInterface
{
    partial class CSVImportForm
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fieldDelimiterTextBox = new System.Windows.Forms.TextBox();
            this.importButton = new System.Windows.Forms.Button();
            this.firstRowNamesCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.columnNumericUpDown5 = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.columnComboBox5 = new System.Windows.Forms.ComboBox();
            this.importFieldBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.columnNumericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.columnNumericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.columnComboBox4 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.columnComboBox3 = new System.Windows.Forms.ComboBox();
            this.columnNumericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.columnNumericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.columnComboBox2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.columnComboBox1 = new System.Windows.Forms.ComboBox();
            this.newProjectButton = new System.Windows.Forms.Button();
            this.omitRowsWithoutNamesCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.columnNumericUpDown5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.importFieldBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnNumericUpDown4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnNumericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnNumericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnNumericUpDown1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Enabled = false;
            this.dataGridView1.Location = new System.Drawing.Point(10, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(316, 186);
            this.dataGridView1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.fieldDelimiterTextBox);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(117, 55);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Field delimiter";
            // 
            // fieldDelimiterTextBox
            // 
            this.fieldDelimiterTextBox.Location = new System.Drawing.Point(7, 20);
            this.fieldDelimiterTextBox.Name = "fieldDelimiterTextBox";
            this.fieldDelimiterTextBox.Size = new System.Drawing.Size(100, 20);
            this.fieldDelimiterTextBox.TabIndex = 0;
            this.fieldDelimiterTextBox.Text = ";";
            // 
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(228, 29);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(75, 23);
            this.importButton.TabIndex = 3;
            this.importButton.Text = "Load file";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // firstRowNamesCheckBox
            // 
            this.firstRowNamesCheckBox.AutoSize = true;
            this.firstRowNamesCheckBox.Location = new System.Drawing.Point(136, 33);
            this.firstRowNamesCheckBox.Name = "firstRowNamesCheckBox";
            this.firstRowNamesCheckBox.Size = new System.Drawing.Size(86, 17);
            this.firstRowNamesCheckBox.TabIndex = 5;
            this.firstRowNamesCheckBox.Text = "Omit first row";
            this.firstRowNamesCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.columnNumericUpDown5);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.columnComboBox5);
            this.groupBox3.Controls.Add(this.columnNumericUpDown4);
            this.groupBox3.Controls.Add(this.columnNumericUpDown3);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.columnComboBox4);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.columnComboBox3);
            this.groupBox3.Controls.Add(this.columnNumericUpDown2);
            this.groupBox3.Controls.Add(this.columnNumericUpDown1);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.columnComboBox2);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.columnComboBox1);
            this.groupBox3.Enabled = false;
            this.groupBox3.Location = new System.Drawing.Point(13, 74);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(332, 154);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Map data";
            // 
            // columnNumericUpDown5
            // 
            this.columnNumericUpDown5.Location = new System.Drawing.Point(55, 123);
            this.columnNumericUpDown5.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.columnNumericUpDown5.Name = "columnNumericUpDown5";
            this.columnNumericUpDown5.Size = new System.Drawing.Size(52, 20);
            this.columnNumericUpDown5.TabIndex = 23;
            this.columnNumericUpDown5.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.columnNumericUpDown5.ValueChanged += new System.EventHandler(this.columnNumericUpDown_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 126);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "Column";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(134, 127);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(19, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "- >";
            // 
            // columnComboBox5
            // 
            this.columnComboBox5.DataSource = this.importFieldBindingSource;
            this.columnComboBox5.DisplayMember = "Name";
            this.columnComboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.columnComboBox5.FormattingEnabled = true;
            this.columnComboBox5.Location = new System.Drawing.Point(179, 124);
            this.columnComboBox5.Name = "columnComboBox5";
            this.columnComboBox5.Size = new System.Drawing.Size(147, 21);
            this.columnComboBox5.TabIndex = 17;
            this.columnComboBox5.ValueMember = "Value";
            this.columnComboBox5.SelectedIndexChanged += new System.EventHandler(this.columnComboBox_SelectedIndexChanged);
            // 
            // importFieldBindingSource
            // 
            this.importFieldBindingSource.DataSource = typeof(SwProjectInterface.importField);
            // 
            // columnNumericUpDown4
            // 
            this.columnNumericUpDown4.Location = new System.Drawing.Point(55, 97);
            this.columnNumericUpDown4.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.columnNumericUpDown4.Name = "columnNumericUpDown4";
            this.columnNumericUpDown4.Size = new System.Drawing.Size(52, 20);
            this.columnNumericUpDown4.TabIndex = 16;
            this.columnNumericUpDown4.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.columnNumericUpDown4.ValueChanged += new System.EventHandler(this.columnNumericUpDown_ValueChanged);
            // 
            // columnNumericUpDown3
            // 
            this.columnNumericUpDown3.Location = new System.Drawing.Point(55, 71);
            this.columnNumericUpDown3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.columnNumericUpDown3.Name = "columnNumericUpDown3";
            this.columnNumericUpDown3.Size = new System.Drawing.Size(52, 20);
            this.columnNumericUpDown3.TabIndex = 15;
            this.columnNumericUpDown3.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.columnNumericUpDown3.ValueChanged += new System.EventHandler(this.columnNumericUpDown_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(134, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "- >";
            // 
            // columnComboBox4
            // 
            this.columnComboBox4.DataSource = this.importFieldBindingSource;
            this.columnComboBox4.DisplayMember = "Name";
            this.columnComboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.columnComboBox4.FormattingEnabled = true;
            this.columnComboBox4.Location = new System.Drawing.Point(179, 97);
            this.columnComboBox4.Name = "columnComboBox4";
            this.columnComboBox4.Size = new System.Drawing.Size(147, 21);
            this.columnComboBox4.TabIndex = 13;
            this.columnComboBox4.ValueMember = "Value";
            this.columnComboBox4.SelectedIndexChanged += new System.EventHandler(this.columnComboBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Column";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Column";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(134, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(19, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "- >";
            // 
            // columnComboBox3
            // 
            this.columnComboBox3.DataSource = this.importFieldBindingSource;
            this.columnComboBox3.DisplayMember = "Name";
            this.columnComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.columnComboBox3.FormattingEnabled = true;
            this.columnComboBox3.Location = new System.Drawing.Point(179, 72);
            this.columnComboBox3.Name = "columnComboBox3";
            this.columnComboBox3.Size = new System.Drawing.Size(147, 21);
            this.columnComboBox3.TabIndex = 9;
            this.columnComboBox3.ValueMember = "Value";
            this.columnComboBox3.SelectedIndexChanged += new System.EventHandler(this.columnComboBox_SelectedIndexChanged);
            // 
            // columnNumericUpDown2
            // 
            this.columnNumericUpDown2.Location = new System.Drawing.Point(55, 45);
            this.columnNumericUpDown2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.columnNumericUpDown2.Name = "columnNumericUpDown2";
            this.columnNumericUpDown2.Size = new System.Drawing.Size(52, 20);
            this.columnNumericUpDown2.TabIndex = 8;
            this.columnNumericUpDown2.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.columnNumericUpDown2.ValueChanged += new System.EventHandler(this.columnNumericUpDown_ValueChanged);
            // 
            // columnNumericUpDown1
            // 
            this.columnNumericUpDown1.Location = new System.Drawing.Point(55, 19);
            this.columnNumericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.columnNumericUpDown1.Name = "columnNumericUpDown1";
            this.columnNumericUpDown1.Size = new System.Drawing.Size(52, 20);
            this.columnNumericUpDown1.TabIndex = 7;
            this.columnNumericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.columnNumericUpDown1.ValueChanged += new System.EventHandler(this.columnNumericUpDown_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(134, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "- >";
            // 
            // columnComboBox2
            // 
            this.columnComboBox2.DataSource = this.importFieldBindingSource;
            this.columnComboBox2.DisplayMember = "Name";
            this.columnComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.columnComboBox2.FormattingEnabled = true;
            this.columnComboBox2.Location = new System.Drawing.Point(179, 45);
            this.columnComboBox2.Name = "columnComboBox2";
            this.columnComboBox2.Size = new System.Drawing.Size(147, 21);
            this.columnComboBox2.TabIndex = 5;
            this.columnComboBox2.ValueMember = "Value";
            this.columnComboBox2.SelectedIndexChanged += new System.EventHandler(this.columnComboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Column";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Column";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(134, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "- >";
            // 
            // columnComboBox1
            // 
            this.columnComboBox1.DataSource = this.importFieldBindingSource;
            this.columnComboBox1.DisplayMember = "Name";
            this.columnComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.columnComboBox1.FormattingEnabled = true;
            this.columnComboBox1.Location = new System.Drawing.Point(179, 20);
            this.columnComboBox1.Name = "columnComboBox1";
            this.columnComboBox1.Size = new System.Drawing.Size(147, 21);
            this.columnComboBox1.TabIndex = 1;
            this.columnComboBox1.ValueMember = "Value";
            this.columnComboBox1.SelectedIndexChanged += new System.EventHandler(this.columnComboBox_SelectedIndexChanged);
            // 
            // newProjectButton
            // 
            this.newProjectButton.Enabled = false;
            this.newProjectButton.Location = new System.Drawing.Point(12, 256);
            this.newProjectButton.Name = "newProjectButton";
            this.newProjectButton.Size = new System.Drawing.Size(332, 23);
            this.newProjectButton.TabIndex = 7;
            this.newProjectButton.Text = "Create new project from imported data";
            this.newProjectButton.UseVisualStyleBackColor = true;
            this.newProjectButton.Click += new System.EventHandler(this.newProjectButton_Click);
            // 
            // omitRowsWithoutNamesCheckBox
            // 
            this.omitRowsWithoutNamesCheckBox.AutoSize = true;
            this.omitRowsWithoutNamesCheckBox.Checked = true;
            this.omitRowsWithoutNamesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.omitRowsWithoutNamesCheckBox.Enabled = false;
            this.omitRowsWithoutNamesCheckBox.Location = new System.Drawing.Point(12, 234);
            this.omitRowsWithoutNamesCheckBox.Name = "omitRowsWithoutNamesCheckBox";
            this.omitRowsWithoutNamesCheckBox.Size = new System.Drawing.Size(143, 17);
            this.omitRowsWithoutNamesCheckBox.TabIndex = 8;
            this.omitRowsWithoutNamesCheckBox.Text = "Omit rows without names";
            this.omitRowsWithoutNamesCheckBox.UseVisualStyleBackColor = true;
            this.omitRowsWithoutNamesCheckBox.CheckedChanged += new System.EventHandler(this.omitRowsWithoutNamesCheckBox_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(12, 286);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(333, 211);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data preview";
            // 
            // CSVImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 505);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.omitRowsWithoutNamesCheckBox);
            this.Controls.Add(this.newProjectButton);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.firstRowNamesCheckBox);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CSVImportForm";
            this.Text = "Import data from CSV file";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.columnNumericUpDown5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.importFieldBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnNumericUpDown4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnNumericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnNumericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnNumericUpDown1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox fieldDelimiterTextBox;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.CheckBox firstRowNamesCheckBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button newProjectButton;
        private System.Windows.Forms.CheckBox omitRowsWithoutNamesCheckBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox columnComboBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox columnComboBox1;
        private System.Windows.Forms.NumericUpDown columnNumericUpDown2;
        private System.Windows.Forms.NumericUpDown columnNumericUpDown1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.BindingSource importFieldBindingSource;
        private System.Windows.Forms.NumericUpDown columnNumericUpDown5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox columnComboBox5;
        private System.Windows.Forms.NumericUpDown columnNumericUpDown4;
        private System.Windows.Forms.NumericUpDown columnNumericUpDown3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox columnComboBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox columnComboBox3;
    }
}