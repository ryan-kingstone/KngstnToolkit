using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
            logGridView.AllowUserToDeleteRows = true;

            // bind the data source
            //logGridView.DataSource = _logEntries;

            // initialize the entry counter text.
            entryCounterLabel.Text = "0 entries";

            LoadData();
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

            // save the data to the file
            SaveData();

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

        private void SaveData()
        {
            var json = JsonConvert.SerializeObject(_logEntries);
            File.WriteAllText("knglogdb.json", json);
        }

        private void LoadData()
        {
            var fileContent = File.ReadAllText("knglogdb.json");
            if(fileContent.Length > 1)
            {
                var list = JsonConvert.DeserializeObject<List<LogEntry>>(fileContent);
                
                foreach(var entry in list)
                {
                    _logEntries.Add(entry);
                }

                // update the grid view
                UpdateGridview();
            }
        }

        private void logGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void logGridView_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (logGridView.SelectedCells.Count > 0)
            {
                int selectedrowindex = logGridView.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = logGridView.Rows[selectedrowindex];

                string a = Convert.ToString(selectedRow.Cells[0].Value);
                string b = Convert.ToString(selectedRow.Cells[1].Value);
                System.Diagnostics.Debug.WriteLine($"A string rel {a} {b}");

            }
        }
    }
}
