using Microsoft.EntityFrameworkCore;
using Tasky2.Entities;
using Task = Tasky2.Entities.Task;

namespace Tasky2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(m => new {m.UserId});
            modelBuilder.Entity<Task>().HasKey(m => new { m.Id });
            
        }

        public DbSet<User> User { get; set; }
        public DbSet<Task> Task { get; set; }
    }
}
