using BtterCity.Models;
using Microsoft.EntityFrameworkCore;
namespace BtterCity.Repository
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Issue> Issues { get; set; }
        public DbSet<IssueType> IssueTypes { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
