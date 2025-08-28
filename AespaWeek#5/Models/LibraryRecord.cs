
using System.ComponentModel.DataAnnotations;
namespace AespaWeek_5.Models;

public partial class LibraryRecord
{
    [Key]
    public int RecordId { get; set; }
    [Required]
    public string? BookTitle { get; set; }
    [Required]
    public string? BookAuthor { get; set; }
    [Required(ErrorMessage = "ISBN is required")]
    [StringLength(13, MinimumLength = 10, ErrorMessage = "ISBN must be 10 or 13 characters long")]
    public string? Isbn { get; set; }

    public string? MemberName { get; set; }
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    [StringLength(100, ErrorMessage = "Email cannot be longer than 100 characters")]
    public string? MemberEmail { get; set; }

    public DateOnly? BorrowDate { get; set; }

    public DateOnly? ReturnDate { get; set; }

    public bool? Available { get; set; }
}
