using DunDrag.Models;
using Microsoft.EntityFrameworkCore;

namespace DunDrag.Data
{
    public class DunDragContext : DbContext
    {
        public DunDragContext(DbContextOptions<DunDragContext> options) : base(options)
        {
        }

        public DbSet<Sort> Sorts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Course>().ToTable("Course");
            //modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            //modelBuilder.Entity<Student>().ToTable("Student");
        }
    }
}