using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using BacaIn.Controls;
using BacaIn.Models;
using BacaIn.Services;

namespace BacaIn
{
    public partial class StudentsPage : UserControl
    {
        public event EventHandler<Guid>? ManageLoansRequested;
        private List<User> _students = new List<User>();

        public StudentsPage()
        {
            InitializeComponent();
            previewLabel.Visible = false;

            searchTextBox.TextChanged += async (s, e) => await LoadStudentsAsync(searchTextBox.Text.Trim());
            addStudentButton.Click += async (s, e) => await HandleAddStudentAsync();
            studentsGrid.CellContentClick += async (s, e) => await HandleGridCellClickAsync(e);

            Load += async (s, e) => await LoadStudentsAsync(null);
        }

        public async Task LoadStudentsAsync(string? keyword)
        {
            try
            {
                _students = await AuthService.Instance.GetStudentsAsync(keyword);
                studentsGrid.Rows.Clear();

                foreach (var s in _students)
                {
                    var idx = studentsGrid.Rows.Add(
                        s.Username,
                        s.DisplayName ?? "—",
                        "Edit",
                        "Loans & Returns"
                    );
                    studentsGrid.Rows[idx].Tag = s;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Failed to load students: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task HandleAddStudentAsync()
        {
            using var dialog = new StudentEditDialog(null);
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                await LoadStudentsAsync(searchTextBox.Text.Trim());
            }
        }

        private async Task HandleGridCellClickAsync(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= studentsGrid.Rows.Count) return;
            var student = (User)studentsGrid.Rows[e.RowIndex].Tag!;

            if (e.ColumnIndex == editColumn.Index)
            {
                using var dialog = new StudentEditDialog(student);
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    await LoadStudentsAsync(searchTextBox.Text.Trim());
                }
            }
            else if (e.ColumnIndex == manageLoansReturnsColumn.Index)
            {
                ManageLoansRequested?.Invoke(this, student.Id);
            }
        }
    }
}
