using Microsoft.EntityFrameworkCore;

namespace AespaWeek_5.Models;

public partial class AespaLibraryManagementContext : DbContext
{
    public AespaLibraryManagementContext()
    {
    }

    public AespaLibraryManagementContext(DbContextOptions<AespaLibraryManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<LibraryRecord> LibraryRecords { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=AespaLibraryManagement;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LibraryRecord>(entity =>
        {
            entity.HasKey(e => e.RecordId).HasName("PK__LibraryR__FBDF78C94D7731DD");

            entity.Property(e => e.RecordId).HasColumnName("RecordID");
            entity.Property(e => e.Available).HasDefaultValue(true);
            entity.Property(e => e.BookAuthor).HasMaxLength(100);
            entity.Property(e => e.BookTitle).HasMaxLength(150);
            entity.Property(e => e.BorrowDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Isbn)
                .HasMaxLength(20)
                .HasColumnName("ISBN");
            entity.Property(e => e.MemberEmail).HasMaxLength(100);
            entity.Property(e => e.MemberName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
