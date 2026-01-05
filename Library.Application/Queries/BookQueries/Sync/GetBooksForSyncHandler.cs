using Library.Application.Models;
using Library.Core.Repositories;
using MediatR;

namespace Library.Application.Queries.BookQueries.Sync;

public class GetBooksForSyncHandler : IRequestHandler<GetBooksForSyncQuery, List<BookSyncModel>>
{
    private readonly IBookRepository _repository;

    public GetBooksForSyncHandler(IBookRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<BookSyncModel>> Handle(GetBooksForSyncQuery request, CancellationToken cancellationToken)
    {
        var books = await _repository.GetAll();

        var model = books.Select(x => BookSyncModel.FromEntity(x)).ToList();

        return model;
    }
}