using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeApp.DataModels
{
    public class CollegeDbContext : DbContext
    {
        public CollegeDbContext(DbContextOptions opt)
            : base(opt)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Student
            modelBuilder
                .Entity<Student>()
                .ToTable("Students")
                .HasKey(p => p.StudentNumber);

            modelBuilder
                .Entity<Student>()
                .Property(p => p.FullName)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder
                .Entity<Student>()
                .Property(p => p.MobilePhone)
                .HasMaxLength(9)
                .IsRequired();

            // Subject
            modelBuilder
                .Entity<Subject>()
                .ToTable("Subjects")
                .HasKey(p => p.SubjectId);

            modelBuilder
                .Entity<Subject>()
                .Property(p => p.Name)
                .HasMaxLength(50);

            modelBuilder
                .Entity<Subject>()
                .Property(p => p.Semester)
                .HasMaxLength(20);

            modelBuilder
                .Entity<Subject>()
                .HasOne(p => p.Student)
                .WithMany(p => p.Subjects)
                .HasForeignKey(p => p.StudentNumber);

            Seed(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        public void Seed(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Student>()
                .HasData(
                new Student()
                {
                    StudentNumber = 1,
                    FullName = "Vladimir Koloski",
                    MobilePhone = 076215802,
                    Email = "v.koloski@gmail.com"
                });
            modelBuilder.Entity<Subject>()
                .HasData(
                new Subject()
                {
                    SubjectId = 1,
                    Name = "C#",
                    Credits = 8,
                    Semester = "1",
                    StudentNumber = 1
                },
                new Subject()
                {
                    SubjectId = 2,
                    Name = "SQL",
                    Credits = 5,
                    Semester = "2",
                    StudentNumber = 1
                }
                );
        }
    }
}

