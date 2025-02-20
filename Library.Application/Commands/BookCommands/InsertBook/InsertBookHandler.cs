using Library.Application.Models;
using Library.Application.Notifications.BookCreated;
using Library.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Commands.BookCommands.InsertBook;

internal class InsertBookHandler : IRequestHandler<InsertBookCommand, ResultViewModel<int>>
{

    private readonly BooksDbContext _context;
    private readonly IMediator _mediator;

    public InsertBookHandler(BooksDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<ResultViewModel<int>> Handle(InsertBookCommand request, CancellationToken cancellationToken)
    {
        var book = request.ToEntity();
        await _context.Books.AddAsync(book);
        await _context.SaveChangesAsync();

        var bookCreated = new BookCreatedNotification(book.Title);

        await _mediator.Publish(bookCreated);

        return ResultViewModel<int>.Sucess(book.Id);
    }
}
