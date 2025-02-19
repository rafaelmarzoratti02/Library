using Library.Application.Models;
using Library.Core.Entities;
using MediatR;

namespace Library.Application.Queries.BookQueries.GetBookById;

public class GetBookByIdCommand : IRequest<ResultViewModel<BookViewModel>>
{
    public GetBookByIdCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }

}

