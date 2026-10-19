using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BacaIn.Data;
using BacaIn.Models;
using Npgsql;

namespace BacaIn.Services
{
    public class BookService
    {
        private static BookService? _instance;
        public static BookService Instance => _instance ??= new BookService();

        private static readonly HttpClient _httpClient = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(8)
        };

        public async Task<List<Bibliography>> SearchBibliographiesAsync(string? keyword = null, bool availableOnly = false)
        {
            var list = new List<Bibliography>();
            await using var conn = DatabaseContext.Instance.CreateConnection();
            await conn.OpenAsync();

            var sql = @"
                SELECT b.id, b.title, b.isbn, b.author, b.publisher, b.publisher_year, b.description, b.cover_url, b.created_at, b.updated_at,
                       COUNT(e.id) as total_copies,
                       COUNT(CASE WHEN e.status = 'AVAILABLE' AND e.deleted_at IS NULL THEN 1 END) as available_copies
                FROM bibliographies b
                LEFT JOIN exemplars e ON b.id = e.bibliography_id AND e.deleted_at IS NULL
                WHERE b.deleted_at IS NULL
            ";

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                sql += @" AND (
                    LOWER(b.title) LIKE @kw OR 
                    LOWER(b.author) LIKE @kw OR 
                    LOWER(b.publisher) LIKE @kw OR 
                    b.isbn LIKE @kw
                )";
            }

            sql += " GROUP BY b.id";

            if (availableOnly)
            {
                sql += " HAVING COUNT(CASE WHEN e.status = 'AVAILABLE' AND e.deleted_at IS NULL THEN 1 END) > 0";
            }

            sql += " ORDER BY b.title ASC;";

            await using var cmd = new NpgsqlCommand(sql, conn);
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                cmd.Parameters.AddWithValue("kw", "%" + keyword.Trim().ToLowerInvariant() + "%");
            }

            await using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                list.Add(new Bibliography
                {
                    Id = reader.GetGuid(0),
                    Title = reader.GetString(1),
                    Isbn = reader.IsDBNull(2) ? null : reader.GetString(2),
                    Author = reader.GetString(3),
                    Publisher = reader.GetString(4),
                    PublisherYear = reader.IsDBNull(5) ? null : reader.GetInt32(5),
                    Description = reader.IsDBNull(6) ? null : reader.GetString(6),
                    CoverUrl = reader.IsDBNull(7) ? null : reader.GetString(7),
                    CreatedAt = reader.GetDateTime(8),
                    UpdatedAt = reader.IsDBNull(9) ? null : reader.GetDateTime(9),
                    TotalCopies = Convert.ToInt32(reader.GetInt64(10)),
                    AvailableCopies = Convert.ToInt32(reader.GetInt64(11))
                });
            }

            return list;
        }

        public async Task<Bibliography?> GetBibliographyByIdAsync(Guid id)
        {
            await using var conn = DatabaseContext.Instance.CreateConnection();
            await conn.OpenAsync();

            const string sql = @"
                SELECT b.id, b.title, b.isbn, b.author, b.publisher, b.publisher_year, b.description, b.cover_url, b.created_at, b.updated_at,
                       COUNT(e.id) as total_copies,
                       COUNT(CASE WHEN e.status = 'AVAILABLE' AND e.deleted_at IS NULL THEN 1 END) as available_copies
                FROM bibliographies b
                LEFT JOIN exemplars e ON b.id = e.bibliography_id AND e.deleted_at IS NULL
                WHERE b.id = @id AND b.deleted_at IS NULL
                GROUP BY b.id
                LIMIT 1;
            ";

            await using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("id", id);

            await using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new Bibliography
                {
                    Id = reader.GetGuid(0),
                    Title = reader.GetString(1),
                    Isbn = reader.IsDBNull(2) ? null : reader.GetString(2),
                    Author = reader.GetString(3),
                    Publisher = reader.GetString(4),
                    PublisherYear = reader.IsDBNull(5) ? null : reader.GetInt32(5),
                    Description = reader.IsDBNull(6) ? null : reader.GetString(6),
                    CoverUrl = reader.IsDBNull(7) ? null : reader.GetString(7),
                    CreatedAt = reader.GetDateTime(8),
                    UpdatedAt = reader.IsDBNull(9) ? null : reader.GetDateTime(9),
                    TotalCopies = Convert.ToInt32(reader.GetInt64(10)),
                    AvailableCopies = Convert.ToInt32(reader.GetInt64(11))
                };
            }

            return null;
        }

        public async Task<Bibliography> CreateBibliographyAsync(Bibliography book)
        {
            if (book.Id == Guid.Empty) book.Id = Guid.NewGuid();
            book.CreatedAt = DateTime.UtcNow;

            await using var conn = DatabaseContext.Instance.CreateConnection();
            await conn.OpenAsync();

            const string sql = @"
                INSERT INTO bibliographies (id, title, isbn, author, publisher, publisher_year, description, cover_url, created_at)
                VALUES (@id, @title, @isbn, @author, @publisher, @year, @desc, @cover, @createdAt);
            ";

            await using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("id", book.Id);
            cmd.Parameters.AddWithValue("title", book.Title);
            cmd.Parameters.AddWithValue("isbn", (object?)book.Isbn ?? DBNull.Value);
            cmd.Parameters.AddWithValue("author", book.Author);
            cmd.Parameters.AddWithValue("publisher", book.Publisher);
            cmd.Parameters.AddWithValue("year", (object?)book.PublisherYear ?? DBNull.Value);
            cmd.Parameters.AddWithValue("desc", (object?)book.Description ?? DBNull.Value);
            cmd.Parameters.AddWithValue("cover", (object?)book.CoverUrl ?? DBNull.Value);
            cmd.Parameters.AddWithValue("createdAt", book.CreatedAt);

            await cmd.ExecuteNonQueryAsync();
            return book;
        }

        public async Task UpdateBibliographyAsync(Bibliography book)
        {
            book.UpdatedAt = DateTime.UtcNow;
            await using var conn = DatabaseContext.Instance.CreateConnection();
            await conn.OpenAsync();

            const string sql = @"
                UPDATE bibliographies
                SET title = @title,
                    isbn = @isbn,
                    author = @author,
                    publisher = @publisher,
                    publisher_year = @year,
                    description = @desc,
                    cover_url = @cover,
                    updated_at = @updatedAt
                WHERE id = @id;
            ";

            await using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("id", book.Id);
            cmd.Parameters.AddWithValue("title", book.Title);
            cmd.Parameters.AddWithValue("isbn", (object?)book.Isbn ?? DBNull.Value);
            cmd.Parameters.AddWithValue("author", book.Author);
            cmd.Parameters.AddWithValue("publisher", book.Publisher);
            cmd.Parameters.AddWithValue("year", (object?)book.PublisherYear ?? DBNull.Value);
            cmd.Parameters.AddWithValue("desc", (object?)book.Description ?? DBNull.Value);
            cmd.Parameters.AddWithValue("cover", (object?)book.CoverUrl ?? DBNull.Value);
            cmd.Parameters.AddWithValue("updatedAt", book.UpdatedAt);

            await cmd.ExecuteNonQueryAsync();
        }

        public async Task DeleteBibliographyAsync(Guid id)
        {
            await using var conn = DatabaseContext.Instance.CreateConnection();
            await conn.OpenAsync();

            const string sql = @"
                UPDATE bibliographies SET deleted_at = NOW() WHERE id = @id;
                UPDATE exemplars SET deleted_at = NOW() WHERE bibliography_id = @id;
            ";

            await using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("id", id);
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task<List<Exemplar>> GetExemplarsAsync(Guid bibliographyId)
        {
            var list = new List<Exemplar>();
            await using var conn = DatabaseContext.Instance.CreateConnection();
            await conn.OpenAsync();

            const string sql = @"
                SELECT id, bibliography_id, barcode, status, condition, created_at, updated_at
                FROM exemplars
                WHERE bibliography_id = @bibId AND deleted_at IS NULL
                ORDER BY barcode ASC;
            ";

            await using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("bibId", bibliographyId);

            await using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                list.Add(new Exemplar
                {
                    Id = reader.GetGuid(0),
                    BibliographyId = reader.GetGuid(1),
                    Barcode = reader.GetString(2),
                    Status = reader.GetString(3),
                    Condition = reader.GetString(4),
                    CreatedAt = reader.GetDateTime(5),
                    UpdatedAt = reader.IsDBNull(6) ? null : reader.GetDateTime(6)
                });
            }

            return list;
        }

        public async Task<Exemplar> AddExemplarAsync(Guid bibliographyId, string barcode, string condition = "GOOD")
        {
            var exemplar = new Exemplar
            {
                Id = Guid.NewGuid(),
                BibliographyId = bibliographyId,
                Barcode = barcode.Trim().ToUpperInvariant(),
                Status = "AVAILABLE",
                Condition = condition.ToUpperInvariant(),
                CreatedAt = DateTime.UtcNow
            };

            await using var conn = DatabaseContext.Instance.CreateConnection();
            await conn.OpenAsync();

            const string sql = @"
                INSERT INTO exemplars (id, bibliography_id, barcode, status, condition, created_at)
                VALUES (@id, @bibId, @barcode, @status, @condition, @createdAt);
            ";

            await using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("id", exemplar.Id);
            cmd.Parameters.AddWithValue("bibId", exemplar.BibliographyId);
            cmd.Parameters.AddWithValue("barcode", exemplar.Barcode);
            cmd.Parameters.AddWithValue("status", exemplar.Status);
            cmd.Parameters.AddWithValue("condition", exemplar.Condition);
            cmd.Parameters.AddWithValue("createdAt", exemplar.CreatedAt);

            await cmd.ExecuteNonQueryAsync();
            return exemplar;
        }

        public async Task UpdateExemplarAsync(Guid id, string status, string condition)
        {
            await using var conn = DatabaseContext.Instance.CreateConnection();
            await conn.OpenAsync();

            const string sql = @"
                UPDATE exemplars
                SET status = @status,
                    condition = @condition,
                    updated_at = NOW()
                WHERE id = @id;
            ";

            await using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("id", id);
            cmd.Parameters.AddWithValue("status", status.ToUpperInvariant());
            cmd.Parameters.AddWithValue("condition", condition.ToUpperInvariant());

            await cmd.ExecuteNonQueryAsync();
        }

        public async Task DeleteExemplarAsync(Guid id)
        {
            await using var conn = DatabaseContext.Instance.CreateConnection();
            await conn.OpenAsync();

            const string sql = "UPDATE exemplars SET deleted_at = NOW() WHERE id = @id;";
            await using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("id", id);
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task<Bibliography?> LookupIsbnAsync(string isbn)
        {
            var cleanIsbn = isbn.Replace("-", "").Trim();
            if (cleanIsbn.Length is not (10 or 13)) return null;

            try
            {
                var url = $"https://openlibrary.org/api/books?bibkeys=ISBN:{cleanIsbn}&format=json&jscmd=data";
                using var response = await _httpClient.GetAsync(url);
                if (!response.IsSuccessStatusCode) return null;

                var json = await response.Content.ReadAsStringAsync();
                using var doc = JsonDocument.Parse(json);
                var key = $"ISBN:{cleanIsbn}";
                if (!doc.RootElement.TryGetProperty(key, out var bookElement)) return null;

                var book = new Bibliography
                {
                    Isbn = cleanIsbn
                };

                if (bookElement.TryGetProperty("title", out var titleProp))
                {
                    book.Title = titleProp.GetString() ?? "";
                }

                if (bookElement.TryGetProperty("authors", out var authorsProp) && authorsProp.GetArrayLength() > 0)
                {
                    if (authorsProp[0].TryGetProperty("name", out var authorName))
                    {
                        book.Author = authorName.GetString() ?? "";
                    }
                }

                if (bookElement.TryGetProperty("publishers", out var publishersProp) && publishersProp.GetArrayLength() > 0)
                {
                    if (publishersProp[0].TryGetProperty("name", out var pubName))
                    {
                        book.Publisher = pubName.GetString() ?? "";
                    }
                }

                if (bookElement.TryGetProperty("publish_date", out var dateProp))
                {
                    var dateStr = dateProp.GetString() ?? "";
                    var match = Regex.Match(dateStr, @"\b(19\d\d|20\d\d)\b");
                    if (match.Success && int.TryParse(match.Value, out var year))
                    {
                        book.PublisherYear = year;
                    }
                }

                if (bookElement.TryGetProperty("cover", out var coverProp))
                {
                    if (coverProp.TryGetProperty("large", out var largeUrl))
                    {
                        book.CoverUrl = largeUrl.GetString();
                    }
                    else if (coverProp.TryGetProperty("medium", out var medUrl))
                    {
                        book.CoverUrl = medUrl.GetString();
                    }
                }

                return book;
            }
            catch
            {
                return null;
            }
        }
    }
}
