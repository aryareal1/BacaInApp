using BacaIn.Models;
using System.Security.Cryptography;

namespace BacaIn.Data;

/// <summary>Fills the catalog with deterministic sample data for development and demos.</summary>
/// <remarks>Idempotent: does nothing when any user already exists. Run with <c>dotnet run -- --seed</c>.</remarks>
internal static class DatabaseSeeder
{
    private const int HashIterations = 210_000;

    /// <summary>Inserts sample users, bibliographies, exemplars, loans, reservations and check-ins.</summary>
    public static void Seed(AppDbContext db)
    {
        if (db.Users.Any())
            return; // ponytail: all-or-nothing sample seed; add per-table guards if partial data must be topped up.

        var admin = CreateUser("admin", "admin123", "Administrator", UserRole.Admin);
        var students = new[]
        {
            CreateUser("budi", "password123", "Budi Santoso", UserRole.Student),
            CreateUser("siti", "password123", "Siti Rahmawati", UserRole.Student),
            CreateUser("andi", "password123", "Andi Pratama", UserRole.Student),
            CreateUser("dewi", "password123", "Dewi Lestari", UserRole.Student),
            CreateUser("rizky", "password123", "Rizky Hidayat", UserRole.Student),
            CreateUser("putri", "password123", "Putri Maharani", UserRole.Student),
        };
        db.Users.Add(admin);
        db.Users.AddRange(students);

        var books = new List<Bibliography>
        {
            new() { Title = "Laskar Pelangi", Author = "Andrea Hirata", Publisher = "Bentang Pustaka", PublisherYear = 2005, Isbn = "9789793062792", Description = "Sepuluh anak Belitung berjuang menempuh pendidikan di sekolah Muhammadiyah yang hampir runtuh." },
            new() { Title = "Bumi Manusia", Author = "Pramoedya Ananta Toer", Publisher = "Hasta Mitra", PublisherYear = 1980, Isbn = "9789799731234", Description = "Kisah Minke di akhir masa kolonial Hindia Belanda." },
            new() { Title = "Cantik Itu Luka", Author = "Eka Kurniawan", Publisher = "Gramedia Pustaka Utama", PublisherYear = 2002, Isbn = "9786020360945", Description = "Saga keluarga Halimunda yang magis dan gelap." },
            new() { Title = "Perahu Kertas", Author = "Dee Lestari", Publisher = "Bentang Pustaka", PublisherYear = 2009, Isbn = "9789791227859", Description = "Dua anak muda mencari arah hidup dan cinta." },
            new() { Title = "Negeri 5 Menara", Author = "Ahmad Fuadi", Publisher = "Gramedia Pustaka Utama", PublisherYear = 2009, Isbn = "9789792248595", Description = "Enam santri di pondok Madani dan mantra 'man jadda wajada'." },
            new() { Title = "Pulang", Author = "Leila S. Chudori", Publisher = "Kepik", PublisherYear = 2012, Isbn = "9786029194626", Description = "Eksil politik 1965 dan rindu yang tak pernah pulang." },
            new() { Title = "Filosofi Teras", Author = "Henry Manampiring", Publisher = "Kompas", PublisherYear = 2018, Isbn = "9786024125189", Description = "Pengantar Stoisisme untuk kehidupan sehari-hari." },
            new() { Title = "Hujan", Author = "Tere Liye", Publisher = "Gramedia Pustaka Utama", PublisherYear = 2016, Isbn = "9786020821934", Description = "Sahabat, bencana, dan kota yang dibangun kembali." },
        };
        db.Bibliographies.AddRange(books);

        var exemplars = new List<Exemplar>();
        var copiesPerBook = new[] { 3, 2, 2, 3, 2, 2, 3, 2 };
        var barcodeSeq = 0;
        for (var i = 0; i < books.Count; i++)
        {
            for (var copy = 0; copy < copiesPerBook[i]; copy++)
            {
                exemplars.Add(new Exemplar
                {
                    Bibliography = books[i],
                    Barcode = $"BC-{++barcodeSeq:0000}",
                    Condition = copy == 0 ? ExemplarCondition.New : ExemplarCondition.Good,
                });
            }
        }
        exemplars[5].Condition = ExemplarCondition.Fair;
        exemplars[5].Status = ExemplarStatus.Damaged;
        exemplars[15].Condition = ExemplarCondition.Poor;
        db.Exemplars.AddRange(exemplars);

        var now = DateTime.UtcNow;
        db.Loans.AddRange(
            Active(exemplars[0], students[0], borrowedDaysAgo: 3),
            Active(exemplars[4], students[1], borrowedDaysAgo: 20),   // overdue
            Active(exemplars[8], students[2], borrowedDaysAgo: 1),
            Active(exemplars[13], students[0], borrowedDaysAgo: 6),
            Returned(exemplars[2], students[3], borrowedDaysAgo: 30, returnedDaysAgo: 20),
            Returned(exemplars[6], students[4], borrowedDaysAgo: 25, returnedDaysAgo: 15),
            Returned(exemplars[10], students[5], borrowedDaysAgo: 40, returnedDaysAgo: 33));

        db.Reservations.AddRange(
            new Reservation { Student = students[1], Bibliography = books[1], ReservedAt = now.AddDays(-2), Status = ReservationStatus.Pending, QueuePosition = 1 },
            new Reservation { Student = students[2], Bibliography = books[0], ReservedAt = now.AddDays(-1), Status = ReservationStatus.Ready, QueuePosition = 1 },
            new Reservation { Student = students[3], Bibliography = books[3], ReservedAt = now.AddDays(-4), Status = ReservationStatus.Pending, QueuePosition = 2 },
            new Reservation { Student = students[4], Bibliography = books[4], ReservedAt = now.AddDays(-9), Status = ReservationStatus.Fulfilled, QueuePosition = 1 },
            new Reservation { Student = students[5], Bibliography = books[5], ReservedAt = now.AddDays(-12), Status = ReservationStatus.Cancelled, QueuePosition = 1 });

        var random = new Random(20261117);
        db.CheckIns.AddRange(students.SelectMany(student =>
            Enumerable.Range(0, 3).Select(_ => new CheckIn
            {
                Student = student,
                CheckedInAt = now.AddDays(-random.Next(0, 14)).AddHours(-random.Next(1, 8)),
            })));

        db.SaveChanges();

        Console.WriteLine(
            $"Seeded {1 + students.Length} users, {books.Count} bibliographies, {exemplars.Count} exemplars, " +
            $"{db.Loans.Local.Count} loans, {db.Reservations.Local.Count} reservations, {db.CheckIns.Local.Count} check-ins.");

        Loan Active(Exemplar exemplar, User student, int borrowedDaysAgo)
        {
            exemplar.Status = ExemplarStatus.Borrowed;
            return new Loan
            {
                Student = student,
                Exemplar = exemplar,
                BorrowedAt = now.AddDays(-borrowedDaysAgo),
                DueAt = now.AddDays(14 - borrowedDaysAgo),
                Status = LoanStatus.Active,
            };
        }

        Loan Returned(Exemplar exemplar, User student, int borrowedDaysAgo, int returnedDaysAgo) => new()
        {
            Student = student,
            Exemplar = exemplar,
            BorrowedAt = now.AddDays(-borrowedDaysAgo),
            DueAt = now.AddDays(14 - borrowedDaysAgo),
            ReturnedAt = now.AddDays(-returnedDaysAgo),
            Status = LoanStatus.Returned,
        };
    }

    private static User CreateUser(string username, string password, string displayName, UserRole role) => new()
    {
        Username = username,
        PasswordHash = HashPassword(password),
        DisplayName = displayName,
        Role = role,
    };

    /// <summary>Hashes a password as <c>pbkdf2-sha256$iterations$salt$hash</c> (PBKDF2-HMAC-SHA256, 32-byte key).</summary>
    internal static string HashPassword(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(16);
        var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, HashIterations, HashAlgorithmName.SHA256, 32);
        return $"pbkdf2-sha256${HashIterations}${Convert.ToBase64String(salt)}${Convert.ToBase64String(hash)}";
    }
}
