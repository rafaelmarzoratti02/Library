using Library.Application.Models;
using Library.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Commands.BookCommands.InsertBook;

internal class InsertBookHandler : IRequestHandler<InsertBookCommand, ResultViewModel<int>>
{

    private readonly BooksDbContext _context;

    public InsertBookHandler(BooksDbContext context)
    {
        _context = context;
    }

    public async Task<ResultViewModel<int>> Handle(InsertBookCommand request, CancellationToken cancellationToken)
    {
        var book = request.ToEntity();
        await _context.Books.AddAsync(book);
        await _context.SaveChangesAsync();

        return ResultViewModel<int>.Sucess(book.Id);
    }
}
