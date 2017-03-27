using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace KngLog
{
    public partial class MainForm : Form
    {
        // the max character list
        public static int MaxCharacters = 300;

        private static List<LogEntry> _logEntries;

        public MainForm()
        {
            InitializeComponent();

            // initialize the list
            _logEntries = new List<LogEntry>();

            // set the maximum length
            logTextBox.MaxLength = MaxCharacters;

            // intialize the character counter
            characterCounterLabel.Text = $"{logTextBox.Text.Length}/{MaxCharacters}";

            // set auto size mode
            logGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // disable last blank row
            logGridView.AllowUserToAddRows = false;

            // bind the data source
            //logGridView.DataSource = _logEntries;

            // initialize the entry counter text.
            entryCounterLabel.Text = "0 entries";
        }

        private void logTextBox_TextChanged(object sender, EventArgs e)
        {
            // update the counter
            characterCounterLabel.Text = $"{logTextBox.Text.Length}/{MaxCharacters}";
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            // don't add if the text is not 
            if (logTextBox.Text.Length < 1)
            {
                return;
            }

            // create the entry
            var logEntry = new LogEntry()
            {
                Entry = logTextBox.Text,
                Date = DateTime.Now.ToString()
            };

            // add the entry
            _logEntries.Add(logEntry);

            // reset the textbox
            logTextBox.Text = "";
            
            // update the gridview
            UpdateGridview();
        }

        private void UpdateGridview()
        {
            // clear the view
            logGridView.Rows.Clear();
            
            // add each item
            foreach(var item in _logEntries)
            {
                string[] row = { item.Entry, item.Date };
                logGridView.Rows.Add(row);
            }

            // update the counter
            entryCounterLabel.Text = $"{logGridView.Rows.Count} entries";
        }
    }
}
