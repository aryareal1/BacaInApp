using System.Drawing.Printing;
using BacaIn.Data;
using BacaIn.Models;
using Microsoft.EntityFrameworkCore;

namespace BacaIn.Controls;

public partial class ViewReports : UserControl
{
    private const string ReportLoansReturns = "Loans & Returns";
    private const string ReportInventory = "Inventory";
    private const string ReportReservations = "Reservations";
    private const string ReportCheckIns = "Check-ins";

    private int _printRowIndex;

    public ViewReports()
    {
        InitializeComponent();

        cmbReportType.Items.AddRange(new object[]
        {
            ReportLoansReturns,
            ReportInventory,
            ReportReservations,
            ReportCheckIns,
        });
        cmbReportType.SelectedIndex = 0;

        dtpFrom.Value = DateTime.Today.AddDays(-30);
        dtpTo.Value = DateTime.Today;

        cmbReportType.SelectedIndexChanged += (_, _) => LoadReport();
        btnApply.Click += (_, _) => LoadReport();
        btnPrint.Click += (_, _) => PrintReport();
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (DesignMode)
            return;

        LoadReport();
    }

    /// <summary>Generates the currently selected report for the active date range.</summary>
    public void LoadReport()
    {
        var reportType = cmbReportType.SelectedItem?.ToString() ?? ReportLoansReturns;
        var fromLocal = dtpFrom.Value.Date;
        var toLocal = dtpTo.Value.Date;
        if (toLocal < fromLocal)
        {
            (fromLocal, toLocal) = (toLocal, fromLocal);
            dtpFrom.Value = fromLocal;
            dtpTo.Value = toLocal;
        }

        var fromUtc = DateTime.SpecifyKind(fromLocal, DateTimeKind.Local).ToUniversalTime();
        var toExclusiveUtc = DateTime.SpecifyKind(toLocal.AddDays(1), DateTimeKind.Local).ToUniversalTime();

        var isDateFiltered = reportType != ReportInventory;
        dtpFrom.Enabled = isDateFiltered;
        dtpTo.Enabled = isDateFiltered;
        btnApply.Enabled = isDateFiltered;

        try
        {
            using var db = new AppDbContext();

            switch (reportType)
            {
                case ReportLoansReturns:
                    LoadLoansReturnsReport(db, fromUtc, toExclusiveUtc);
                    break;
                case ReportInventory:
                    LoadInventoryReport(db);
                    break;
                case ReportReservations:
                    LoadReservationsReport(db, fromUtc, toExclusiveUtc);
                    break;
                case ReportCheckIns:
                    LoadCheckInsReport(db, fromUtc, toExclusiveUtc);
                    break;
            }
        }
        catch (Exception ex)
        {
            dataGridView1.DataSource = null;
            MessageBox.Show($"Could not load report:\n{ex.Message}", "BacaIn",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void LoadLoansReturnsReport(AppDbContext db, DateTime fromUtc, DateTime toExclusiveUtc)
    {
        var now = DateTime.UtcNow;

        var issuedLoans = db.Loans.AsNoTracking()
            .Where(l => l.BorrowedAt >= fromUtc && l.BorrowedAt < toExclusiveUtc)
            .Select(l => new { l.Exemplar.BibliographyId, l.Exemplar.Bibliography.Title })
            .ToList();

        var returnedLoans = db.Loans.AsNoTracking()
            .Where(l => l.ReturnedAt != null && l.ReturnedAt >= fromUtc && l.ReturnedAt < toExclusiveUtc)
            .Select(l => new { l.Exemplar.BibliographyId, l.Exemplar.Bibliography.Title })
            .ToList();

        var overdueNow = db.Loans.AsNoTracking()
            .Count(l => l.Status == LoanStatus.Active && l.DueAt < now);

        SetCards(
            "Loans issued", issuedLoans.Count.ToString(),
            "Returns", returnedLoans.Count.ToString(),
            "Overdue now", overdueNow.ToString());

        var rows = issuedLoans
            .Select(x => new { x.BibliographyId, x.Title, Issued = 1, Returned = 0 })
            .Concat(returnedLoans.Select(x => new { x.BibliographyId, x.Title, Issued = 0, Returned = 1 }))
            .GroupBy(x => new { x.BibliographyId, x.Title })
            .OrderByDescending(g => g.Sum(x => x.Issued))
            .ThenBy(g => g.Key.Title)
            .Select(g => new LoansReportRow
            {
                BookTitle = g.Key.Title,
                LoansIssued = g.Sum(x => x.Issued),
                Returns = g.Sum(x => x.Returned),
            })
            .ToList();

        if (rows.Count > 0)
        {
            rows.Add(new LoansReportRow
            {
                BookTitle = "Total",
                LoansIssued = issuedLoans.Count,
                Returns = returnedLoans.Count,
            });
        }

        dataGridView1.DataSource = rows;
    }

    private void LoadInventoryReport(AppDbContext db)
    {
        var books = db.Bibliographies.AsNoTracking()
            .OrderBy(b => b.Title)
            .Select(b => new InventoryReportRow
            {
                Title = b.Title,
                Author = b.Author,
                TotalCopies = b.Exemplars.Count,
                Available = b.Exemplars.Count(e => e.Status == ExemplarStatus.Available),
                Borrowed = b.Exemplars.Count(e => e.Status == ExemplarStatus.Borrowed),
                DamagedOrLost = b.Exemplars.Count(e => e.Status == ExemplarStatus.Damaged || e.Status == ExemplarStatus.Lost),
            })
            .ToList();

        SetCards(
            "Total titles", books.Count.ToString(),
            "Total copies", books.Sum(b => b.TotalCopies).ToString(),
            "Available now", books.Sum(b => b.Available).ToString());

        dataGridView1.DataSource = books;
    }

    private void LoadReservationsReport(AppDbContext db, DateTime fromUtc, DateTime toExclusiveUtc)
    {
        var reservations = db.Reservations.AsNoTracking()
            .Where(r => r.ReservedAt >= fromUtc && r.ReservedAt < toExclusiveUtc)
            .Select(r => new { r.BibliographyId, r.Bibliography.Title, r.Status })
            .ToList();

        var pendingOrReady = reservations.Count(r => r.Status is ReservationStatus.Pending or ReservationStatus.Ready);
        var fulfilled = reservations.Count(r => r.Status == ReservationStatus.Fulfilled);

        SetCards(
            "Reservations", reservations.Count.ToString(),
            "Pending / Ready", pendingOrReady.ToString(),
            "Fulfilled", fulfilled.ToString());

        var rows = reservations
            .GroupBy(r => new { r.BibliographyId, r.Title })
            .OrderByDescending(g => g.Count())
            .ThenBy(g => g.Key.Title)
            .Select(g => new ReservationReportRow
            {
                BookTitle = g.Key.Title,
                Pending = g.Count(x => x.Status == ReservationStatus.Pending),
                Ready = g.Count(x => x.Status == ReservationStatus.Ready),
                Fulfilled = g.Count(x => x.Status == ReservationStatus.Fulfilled),
                CancelledOrExpired = g.Count(x => x.Status is ReservationStatus.Cancelled or ReservationStatus.Expired),
            })
            .ToList();

        dataGridView1.DataSource = rows;
    }

    private void LoadCheckInsReport(AppDbContext db, DateTime fromUtc, DateTime toExclusiveUtc)
    {
        var todayStartUtc = DateTime.SpecifyKind(DateTime.Today, DateTimeKind.Local).ToUniversalTime();
        var todayEndUtc = DateTime.SpecifyKind(DateTime.Today.AddDays(1), DateTimeKind.Local).ToUniversalTime();

        var checkIns = db.CheckIns.AsNoTracking()
            .Where(c => c.CheckedInAt >= fromUtc && c.CheckedInAt < toExclusiveUtc)
            .OrderByDescending(c => c.CheckedInAt)
            .Select(c => new
            {
                c.StudentId,
                StudentName = c.Student.DisplayName ?? c.Student.Username,
                c.Student.Username,
                c.CheckedInAt,
            })
            .ToList();

        var todayCount = db.CheckIns.AsNoTracking()
            .Count(c => c.CheckedInAt >= todayStartUtc && c.CheckedInAt < todayEndUtc);

        SetCards(
            "Total check-ins", checkIns.Count.ToString(),
            "Unique students", checkIns.Select(c => c.StudentId).Distinct().Count().ToString(),
            "Today", todayCount.ToString());

        var rows = checkIns.Select(c =>
        {
            var local = c.CheckedInAt.ToLocalTime();
            return new CheckInReportRow
            {
                Date = local.ToString("yyyy-MM-dd"),
                Time = local.ToString("HH:mm"),
                Student = c.StudentName,
                Username = "@" + c.Username,
            };
        }).ToList();

        dataGridView1.DataSource = rows;
    }

    private void SetCards(string title1, string val1, string title2, string val2, string title3, string val3)
    {
        lblCard1Title.Text = title1;
        lblCard1Value.Text = val1;
        lblCard2Title.Text = title2;
        lblCard2Value.Text = val2;
        lblCard3Title.Text = title3;
        lblCard3Value.Text = val3;
    }

    private void PrintReport()
    {
        if (dataGridView1.Rows.Count == 0)
        {
            MessageBox.Show("There is no report data to print.", "View Reports",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        _printRowIndex = 0;

        using var doc = new PrintDocument();
        doc.DocumentName = $"BacaIn - {cmbReportType.SelectedItem}";
        doc.PrintPage += PrintDocument_PrintPage;

        using var preview = new PrintPreviewDialog
        {
            Document = doc,
            Width = 900,
            Height = 650,
        };
        preview.ShowDialog(FindForm());
    }

    private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
    {
        if (e.Graphics is null)
            return;

        var g = e.Graphics;
        var left = e.MarginBounds.Left;
        var top = e.MarginBounds.Top;
        var width = e.MarginBounds.Width;

        using var titleFont = new Font("Segoe UI", 14F, FontStyle.Bold);
        using var subFont = new Font("Segoe UI", 9.5F);
        using var headerFont = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        using var cellFont = new Font("Segoe UI", 9F);

        var y = (float)top;

        if (_printRowIndex == 0)
        {
            var reportType = cmbReportType.SelectedItem?.ToString() ?? ReportLoansReturns;
            g.DrawString($"BacaIn Library Report — {reportType}", titleFont, Brushes.Black, left, y);
            y += 28;

            var period = reportType == ReportInventory
                ? $"Generated: {DateTime.Now:yyyy-MM-dd HH:mm}"
                : $"Period: {dtpFrom.Value:yyyy-MM-dd} to {dtpTo.Value:yyyy-MM-dd}   |   Generated: {DateTime.Now:yyyy-MM-dd HH:mm}";
            g.DrawString(period, subFont, Brushes.DimGray, left, y);
            y += 22;

            var summary = $"{lblCard1Title.Text}: {lblCard1Value.Text}    |    {lblCard2Title.Text}: {lblCard2Value.Text}    |    {lblCard3Title.Text}: {lblCard3Value.Text}";
            g.DrawString(summary, headerFont, Brushes.Black, left, y);
            y += 28;
        }

        var visibleCols = dataGridView1.Columns.Cast<DataGridViewColumn>().Where(c => c.Visible).ToList();
        if (visibleCols.Count == 0)
            return;

        var colWidth = (float)width / visibleCols.Count;
        const float rowHeight = 24f;

        // Table header
        g.FillRectangle(Brushes.WhiteSmoke, left, y, width, rowHeight);
        for (var i = 0; i < visibleCols.Count; i++)
            g.DrawString(visibleCols[i].HeaderText, headerFont, Brushes.Black, new RectangleF(left + i * colWidth + 4, y + 4, colWidth - 8, rowHeight));
        g.DrawLine(Pens.Gray, left, y + rowHeight, left + width, y + rowHeight);
        y += rowHeight;

        while (_printRowIndex < dataGridView1.Rows.Count)
        {
            if (y + rowHeight > e.MarginBounds.Bottom)
            {
                e.HasMorePages = true;
                return;
            }

            var row = dataGridView1.Rows[_printRowIndex];
            for (var i = 0; i < visibleCols.Count; i++)
            {
                var val = row.Cells[visibleCols[i].Index].Value?.ToString() ?? "";
                g.DrawString(val, cellFont, Brushes.Black, new RectangleF(left + i * colWidth + 4, y + 4, colWidth - 8, rowHeight));
            }
            g.DrawLine(Pens.LightGray, left, y + rowHeight, left + width, y + rowHeight);
            y += rowHeight;
            _printRowIndex++;
        }

        e.HasMorePages = false;
    }

    private sealed class LoansReportRow
    {
        public string BookTitle { get; set; } = "";
        public int LoansIssued { get; set; }
        public int Returns { get; set; }
    }

    private sealed class InventoryReportRow
    {
        public string Title { get; set; } = "";
        public string Author { get; set; } = "";
        public int TotalCopies { get; set; }
        public int Available { get; set; }
        public int Borrowed { get; set; }
        public int DamagedOrLost { get; set; }
    }

    private sealed class ReservationReportRow
    {
        public string BookTitle { get; set; } = "";
        public int Pending { get; set; }
        public int Ready { get; set; }
        public int Fulfilled { get; set; }
        public int CancelledOrExpired { get; set; }
    }

    private sealed class CheckInReportRow
    {
        public string Date { get; set; } = "";
        public string Time { get; set; } = "";
        public string Student { get; set; } = "";
        public string Username { get; set; } = "";
    }
}
