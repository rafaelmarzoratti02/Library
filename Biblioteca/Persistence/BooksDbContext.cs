using Biblioteca.Entities;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Persistence;

public class BooksDbContext : DbContext
{
    public BooksDbContext(DbContextOptions<BooksDbContext> options) : base(options)
    {

    }

    public DbSet<Book> Books { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Book>(e =>
        {
            e.HasKey(e => e.Id);
            e.Property(e => e.ISBN)
            .HasMaxLength(13);
        });

        base.OnModelCreating(builder);
    }
}
