namespace SwProjectInterface
{
    partial class ChangePropertyForm
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
            this.valueGroupBox = new System.Windows.Forms.GroupBox();
            this.valueTextBox = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.valueGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // valueGroupBox
            // 
            this.valueGroupBox.Controls.Add(this.valueTextBox);
            this.valueGroupBox.Location = new System.Drawing.Point(13, 13);
            this.valueGroupBox.Name = "valueGroupBox";
            this.valueGroupBox.Size = new System.Drawing.Size(446, 54);
            this.valueGroupBox.TabIndex = 0;
            this.valueGroupBox.TabStop = false;
            this.valueGroupBox.Text = "{0}";
            // 
            // valueTextBox
            // 
            this.valueTextBox.Location = new System.Drawing.Point(7, 20);
            this.valueTextBox.Name = "valueTextBox";
            this.valueTextBox.Size = new System.Drawing.Size(433, 20);
            this.valueTextBox.TabIndex = 0;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(13, 73);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(384, 73);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // ChangePropertyForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(471, 103);
            this.ControlBox = false;
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.valueGroupBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangePropertyForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Change custom property value";
            this.valueGroupBox.ResumeLayout(false);
            this.valueGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox valueGroupBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        public System.Windows.Forms.TextBox valueTextBox;
    }
}