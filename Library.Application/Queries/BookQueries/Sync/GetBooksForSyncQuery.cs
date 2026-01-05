using Library.Application.Models;
using MediatR;

namespace Library.Application.Queries.BookQueries.Sync;

public class GetBooksForSyncQuery : IRequest<List<BookSyncModel>>
{
    
}