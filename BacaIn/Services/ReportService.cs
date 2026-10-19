using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BacaIn.Data;
using Npgsql;

namespace BacaIn.Services
{
    public class ReportData
    {
        public string ReportType { get; set; } = "Loans & Returns";
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public string Card1Title { get; set; } = "";
        public string Card1Value { get; set; } = "";
        public string Card2Title { get; set; } = "";
        public string Card2Value { get; set; } = "";
        public string Card3Title { get; set; } = "";
        public string Card3Value { get; set; } = "";

        public string Column1Header { get; set; } = "Book title";
        public string Column2Header { get; set; } = "Loans issued";
        public string Column3Header { get; set; } = "Returns";

        public List<(string col1, string col2, string col3)> Rows { get; set; } = new();

        public string TotalLabel { get; set; } = "Total";
        public string TotalCol2 { get; set; } = "0";
        public string TotalCol3 { get; set; } = "0";
    }

    public class ReportService
    {
        private static ReportService? _instance;
        public static ReportService Instance => _instance ??= new ReportService();

        public async Task<ReportData> GetReportDataAsync(string reportType, DateTime fromDate, DateTime toDate)
        {
            var data = new ReportData
            {
                ReportType = reportType,
                FromDate = fromDate.Date,
                ToDate = toDate.Date
            };

            var startUtc = DateTime.SpecifyKind(fromDate.Date, DateTimeKind.Utc);
            var endUtc = DateTime.SpecifyKind(toDate.Date.AddDays(1).AddTicks(-1), DateTimeKind.Utc);

            await using var conn = DatabaseContext.Instance.CreateConnection();
            await conn.OpenAsync();

            if (reportType.Contains("Inventory", StringComparison.OrdinalIgnoreCase))
            {
                // INVENTORY REPORT
                data.Card1Title = "Total titles";
                data.Card2Title = "Total copies";
                data.Card3Title = "Available now";
                data.Column1Header = "Book title";
                data.Column2Header = "Total copies";
                data.Column3Header = "Available";

                const string sql = @"
                    SELECT b.title,
                           COUNT(e.id) as total_copies,
                           COUNT(CASE WHEN e.status = 'AVAILABLE' AND e.deleted_at IS NULL THEN 1 END) as avail_copies
                    FROM bibliographies b
                    LEFT JOIN exemplars e ON b.id = e.bibliography_id AND e.deleted_at IS NULL
                    WHERE b.deleted_at IS NULL
                    GROUP BY b.id, b.title
                    ORDER BY b.title ASC;
                ";

                long totalCopiesSum = 0;
                long totalAvailSum = 0;

                await using (var cmd = new NpgsqlCommand(sql, conn))
                await using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var title = reader.GetString(0);
                        var tot = reader.GetInt64(1);
                        var av = reader.GetInt64(2);
                        totalCopiesSum += tot;
                        totalAvailSum += av;
                        data.Rows.Add((title, tot.ToString(), av.ToString()));
                    }
                }

