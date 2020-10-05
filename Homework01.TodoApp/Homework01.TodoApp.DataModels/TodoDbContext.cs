using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Homework01.TodoApp.DataModels
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User

            modelBuilder
                .Entity<User>()
                .ToTable(nameof(User))
                .HasKey(p => p.Id);

            modelBuilder
                .Entity<User>()
                .Property(p => p.FirstName)
                .HasMaxLength(30)
                .IsRequired();

            modelBuilder
                .Entity<User>()
                .Property(p => p.LastName)
                .HasMaxLength(30)
                .IsRequired();

            modelBuilder
                .Entity<User>()
                .Property(p => p.Password)
                .HasMaxLength(100)
                .IsRequired();

            //Todo

            modelBuilder
                .Entity<Todo>()
                .ToTable(nameof(Todo))
                .HasKey(p => p.Id);

            modelBuilder
                .Entity<Todo>()
                .Property(p => p.Subject)
                .IsRequired();

            modelBuilder
                .Entity<Todo>()
                .Property(p => p.Description)
                .HasMaxLength(300);

            modelBuilder
                .Entity<Todo>()
                .Property(p => p.CreatedOn)
                .HasDefaultValue();

            modelBuilder
                .Entity<Todo>()
                .Property(p => p.TimeTodo)
                .IsRequired();

            modelBuilder
                .Entity<Todo>()
                .HasOne(p => p.User)
                .WithMany(p => p.Todos)
                .HasForeignKey(p => p.UserId);



            base.OnModelCreating(modelBuilder);
            Seed(modelBuilder);
        }

        public void Seed(ModelBuilder modelBuilder)
        {
            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(Encoding.ASCII.GetBytes("123456sedc"));
            var hashedPassword = Encoding.ASCII.GetString(md5data);

            modelBuilder.Entity<User>()
                .HasData(
                new User()
                {
                    Id = 1,
                    FirstName = "Bob",
                    LastName = "Bobsky",
                    Username = "bob007",
                    Password = hashedPassword
                },

                new User()
                {
                    Id = 2,
                    FirstName = "Vladimir",
                    LastName = "Koloski",
                    Username = "vlatko",
                    Password = hashedPassword
                }
                );
            modelBuilder.Entity<Todo>()
                .HasData(
                new Todo()
                {
                    Id = 1,
                    Subject = "Shoping",
                    Description = "In ramstore mall, in store of Peko, i should buy new shoes",
                    TimeTodo = new DateTime(2020, 10, 10),
                    UserId = 1
                },
                new Todo()
                {
                    Id = 2,
                    Subject = "Running",
                    Description = "Dont forget to take some water",
                    TimeTodo = new DateTime(2020, 10, 31),
                    UserId = 1
                },
                new Todo()
                {
                    Id = 3,
                    Subject = "Homework",
                    Description = "To build a service for TODO as WebApi",
                    TimeTodo = new DateTime(2020, 10, 05),
                    UserId = 2
                }
                );
        }
    }
}
