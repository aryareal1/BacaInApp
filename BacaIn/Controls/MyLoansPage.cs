using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using BacaIn.Models;
using BacaIn.Services;

namespace BacaIn
{
    public partial class MyLoansPage : UserControl
    {
        private List<Loan> _loans = new List<Loan>();

        public MyLoansPage()
        {
            InitializeComponent();
            previewLabel.Visible = false;

            statusComboBox.SelectedIndexChanged += async (s, e) => await LoadLoansAsync();
            Load += async (s, e) => await LoadLoansAsync();
        }

        public async Task LoadLoansAsync()
        {
            if (CurrentUser.Current == null) return;
            studentLabel.Text = $"Student: {CurrentUser.Current.DisplayName ?? CurrentUser.Current.Username}";

            var filter = statusComboBox.SelectedItem?.ToString() ?? "All";
            if (filter.StartsWith("Status: ")) filter = filter.Replace("Status: ", "").Trim();

            try
            {
                var allLoans = await LoanService.Instance.GetLoansForStudentAsync(CurrentUser.Current.Id, null);
                var activeCount = allLoans.FindAll(x => x.Status == "ACTIVATE" && !x.IsOverdue).Count;
                var overdueCount = allLoans.FindAll(x => x.IsOverdue).Count;
                var returnedCount = allLoans.FindAll(x => x.Status == "RETURNED").Count;

                activeCountLabel.Text = $"Active: {activeCount}";
                overdueCountLabel.Text = $"Overdue: {overdueCount}";
                returnedCountLabel.Text = $"Returned: {returnedCount}";

                _loans = await LoanService.Instance.GetLoansForStudentAsync(CurrentUser.Current.Id, filter);
                loansGrid.Rows.Clear();

                foreach (var loan in _loans)
                {
                    var bookCopy = $"{loan.BookTitle ?? "—"} / {loan.Barcode ?? "—"}";
                    var borrowedStr = loan.BorrowedAt.ToLocalTime().ToString("dd MMM yyyy");
                    var dueStr = loan.DueAt.ToLocalTime().ToString("dd MMM yyyy");
                    var returnedStr = loan.ReturnedAt.HasValue ? loan.ReturnedAt.Value.ToLocalTime().ToString("dd MMM yyyy") : "—";

                    string statusStr;
                    if (loan.Status == "RETURNED") statusStr = "Returned";
                    else if (loan.IsOverdue) statusStr = "Overdue";
                    else statusStr = "Active";

                    var idx = loansGrid.Rows.Add(bookCopy, borrowedStr, dueStr, returnedStr, statusStr);
                    loansGrid.Rows[idx].Tag = loan;

                    if (loan.IsOverdue)
                    {
                        loansGrid.Rows[idx].Cells[statusColumn.Index].Style.ForeColor = Color.FromArgb(153, 27, 27);
                        loansGrid.Rows[idx].Cells[statusColumn.Index].Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                    }
                    else if (loan.Status == "ACTIVATE")
                    {
                        loansGrid.Rows[idx].Cells[statusColumn.Index].Style.ForeColor = Color.FromArgb(30, 64, 175);
                    }
                    else
                    {
                        loansGrid.Rows[idx].Cells[statusColumn.Index].Style.ForeColor = Color.FromArgb(22, 101, 52);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Failed to load loans: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
