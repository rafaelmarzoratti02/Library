using Biblioteca.Entities;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Persistence;

public class BooksDbContext : DbContext
{
    public BooksDbContext(DbContextOptions<BooksDbContext> options) : base(options)
    {

    }

    public DbSet<Book> Books { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Book>(e =>
        {
            e.HasKey(e => e.Id);
            e.Property(e => e.ISBN)
            .HasMaxLength(13);
        });

        builder.Entity<User>(e =>
        { 
            e.HasKey(e => e.Id);
        });

        base.OnModelCreating(builder);
    }
}
