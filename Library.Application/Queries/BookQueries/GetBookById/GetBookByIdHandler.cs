using Library.Application.Models;
using Library.Core.Repositories;
using Library.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Queries.BookQueries.GetBookById;

internal class GetBookByIdHandler : IRequestHandler<GetBookByIdCommand, ResultViewModel<BookViewModel>>
{

    private readonly IBookRepository _repository;

    public GetBookByIdHandler(IBookRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultViewModel<BookViewModel>> Handle(GetBookByIdCommand request, CancellationToken cancellationToken)
    {
        var book = await _repository.GetDetailsById(request.Id);

        if (book is null)
        {
            return ResultViewModel<BookViewModel>.Error("Projeto não existe!");
        }

        var model = BookViewModel.FromEntity(book);

        return ResultViewModel<BookViewModel>.Sucess(model);
    }
}
