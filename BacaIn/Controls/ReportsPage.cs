using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Threading.Tasks;
using System.Windows.Forms;
using BacaIn.Services;

namespace BacaIn
{
    public partial class ReportsPage : UserControl
    {
        private ReportData? _currentData;
        private int _printRowIndex = 0;

        public ReportsPage()
        {
            InitializeComponent();
            previewLabel.Visible = false;

            if (reportTypeComboBox.Items.Count == 0)
            {
                reportTypeComboBox.Items.AddRange(new object[]
                {
                    "Loans & Returns",
                    "Inventory",
                    "Reservations",
                    "Check-ins"
                });
                reportTypeComboBox.SelectedIndex = 0;
            }

            fromDatePicker.Value = DateTime.Now.AddDays(-30);
            toDatePicker.Value = DateTime.Now;

            applyButton.Click += async (s, e) => await LoadReportAsync();
            reportTypeComboBox.SelectedIndexChanged += async (s, e) => await LoadReportAsync();
            printButton.Click += HandlePrint;

            Load += async (s, e) => await LoadReportAsync();
        }

        public async Task LoadReportAsync()
        {
            var type = reportTypeComboBox.SelectedItem?.ToString() ?? "Loans & Returns";
            var from = fromDatePicker.Value.Date;
            var to = toDatePicker.Value.Date;

            try
            {
                _currentData = await ReportService.Instance.GetReportDataAsync(type, from, to);

                loansLabel.Text = _currentData.Card1Title;
                loansValueLabel.Text = _currentData.Card1Value;

                returnsLabel.Text = _currentData.Card2Title;
                returnsValueLabel.Text = _currentData.Card2Value;

                overdueLabel.Text = _currentData.Card3Title;
                overdueValueLabel.Text = _currentData.Card3Value;

                bookTitleColumn.HeaderText = _currentData.Column1Header;
                loansIssuedColumn.HeaderText = _currentData.Column2Header;
                returnsColumn.HeaderText = _currentData.Column3Header;

                reportGrid.Rows.Clear();
                foreach (var row in _currentData.Rows)
                {
                    reportGrid.Rows.Add(row.col1, row.col2, row.col3);
                }

                totalLabel.Text = _currentData.TotalLabel + ":";
                totalLoansLabel.Text = _currentData.TotalCol2;
                totalReturnsLabel.Text = _currentData.TotalCol3;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Failed to load report: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandlePrint(object? sender, EventArgs e)
        {
            if (_currentData == null) return;

            using var printDoc = new PrintDocument();
            printDoc.DocumentName = $"BacaIn_{_currentData.ReportType.Replace(" ", "_")}_Report";
            _printRowIndex = 0;

            printDoc.PrintPage += PrintDoc_PrintPage;

            using var previewDlg = new PrintPreviewDialog
            {
                Document = printDoc,
                Width = 900,
                Height = 700,
                StartPosition = FormStartPosition.CenterParent
            };

            previewDlg.ShowDialog(this);
        }

        private void PrintDoc_PrintPage(object? sender, PrintPageEventArgs e)
        {
            if (e.Graphics == null || _currentData == null) return;

            var g = e.Graphics;
            int margin = 50;
            int y = margin;
            int width = e.PageBounds.Width - (margin * 2);

            using var titleFont = new Font("Segoe UI", 18, FontStyle.Bold);
            using var subFont = new Font("Segoe UI", 10);
            using var headerFont = new Font("Segoe UI", 10, FontStyle.Bold);
            using var cellFont = new Font("Segoe UI", 9.5f);
            using var primaryBrush = new SolidBrush(Color.FromArgb(57, 112, 41));
            using var textBrush = new SolidBrush(Color.FromArgb(26, 26, 26));
            using var grayBrush = new SolidBrush(Color.FromArgb(102, 102, 102));
            using var linePen = new Pen(Color.FromArgb(204, 204, 204), 1);
            using var headerBgBrush = new SolidBrush(Color.FromArgb(242, 242, 242));

            // 1. Header (only on page 1)
            if (_printRowIndex == 0)
            {
                g.DrawString("BacaIn • School Library Report", titleFont, primaryBrush, margin, y);
                y += 36;

                var sub = $"Report Type: {_currentData.ReportType}   |   Period: {_currentData.FromDate:dd MMM yyyy} to {_currentData.ToDate:dd MMM yyyy}   |   Generated: {DateTime.Now:dd MMM yyyy HH:mm}";
                g.DrawString(sub, subFont, grayBrush, margin, y);
                y += 24;

                g.DrawLine(linePen, margin, y, margin + width, y);
                y += 14;

                // Summary Cards
                var summaryText = $"{_currentData.Card1Title}: {_currentData.Card1Value}      |      {_currentData.Card2Title}: {_currentData.Card2Value}      |      {_currentData.Card3Title}: {_currentData.Card3Value}";
                g.FillRectangle(headerBgBrush, margin, y, width, 32);
                g.DrawRectangle(linePen, margin, y, width, 32);
                g.DrawString(summaryText, headerFont, textBrush, margin + 12, y + 6);
                y += 46;
            }

            // 2. Table Column Headers
            int col1W = (int)(width * 0.55);
            int col2W = (int)(width * 0.22);
            int col3W = (int)(width * 0.23);

            g.FillRectangle(headerBgBrush, margin, y, width, 28);
            g.DrawRectangle(linePen, margin, y, width, 28);
            g.DrawString(_currentData.Column1Header, headerFont, textBrush, margin + 6, y + 4);
            g.DrawString(_currentData.Column2Header, headerFont, textBrush, margin + col1W + 6, y + 4);
            g.DrawString(_currentData.Column3Header, headerFont, textBrush, margin + col1W + col2W + 6, y + 4);
            y += 28;

            // 3. Table Rows
            int rowHeight = 24;
            while (_printRowIndex < _currentData.Rows.Count)
            {
                if (y + rowHeight + 60 > e.PageBounds.Height - margin)
                {
                    e.HasMorePages = true;
                    return;
                }

                var row = _currentData.Rows[_printRowIndex];
                g.DrawLine(linePen, margin, y + rowHeight, margin + width, y + rowHeight);

                g.DrawString(row.col1, cellFont, textBrush, new RectangleF(margin + 6, y + 3, col1W - 12, rowHeight));
                g.DrawString(row.col2, cellFont, textBrush, new RectangleF(margin + col1W + 6, y + 3, col2W - 12, rowHeight));
                g.DrawString(row.col3, cellFont, textBrush, new RectangleF(margin + col1W + col2W + 6, y + 3, col3W - 12, rowHeight));

                y += rowHeight;
                _printRowIndex++;
            }

            // 4. Totals Footer
            y += 10;
            g.DrawLine(new Pen(Color.FromArgb(57, 112, 41), 2), margin, y, margin + width, y);
            y += 6;
            g.DrawString(_currentData.TotalLabel, headerFont, primaryBrush, margin + 6, y);
            g.DrawString(_currentData.TotalCol2, headerFont, primaryBrush, margin + col1W + 6, y);
            g.DrawString(_currentData.TotalCol3, headerFont, primaryBrush, margin + col1W + col2W + 6, y);

            e.HasMorePages = false;
        }
    }
}
