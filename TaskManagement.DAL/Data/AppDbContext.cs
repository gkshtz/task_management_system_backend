using Microsoft.EntityFrameworkCore;
using TaskManagement.DAL.Entities;

namespace TaskManagement.DAL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) 
        {
            
        }
        public DbSet<Tasks> Tasks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tasks>().Property(t => t.Status).HasConversion<string>();
        }
    }
}
