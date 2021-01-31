using CourseManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseManagement.Infrastructure.Persistence.Context
{
    public class CourseDbContext: DbContext
    {
        public DbSet<Course> Courses { get; set; }

        public CourseDbContext(DbContextOptions<CourseDbContext> options)
        : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().Property(u => u.Price).HasColumnType("decimal(10, 2)");
        }

    }
}
