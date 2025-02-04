using Biblioteca.Entities;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Persistency;

public class BooksDbContext : DbContext
{
    public BooksDbContext(DbContextOptions<BooksDbContext> options) : base(options)
    {

    }

    public DbSet<Book> Books { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Loan> Loans { get; set; }



    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Book>(e =>
        {
            e.HasKey(e => e.Id);
        });

        base.OnModelCreating(builder);
    }
}
