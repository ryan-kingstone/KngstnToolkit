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
            this.logGridView = new System.Windows.Forms.DataGridView();
            this.entryCounterLabel = new System.Windows.Forms.Label();
            this.Entry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.logGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // logTextBox
            // 
            this.logTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            // logGridView
            // 
            this.logGridView.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.logGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.logGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Entry,
            this.Date});
            this.logGridView.Location = new System.Drawing.Point(13, 176);
            this.logGridView.Name = "logGridView";
            this.logGridView.ReadOnly = true;
            this.logGridView.Size = new System.Drawing.Size(656, 179);
            this.logGridView.TabIndex = 3;
            // 
            // entryCounterLabel
            // 
            this.entryCounterLabel.AutoSize = true;
            this.entryCounterLabel.Location = new System.Drawing.Point(13, 157);
            this.entryCounterLabel.Name = "entryCounterLabel";
            this.entryCounterLabel.Size = new System.Drawing.Size(46, 13);
            this.entryCounterLabel.TabIndex = 4;
            this.entryCounterLabel.Text = "x entries";
            // 
            // Entry
            // 
            this.Entry.HeaderText = "Entry Text";
            this.Entry.Name = "Entry";
            this.Entry.ReadOnly = true;
            this.Entry.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Entry.Width = 490;
            // 
            // Date
            // 
            this.Date.HeaderText = "Last modified";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Date.Width = 120;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 367);
            this.Controls.Add(this.entryCounterLabel);
            this.Controls.Add(this.logGridView);
            this.Controls.Add(this.characterCounterLabel);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.logTextBox);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "KngLog";
            ((System.ComponentModel.ISupportInitialize)(this.logGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label characterCounterLabel;
        private System.Windows.Forms.DataGridView logGridView;
        private System.Windows.Forms.Label entryCounterLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Entry;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
    }
}

