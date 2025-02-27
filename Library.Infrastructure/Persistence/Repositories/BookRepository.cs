using Azure.Core;
using Library.Core.Entities;
using Library.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Persistence.Repositories;

public class BookRepository : IBookRepository
{

    private readonly BooksDbContext _context;

    public BookRepository(BooksDbContext context)
    {
        _context = context;
    }

    public async Task<int> Add(Book book)
    {
        await _context.Books.AddAsync(book);
        await _context.SaveChangesAsync();
        return book.Id;
    }

    public Task<List<Book>> GetAll()
    {
       var books = _context.Books.Where(e => !e.IsDeleted).ToListAsync();
        return books;
    }

    public async Task<Book?> GetById(int id)
    {
        var book = await _context.Books.SingleOrDefaultAsync(x => x.Id == id);
        return book;
    }
    public async Task<Book?> GetDetailsById(int id)
    {
        var book = await _context.Books.SingleOrDefaultAsync(e => e.Id == id && !e.IsDeleted);
        return book;
    }

    public async Task Update(Book book)
    {
        _context.Books.Update(book);
        await _context.SaveChangesAsync();
    }
}
