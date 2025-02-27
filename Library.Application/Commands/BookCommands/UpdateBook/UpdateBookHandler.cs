using Library.Application.Models;
using Library.Core.Repositories;
using Library.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Commands.BookCommands.UpdateBook;

internal class UpdateBookHandler : IRequestHandler<UpdateBookCommand, ResultViewModel>
{

    private readonly IBookRepository _repository;

    public UpdateBookHandler(IBookRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultViewModel> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _repository.GetById(request.IdBook);

        if (book is null)
        {
            return ResultViewModel.Error("Livro não existe!");
        }

        book.Update(request.Title, request.Autor, request.ISBN, request.AnoDePublicacao);
        await _repository.Update(book);

        return ResultViewModel.Sucess();
    }
}
