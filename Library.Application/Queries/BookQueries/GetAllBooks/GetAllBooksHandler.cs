using Library.Application.Models;
using Library.Core.Repositories;
using Library.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Queries.BookQueries.GetAllBooks;

internal class GetAllBooksHandler : IRequestHandler<GetAllBooksCommand, ResultViewModel<List<BookItemViewModel>>>
{

    private readonly IBookRepository _repository;

    public GetAllBooksHandler(IBookRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultViewModel<List<BookItemViewModel>>> Handle(GetAllBooksCommand request, CancellationToken cancellationToken)
    {
        var books = await _repository.GetAll();

        var model = books.Select(x => BookItemViewModel.FromEntity(x)).ToList();

        return ResultViewModel<List<BookItemViewModel>>.Sucess(model);
    }
}
