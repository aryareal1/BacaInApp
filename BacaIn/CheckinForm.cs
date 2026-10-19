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
            KeyPreview = true;
            checkinButton.Click += async (s, e) => await HandleCheckinAsync();
            resetTimer.Tick += ResetTimer_Tick;
            KeyDown += CheckinForm_KeyDown;
        }

        private bool _isFullScreen = false;
        private FormBorderStyle _prevBorderStyle = FormBorderStyle.Sizable;
        private FormWindowState _prevWindowState = FormWindowState.Normal;

        private void CheckinForm_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F11)
            {
                e.SuppressKeyPress = true;
                ToggleFullScreen();
            }
            else if (e.KeyCode == Keys.Escape && _isFullScreen)
            {
                e.SuppressKeyPress = true;
                ToggleFullScreen();
            }
        }

        public void ToggleFullScreen()
        {
            if (!_isFullScreen)
            {
                _prevBorderStyle = FormBorderStyle;
                _prevWindowState = WindowState;
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
                _isFullScreen = true;
            }
            else
            {
                FormBorderStyle = _prevBorderStyle;
                WindowState = _prevWindowState;
                _isFullScreen = false;
            }
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