                data.Card1Value = data.Rows.Count.ToString();
                data.Card2Value = totalCopiesSum.ToString();
                data.Card3Value = totalAvailSum.ToString();
                data.TotalCol2 = totalCopiesSum.ToString();
                data.TotalCol3 = totalAvailSum.ToString();
            }
            else if (reportType.Contains("Reservations", StringComparison.OrdinalIgnoreCase))
            {
                // RESERVATIONS REPORT
                data.Card1Title = "Pending";
                data.Card2Title = "Ready";
                data.Card3Title = "Fulfilled/Cancelled";
                data.Column1Header = "Book title";
                data.Column2Header = "Student";
                data.Column3Header = "Status";

                const string sql = @"
                    SELECT b.title, COALESCE(u.display_name, u.username), r.status
                    FROM reservations r
                    JOIN bibliographies b ON r.bibliography_id = b.id
                    JOIN users u ON r.student_id = u.id
                    WHERE r.reserved_at >= @startUtc AND r.reserved_at <= @endUtc
                    ORDER BY r.reserved_at DESC;
                ";

                int pending = 0;
                int ready = 0;
                int other = 0;

                await using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("startUtc", startUtc);
                    cmd.Parameters.AddWithValue("endUtc", endUtc);
                    await using var reader = await cmd.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        var title = reader.GetString(0);
                        var student = reader.GetString(1);
                        var status = reader.GetString(2);

                        if (status == "PENDING") pending++;
                        else if (status == "READY") ready++;
                        else other++;

                        data.Rows.Add((title, student, status));
                    }
                }

                data.Card1Value = pending.ToString();
                data.Card2Value = ready.ToString();
                data.Card3Value = other.ToString();
                data.TotalLabel = "Total reservations";
                data.TotalCol2 = data.Rows.Count.ToString();
                data.TotalCol3 = $"Ready: {ready}";
            }
            else if (reportType.Contains("Check-ins", StringComparison.OrdinalIgnoreCase))
            {
                // CHECK-INS REPORT
                data.Card1Title = "Total visits";
                data.Card2Title = "Unique students";
                data.Card3Title = "Active days";
                data.Column1Header = "Student";
                data.Column2Header = "Date";
                data.Column3Header = "Check-in Time";

                const string sql = @"
                    SELECT COALESCE(u.display_name, u.username), c.checked_in_at
                    FROM check_ins c
                    JOIN users u ON c.student_id = u.id
                    WHERE c.checked_in_at >= @startUtc AND c.checked_in_at <= @endUtc
                    ORDER BY c.checked_in_at DESC;
                ";

                var uniqueStudents = new HashSet<string>();
                var activeDays = new HashSet<string>();

                await using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("startUtc", startUtc);
                    cmd.Parameters.AddWithValue("endUtc", endUtc);
                    await using var reader = await cmd.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        var student = reader.GetString(0);
                        var time = reader.GetDateTime(1).ToLocalTime();

                        uniqueStudents.Add(student);
                        activeDays.Add(time.ToString("yyyy-MM-dd"));

                        data.Rows.Add((student, time.ToString("dd MMM yyyy"), time.ToString("HH:mm:ss")));
                    }
                }

                data.Card1Value = data.Rows.Count.ToString();
                data.Card2Value = uniqueStudents.Count.ToString();
                data.Card3Value = activeDays.Count.ToString();
                data.TotalLabel = "Total visits in period";
                data.TotalCol2 = data.Rows.Count.ToString();
                data.TotalCol3 = $"Students: {uniqueStudents.Count}";
            }
            else
            {
                // DEFAULT: LOANS & RETURNS
                data.ReportType = "Loans & Returns";
                data.Card1Title = "Loans issued";
                data.Card2Title = "Returns";
                data.Card3Title = "Overdue now";
                data.Column1Header = "Book title";
                data.Column2Header = "Loans issued";
                data.Column3Header = "Returns";

                // Count active overdue right now
                await using (var overdueCmd = new NpgsqlCommand("SELECT COUNT(*) FROM loans WHERE status = 'ACTIVATE' AND due_at < NOW();", conn))
                {
                    data.Card3Value = (await overdueCmd.ExecuteScalarAsync())?.ToString() ?? "0";
                }

                const string sql = @"
                    SELECT b.title,
                           COUNT(CASE WHEN l.borrowed_at >= @startUtc AND l.borrowed_at <= @endUtc THEN 1 END) as issued,
                           COUNT(CASE WHEN l.returned_at >= @startUtc AND l.returned_at <= @endUtc THEN 1 END) as returned
                    FROM bibliographies b
                    LEFT JOIN exemplars e ON b.id = e.bibliography_id
                    LEFT JOIN loans l ON e.id = l.exemplar_id
                    WHERE b.deleted_at IS NULL
                    GROUP BY b.id, b.title
                    HAVING COUNT(CASE WHEN l.borrowed_at >= @startUtc AND l.borrowed_at <= @endUtc THEN 1 END) > 0
                        OR COUNT(CASE WHEN l.returned_at >= @startUtc AND l.returned_at <= @endUtc THEN 1 END) > 0
                    ORDER BY issued DESC, b.title ASC;
                ";

                long totalIssued = 0;
                long totalReturns = 0;

                await using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("startUtc", startUtc);
                    cmd.Parameters.AddWithValue("endUtc", endUtc);
                    await using var reader = await cmd.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        var title = reader.GetString(0);
                        var issued = reader.GetInt64(1);
                        var returned = reader.GetInt64(2);

                        totalIssued += issued;
                        totalReturns += returned;

                        data.Rows.Add((title, issued.ToString(), returned.ToString()));
                    }
                }

                data.Card1Value = totalIssued.ToString();
                data.Card2Value = totalReturns.ToString();
                data.TotalCol2 = totalIssued.ToString();
                data.TotalCol3 = totalReturns.ToString();
            }

            return data;
        }
    }
}
