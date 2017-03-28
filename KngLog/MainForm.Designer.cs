namespace KngLog
{
    partial class MainForm
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
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.characterCounterLabel = new System.Windows.Forms.Label();
            this.entryGroupBox = new System.Windows.Forms.GroupBox();
            this.EntryPanel = new System.Windows.Forms.Panel();
            this.entryGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // logTextBox
            // 
            this.logTextBox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logTextBox.Location = new System.Drawing.Point(13, 13);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.Size = new System.Drawing.Size(656, 120);
            this.logTextBox.TabIndex = 0;
            this.logTextBox.TextChanged += new System.EventHandler(this.logTextBox_TextChanged);
            // 
            // submitButton
            // 
            this.submitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitButton.Location = new System.Drawing.Point(577, 139);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(92, 31);
            this.submitButton.TabIndex = 1;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // characterCounterLabel
            // 
            this.characterCounterLabel.AutoSize = true;
            this.characterCounterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.characterCounterLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.characterCounterLabel.Location = new System.Drawing.Point(517, 145);
            this.characterCounterLabel.Name = "characterCounterLabel";
            this.characterCounterLabel.Size = new System.Drawing.Size(54, 18);
            this.characterCounterLabel.TabIndex = 2;
            this.characterCounterLabel.Text = "xxx/xxx";
            this.characterCounterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // entryGroupBox
            // 
            this.entryGroupBox.BackColor = System.Drawing.SystemColors.Control;
            this.entryGroupBox.Controls.Add(this.EntryPanel);
            this.entryGroupBox.Location = new System.Drawing.Point(12, 173);
            this.entryGroupBox.Name = "entryGroupBox";
            this.entryGroupBox.Size = new System.Drawing.Size(657, 292);
            this.entryGroupBox.TabIndex = 5;
            this.entryGroupBox.TabStop = false;
            this.entryGroupBox.Text = "Log";
            // 
            // EntryPanel
            // 
            this.EntryPanel.AutoScroll = true;
            this.EntryPanel.BackColor = System.Drawing.SystemColors.Control;
            this.EntryPanel.Location = new System.Drawing.Point(6, 19);
            this.EntryPanel.Name = "EntryPanel";
            this.EntryPanel.Size = new System.Drawing.Size(645, 267);
            this.EntryPanel.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 477);
            this.Controls.Add(this.entryGroupBox);
            this.Controls.Add(this.characterCounterLabel);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.logTextBox);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "KngLog";
            this.entryGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label characterCounterLabel;
        private System.Windows.Forms.GroupBox entryGroupBox;
        private System.Windows.Forms.Panel EntryPanel;
    }
}

