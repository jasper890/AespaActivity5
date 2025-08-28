using AespaWeek_5.Models;
using Microsoft.EntityFrameworkCore;
namespace AespaWeek_5.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<LibraryRecord> LibraryRecords { get; set; } = null!;
    }
}