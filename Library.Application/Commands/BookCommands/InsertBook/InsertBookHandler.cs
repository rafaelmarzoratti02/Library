using Library.Application.Models;
using Library.Application.Notifications.BookCreated;
using Library.Core.Repositories;
using Library.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Commands.BookCommands.InsertBook;

internal class InsertBookHandler : IRequestHandler<InsertBookCommand, ResultViewModel<int>>
{

    private readonly IMediator _mediator;
    private readonly IBookRepository _repository;

    public InsertBookHandler(IMediator mediator, IBookRepository repository)
    {
        _mediator = mediator;
        _repository = repository;
    }

    public async Task<ResultViewModel<int>> Handle(InsertBookCommand request, CancellationToken cancellationToken)
    {
        var book = request.ToEntity();
        await _repository.Add(book);

        var bookCreated = new BookCreatedNotification(book.Title);

        await _mediator.Publish(bookCreated);

        return ResultViewModel<int>.Sucess(book.Id);
    }
}
