using Library.Application.Models;
using Library.Core.Entities;
using MediatR;

namespace Library.Application.Queries.BookQueries.GetAllBooks;

public class GetAllBooksCommand : IRequest<ResultViewModel<List<BookItemViewModel>>>
{
    public GetAllBooksCommand()
    {

    }

}
