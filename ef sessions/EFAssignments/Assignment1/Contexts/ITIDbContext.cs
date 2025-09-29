using Assignment1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Contexts
{
    internal class ITIDbContext:DbContext
    {
        public ITIDbContext() : base() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=.;Database=ITI_EF;Trusted_Connection=True;TrustServerCertificate=True");
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<StudCourse> StudCourses { get; set; }
        public DbSet<CourseInstructor> CourseInstructors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Composite Key for StudCourse
            modelBuilder.Entity<StudCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            // Composite Key for CourseInstructor
            modelBuilder.Entity<CourseInstructor>()
                .HasKey(ci => new { ci.CourseId, ci.InstructorId });

            // Department -> Manager (Instructor)
            modelBuilder.Entity<Department>()
                .HasOne(d => d.Manager)
                .WithMany() // one manager per department
                .HasForeignKey(d => d.InstructorMgrId)
                .OnDelete(DeleteBehavior.Restrict);

            // Department -> Instructors
            modelBuilder.Entity<Instructor>()
                .HasOne(i => i.Department)
                .WithMany(d => d.Instructors)
                .HasForeignKey(i => i.DepartmentId);

            // Department -> Students
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Department)
                .WithMany(d => d.Students)
                .HasForeignKey(s => s.DepartmentId);

            // Course -> Topic
            modelBuilder.Entity<Course>()
                .HasOne(c => c.Topic)
                .WithMany(t => t.Courses)
                .HasForeignKey(c => c.TopicId);
        }
    }
}
