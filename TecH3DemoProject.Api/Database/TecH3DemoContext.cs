using Microsoft.EntityFrameworkCore;
using TecH3DemoProject.Api.Domain;

namespace TecH3DemoProject.Api.Database
{
    public class TecH3DemoContext : DbContext
    {

        public TecH3DemoContext() { }
        public TecH3DemoContext(DbContextOptions<TecH3DemoContext> options) : base(options) { }

        public DbSet<Author> Author { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<Login> Login { get; set; }
    }
}
