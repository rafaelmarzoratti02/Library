using Library.Application.Models;
using Library.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Commands.BookCommands.UpdateBook;

internal class UpdateBookHandler : IRequestHandler<UpdateBookCommand, ResultViewModel>
{

    private readonly BooksDbContext _context;

    public UpdateBookHandler(BooksDbContext context)
    {
        _context = context;
    }

    public async Task<ResultViewModel> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _context.Books.FirstOrDefaultAsync(e => e.Id == request.IdBook);

        if (book is null)
        {
            return ResultViewModel.Error("Livro não existe!");
        }

        book.Update(request.Title, request.Autor, request.ISBN, request.AnoDePublicacao);
        _context.Books.Update(book);
        _context.SaveChanges();

        return ResultViewModel.Sucess();
    }
}
