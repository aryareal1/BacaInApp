using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using BacaIn.Models;
using BacaIn.Services;

namespace BacaIn.Controls
{
    public partial class CreateLoanDialog : Form
    {
        private readonly User _student;
        private List<Exemplar> _availableCopies = new List<Exemplar>();

        public CreateLoanDialog(User student)
        {
            InitializeComponent();
            _student = student;
            studentLabel.Text = $"Student: {_student.DisplayName ?? _student.Username} ({_student.Username})";

            searchTextBox.TextChanged += async (s, e) => await LoadCopiesAsync(searchTextBox.Text.Trim());
            issueButton.Click += async (s, e) => await HandleIssueAsync();
            cancelButton.Click += (s, e) => DialogResult = DialogResult.Cancel;

            Load += async (s, e) => await LoadCopiesAsync(null);
        }

        private async Task LoadCopiesAsync(string? keyword)
        {
            try
            {
                _availableCopies = await LoanService.Instance.GetAvailableExemplarsAsync(keyword);
                exemplarsGrid.Rows.Clear();
                foreach (var copy in _availableCopies)
                {
                    var idx = exemplarsGrid.Rows.Add(
                        copy.BookTitle ?? "—",
                        copy.BookAuthor ?? "—",
                        copy.Barcode,
                        copy.Condition
                    );
                    exemplarsGrid.Rows[idx].Tag = copy.Id;
                }

                if (_availableCopies.Count == 0)
                {
                    statusLabel.Text = "No available copies found.";
                    statusLabel.ForeColor = Color.FromArgb(102, 102, 102);
                    statusLabel.Visible = true;
                }
                else
                {
                    statusLabel.Visible = false;
                }
            }
            catch (Exception ex)
            {
                statusLabel.Text = "Error: " + ex.Message;
                statusLabel.ForeColor = Color.FromArgb(153, 27, 27);
                statusLabel.Visible = true;
            }
        }

        private async Task HandleIssueAsync()
        {
            if (exemplarsGrid.SelectedRows.Count == 0)
            {
                statusLabel.Text = "Please select an available book copy from the list.";
                statusLabel.ForeColor = Color.FromArgb(153, 27, 27);
                statusLabel.Visible = true;
                return;
            }

            var exemplarId = (Guid)exemplarsGrid.SelectedRows[0].Tag!;
            var selectedCopy = _availableCopies.Find(x => x.Id == exemplarId);

            issueButton.Enabled = false;
            issueButton.Text = "Issuing...";

            try
            {
                await LoanService.Instance.CreateLoanAsync(_student.Id, exemplarId, durationDays: 14);
                MessageBox.Show(this,
                    $"Loan successfully created for '{_student.DisplayName ?? _student.Username}'!\nBook: {selectedCopy?.BookTitle} ({selectedCopy?.Barcode})\nDue Date: {DateTime.Now.AddDays(14):dd MMM yyyy}",
                    "Loan Issued",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                statusLabel.Text = "Cannot issue loan: " + ex.Message;
                statusLabel.ForeColor = Color.FromArgb(153, 27, 27);
                statusLabel.Visible = true;
                issueButton.Enabled = true;
                issueButton.Text = "Issue Loan (14 Days)";
            }
        }
    }
}
