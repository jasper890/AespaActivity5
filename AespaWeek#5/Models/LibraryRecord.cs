using System;
using System.Collections.Generic;

namespace AespaWeek_5.Models;

public partial class LibraryRecord
{
    public int RecordId { get; set; }

    public string BookTitle { get; set; } = null!;

    public string? BookAuthor { get; set; }

    public string? Isbn { get; set; }

    public string? MemberName { get; set; }

    public string? MemberEmail { get; set; }

    public DateOnly? BorrowDate { get; set; }

    public DateOnly? ReturnDate { get; set; }

    public bool? Available { get; set; }
}
