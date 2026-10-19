using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using BacaIn.Controls;
using BacaIn.Models;
using BacaIn.Services;

namespace BacaIn
{
    public partial class LoansReturnsPage : UserControl
    {
        private List<User> _students = new List<User>();
        private User? _selectedStudent;
        private List<Loan> _loans = new List<Loan>();

        public LoansReturnsPage()
        {
            InitializeComponent();
            studentsPreviewLabel.Visible = false;
            loansPreviewLabel.Visible = false;

            studentSearchTextBox.TextChanged += async (s, e) => await LoadStudentsAsync(studentSearchTextBox.Text.Trim());
            studentsGrid.CellContentClick += async (s, e) => await HandleStudentSelectClickAsync(e);
            studentsGrid.SelectionChanged += async (s, e) => await HandleStudentSelectionChangedAsync();

            loanSearchTextBox.TextChanged += (s, e) => FilterLoans();
            createLoanButton.Click += async (s, e) => await HandleCreateLoanAsync();
            loansGrid.CellContentClick += async (s, e) => await HandleLoanReturnClickAsync(e);

            Load += async (s, e) => await LoadStudentsAsync(null);
        }

        public async Task LoadStudentsAsync(string? keyword)
        {
            try
            {
                _students = await LoanService.Instance.GetActiveStudentsAsync(keyword);
                studentsGrid.Rows.Clear();

                foreach (var s in _students)
                {
                    var idx = studentsGrid.Rows.Add(s.Username, s.DisplayName ?? "—", "Select");
                    studentsGrid.Rows[idx].Tag = s;
                }

                if (_students.Count > 0 && _selectedStudent == null)
                {
                    await SetSelectedStudentAsync(_students[0]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Failed to load students: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task SelectStudentByIdAsync(Guid studentId)
        {
            await LoadStudentsAsync(null);
            var student = _students.Find(x => x.Id == studentId);
            if (student != null)
            {
                await SetSelectedStudentAsync(student);
            }
        }

        private async Task HandleStudentSelectClickAsync(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= studentsGrid.Rows.Count) return;
            var student = (User)studentsGrid.Rows[e.RowIndex].Tag!;
            await SetSelectedStudentAsync(student);
        }

        private async Task HandleStudentSelectionChangedAsync()
        {
            if (studentsGrid.SelectedRows.Count == 0) return;
            var student = (User)studentsGrid.SelectedRows[0].Tag!;
            if (_selectedStudent?.Id != student.Id)
            {
                await SetSelectedStudentAsync(student);
            }
        }

        private async Task SetSelectedStudentAsync(User student)
        {
            _selectedStudent = student;
            studentContextLabel.Text = $"Student: {_selectedStudent.DisplayName ?? _selectedStudent.Username} ({_selectedStudent.Username})";
            await LoadLoansForStudentAsync();
        }

        private async Task LoadLoansForStudentAsync()
        {
            if (_selectedStudent == null) return;
            try
            {
                _loans = await LoanService.Instance.GetLoansForStudentAsync(_selectedStudent.Id);
                FilterLoans();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Failed to load student loans: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterLoans()
        {
            var kw = loanSearchTextBox.Text.Trim().ToLowerInvariant();
            loansGrid.Rows.Clear();

            foreach (var loan in _loans)
            {
                if (!string.IsNullOrEmpty(kw))
                {
                    var titleMatch = (loan.BookTitle ?? "").ToLowerInvariant().Contains(kw);
                    var authorMatch = (loan.Author ?? "").ToLowerInvariant().Contains(kw);
                    var barcodeMatch = (loan.Barcode ?? "").ToLowerInvariant().Contains(kw);
                    if (!titleMatch && !authorMatch && !barcodeMatch) continue;
                }

                string statusText;
                if (loan.Status == "RETURNED")
                {
                    statusText = "Returned";
                }
                else if (loan.IsOverdue)
                {
                    statusText = $"Overdue ({loan.DaysOverdue}d)";
                }
                else
                {
                    statusText = "Active";
                }

                var actionText = loan.Status == "ACTIVATE" ? "Return" : "—";
                var idx = loansGrid.Rows.Add(
                    loan.BookTitle ?? "—",
                    loan.Author ?? "—",
                    loan.Barcode ?? "—",
                    statusText,
                    actionText
                );
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

        private async Task HandleCreateLoanAsync()
        {
            if (_selectedStudent == null)
            {
                MessageBox.Show(this, "Please select a student first.", "No Student Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var hasOverdue = await LoanService.Instance.HasOverdueLoansAsync(_selectedStudent.Id);
            if (hasOverdue)
            {
                MessageBox.Show(this,
                    $"Cannot issue new loans!\nStudent '{_selectedStudent.DisplayName ?? _selectedStudent.Username}' currently has overdue books.\nOverdue books must be returned and fines resolved first.",
                    "Overdue Loan Block",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            using var dialog = new CreateLoanDialog(_selectedStudent);
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                await LoadLoansForStudentAsync();
            }
        }

        private async Task HandleLoanReturnClickAsync(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= loansGrid.Rows.Count) return;
            if (e.ColumnIndex != returnColumn.Index) return;

            var loan = (Loan)loansGrid.Rows[e.RowIndex].Tag!;
            if (loan.Status == "RETURNED") return;

            string confirmMsg;
            if (loan.IsOverdue)
            {
                confirmMsg = $"Book: {loan.BookTitle} ({loan.Barcode})\n" +
                             $"Borrowed: {loan.BorrowedAt.ToLocalTime():dd MMM yyyy}\n" +
                             $"Due Date: {loan.DueAt.ToLocalTime():dd MMM yyyy}\n\n" +
                             $"⚠ Book is {loan.DaysOverdue} day(s) overdue!\n" +
                             $"Calculated Late Fine: Rp {loan.FineAmount:N0} (Rp 1.000/day)\n\n" +
                             $"Confirm book return and fine collection?";
            }
            else
            {
                confirmMsg = $"Confirm return for '{loan.BookTitle}' ({loan.Barcode})?";
            }

            var confirm = MessageBox.Show(this, confirmMsg, "Process Book Return", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    var result = await LoanService.Instance.ReturnLoanAsync(loan.Id);
                    if (result.isLate)
                    {
                        MessageBox.Show(this,
                            $"Book successfully returned!\nCollected Fine: Rp {result.fineAmount:N0}.",
                            "Return Complete",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(this,
                            "Book successfully returned on time. Thank you!",
                            "Return Complete",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }

                    await LoadLoansForStudentAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Error processing return: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
