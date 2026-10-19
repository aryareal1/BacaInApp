using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using BacaIn.Models;
using BacaIn.Services;

namespace BacaIn
{
    public partial class CheckInHistoryPage : UserControl
    {
        private List<CheckIn> _history = new List<CheckIn>();

        public CheckInHistoryPage()
        {
            InitializeComponent();
            previewLabel.Visible = false;

            fromDatePicker.Value = DateTime.Now.AddDays(-30);
            toDatePicker.Value = DateTime.Now;

            applyButton.Click += async (s, e) => await LoadHistoryAsync();
            resetButton.Click += async (s, e) =>
            {
                fromDatePicker.Value = DateTime.Now.AddDays(-30);
                toDatePicker.Value = DateTime.Now;
                await LoadHistoryAsync();
            };

            Load += async (s, e) => await LoadHistoryAsync();
        }

        public async Task LoadHistoryAsync()
        {
            if (CurrentUser.Current == null) return;
            studentLabel.Text = $"Student: {CurrentUser.Current.DisplayName ?? CurrentUser.Current.Username}";

            var fromDate = fromDatePicker.Value.Date;
            var toDate = toDatePicker.Value.Date;

            try
            {
                _history = await CheckInService.Instance.GetHistoryAsync(CurrentUser.Current.Id, fromDate, toDate);
                summaryCountLabel.Text = $"Total visits: {_history.Count}";

                historyGrid.Rows.Clear();
                foreach (var item in _history)
                {
                    var local = item.CheckedInAt.ToLocalTime();
                    var dateStr = local.ToString("dd MMM yyyy");
                    var timeStr = local.ToString("HH:mm");
                    historyGrid.Rows.Add(dateStr, timeStr);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Failed to load check-in history: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
