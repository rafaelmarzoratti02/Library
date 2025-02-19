using Library.Application.Models;
using Library.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Commands.BookCommands.DeleteBook;

internal class DeleteBookHandler : IRequestHandler<DeleteBookCommand, ResultViewModel>
{

    private readonly BooksDbContext _context;

    public DeleteBookHandler(BooksDbContext context)
    {
        _context = context;
    }

    public async Task<ResultViewModel> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _context.Books.FirstOrDefaultAsync(e => e.Id == request.Id);

        if (book is null)
        {
            return ResultViewModel.Error("Livro não existe!");
        }

        book.SetAsDeleted();
        _context.Books.Update(book);
        await _context.SaveChangesAsync();

        return ResultViewModel.Sucess();
    }
}
