﻿using Biblioteca.Entities;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Persistence;

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
            e.Property(e => e.ISBN)
            .HasMaxLength(13);
        });

        builder.Entity<User>(e =>
        { 
            e.HasKey(e => e.Id);
        });

        builder.Entity<Loan>(e =>
        {
            e.HasKey(e => e.Id);

            e.HasOne(e=> e.User)
            .WithMany(e => e.Loans)
            .HasForeignKey(e => e.IdUser)
            .OnDelete(DeleteBehavior.Restrict);

            e.HasOne(e=> e.Book)
            .WithMany(e=> e.Loans)
            .HasForeignKey(e=> e.IdBook)
            .OnDelete(DeleteBehavior.Restrict);
        });

        base.OnModelCreating(builder);
    }
}
