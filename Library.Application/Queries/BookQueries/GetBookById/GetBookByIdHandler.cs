using Library.Application.Models;
using Library.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Queries.BookQueries.GetBookById;

internal class GetBookByIdHandler : IRequestHandler<GetBookByIdCommand, ResultViewModel<BookViewModel>>
{

    private readonly BooksDbContext _context;

    public GetBookByIdHandler(BooksDbContext context)
    {
        _context = context;
    }

    public async Task<ResultViewModel<BookViewModel>> Handle(GetBookByIdCommand request, CancellationToken cancellationToken)
    {
        var book = await _context.Books.SingleOrDefaultAsync(e => e.Id == request.Id);

        if (book is null)
        {
            return ResultViewModel<BookViewModel>.Error("Projeto não existe!");
        }

        var model = BookViewModel.FromEntity(book);

        return ResultViewModel<BookViewModel>.Sucess(model);
    }
}
