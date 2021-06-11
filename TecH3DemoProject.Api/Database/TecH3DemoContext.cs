using Microsoft.EntityFrameworkCore;
using System;
using TecH3DemoProject.Api.Domain;

namespace TecH3DemoProject.Api.Database
{
    public class TecH3DemoContext : DbContext
    {

        public TecH3DemoContext() { }
        public TecH3DemoContext(DbContextOptions<TecH3DemoContext> options) : base(options) { }

        public DbSet<Role> Role { get; set; }

        public DbSet<Author> Author { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<Login> Login { get; set; }
        public DbSet<Address> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Login>().HasIndex(u => u.Email).IsUnique();

            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    Name = "Customer"
                },
                new Role
                {
                    Id = 2,
                    Name = "Admin"
                });

            modelBuilder.Entity<Login>().HasData(
                new Login
                {
                    Id = 1,
                    Email = "albert@mail.dk",
                    Password = "Test1234",
                    RoleId = 2,
                    createdAt = DateTime.Now
                },
                new Login
                {
                    Id = 2,
                    Email = "benny@mail.dk",
                    Password = "Test1234",
                    RoleId = 1,
                    createdAt = DateTime.Now
                });

            modelBuilder.Entity<Address>().HasData(
                new Address
                {
                    Id = 1,
                    StreetName = "Telegrafvej",
                    StreetNumber = "9",
                    CityName = "Ballerup",
                    ZipCode = "2750",
                    createdAt = DateTime.Now
                });

        }
    }
}
