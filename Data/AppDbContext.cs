using Microsoft.EntityFrameworkCore;
using UniClass.Models;

namespace UniClass.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Major> Majors { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {

            // Defining the relationship between students and their major
            builder.Entity<Student>()
                .HasOne(x => x.Major)
                .WithMany(x => x.Students);

            // Seed initial database with students and majors to demonstrate
            new DbInitializer(builder).Seed();
        }
    }
}