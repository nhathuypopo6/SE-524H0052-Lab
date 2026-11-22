using Microsoft.EntityFrameworkCore;

namespace SchoolManagement_Razor.Models
{
    public partial class SchoolDbContext : DbContext
    {
        public SchoolDbContext()
        {
        }

        public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Enrollment> Enrollments { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.CourseId).ValueGeneratedNever();
                entity.Property(e => e.Title).HasMaxLength(100);
                entity.HasOne(d => d.Department).WithMany(p => p.Courses).HasForeignKey(d => d.DepartmentId);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.Budget).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.Property(e => e.Grade).HasMaxLength(5);
                entity.HasOne(d => d.Course).WithMany(p => p.Enrollments).HasForeignKey(d => d.CourseId);
                entity.HasOne(d => d.Student).WithMany(p => p.Enrollments).HasForeignKey(d => d.StudentId);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.FirstMidName).HasMaxLength(50);
                entity.Property(e => e.LastName).HasMaxLength(50);
            });
        }
    }
}
