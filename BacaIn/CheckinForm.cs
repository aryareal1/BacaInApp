using System;
using System.Drawing;
using System.Windows.Forms;
using BacaIn.Services;

namespace BacaIn
{
    public partial class CheckinForm : Form
    {
        public CheckinForm()
        {
            InitializeComponent();
            checkinButton.Click += async (s, e) => await HandleCheckinAsync();
            closeButton.Click += (s, e) => Close();
            resetTimer.Tick += ResetTimer_Tick;
        }

        private async Task HandleCheckinAsync()
        {
            var username = usernameTextBox.Text.Trim();
            if (string.IsNullOrEmpty(username))
            {
                ShowFeedback("Please enter student username or scan card.", isError: true);
                return;
            }

            checkinButton.Enabled = false;
            checkinButton.Text = "Checking in...";

            try
            {
                var checkIn = await CheckInService.Instance.CheckInAsync(username);
                var timeStr = checkIn.CheckedInAt.ToLocalTime().ToString("HH:mm:ss");
                ShowFeedback($"✓ Welcome, {checkIn.StudentName}!\nCheck-in recorded at {timeStr}.", isError: false);
                usernameTextBox.Clear();
            }
            catch (Exception ex)
            {
                ShowFeedback("✗ " + ex.Message, isError: true);
                usernameTextBox.SelectAll();
            }
            finally
            {
                checkinButton.Enabled = true;
                checkinButton.Text = "Record Check-In";
                usernameTextBox.Focus();
            }
        }

        private void ShowFeedback(string message, bool isError)
        {
            resetTimer.Stop();
            feedbackLabel.Text = message;
            if (isError)
            {
                feedbackPanel.FillColor = Color.FromArgb(254, 226, 226); // light red
                feedbackLabel.ForeColor = Color.FromArgb(153, 27, 27); // dark red
            }
            else
            {
                feedbackPanel.FillColor = Color.FromArgb(220, 252, 231); // light green
                feedbackLabel.ForeColor = Color.FromArgb(22, 101, 52); // dark green
            }

            feedbackPanel.Visible = true;
            resetTimer.Start();
        }

        private void ResetTimer_Tick(object? sender, EventArgs e)
        {
            resetTimer.Stop();
            feedbackPanel.Visible = false;
        }
    }
}
