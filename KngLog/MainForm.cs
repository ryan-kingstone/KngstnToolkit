using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace KngLog
{
    public partial class MainForm : Form
    {
        public static string FilePath = "knglogdb.json";

        // the max character list
        public static int MaxCharacters = 300;

        private static List<LogEntry> _logEntries;

        private List<Control> _controls;

        public MainForm()
        {
            InitializeComponent();

            // initialize the lists
            _logEntries = new List<LogEntry>();
            _controls = new List<Control>();

            // set the maximum length
            logTextBox.MaxLength = MaxCharacters;

            // intialize the character counter
            characterCounterLabel.Text = $"{logTextBox.Text.Length}/{MaxCharacters}";

            // initialize the entry counter text.
            entryGroupBox.Text = @"0 entries";

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
                Date = DateTime.Now.ToString(CultureInfo.CurrentCulture)
            };

            // add the entry
            _logEntries.Add(logEntry);

            // reset the textbox
            logTextBox.Text = "";

            // save the data to the file
            SaveData(_logEntries);

            // update the gridview
            UpdateGridview();
        }

        private void UpdateGridview()
        {
            EntryPanel.Controls.Clear();

            var sortedEntries = _logEntries.OrderByDescending(p => p.Date);

            int count = 0;
            foreach (var item in sortedEntries)
            {
                Panel pan = new Panel();
                pan.Location = new Point(5, 2 + EntryPanel.Controls.Count * 110);
                pan.BackColor = Color.LightGray;
                pan.Width = EntryPanel.Width - 22;
                pan.Height = 100;
                EntryPanel.Controls.Add(pan);

                Label chb = new Label();
                chb.Text = item.Entry;
                chb.Width = EntryPanel.Width - 22;
                chb.Height = 85;
                chb.BackColor = Color.LightGray;
                chb.Font = new Font("Segoe UI", 11f);
                chb.Location = new Point(0, pan.Controls.Count * 60);
                pan.Controls.Add(chb);

                Label dateLabel = new Label();
                dateLabel.Text = item.Date;
                dateLabel.Width = EntryPanel.Width - 22;
                dateLabel.Height = 15;
                dateLabel.Font = new Font("Segoe UI", 8.6f);
                dateLabel.ForeColor = Color.Gray;
                dateLabel.Location = new Point(0, pan.Controls.Count * 60 + 25);
                pan.Controls.Add(dateLabel);
            }

            // update the counter
            entryGroupBox.Text = $"{_logEntries.Count} entries";
        }

        private void SaveData(List<LogEntry> entries)
        {
            var json = JsonConvert.SerializeObject(entries);
            File.WriteAllText(FilePath, json);
        }

        private void LoadData()
        {

            if (File.Exists(FilePath))
            {
                var fileContent = File.ReadAllText(FilePath);
                if (fileContent.Length > 1)
                {
                    var list = JsonConvert.DeserializeObject<List<LogEntry>>(fileContent);

                    foreach (var entry in list)
                    {
                        _logEntries.Add(entry);
                    }

                    // update the grid view
                    UpdateGridview();
                }
            } else SaveData(_logEntries);
        }
    }
}
