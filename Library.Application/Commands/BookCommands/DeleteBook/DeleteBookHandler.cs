using Library.Application.Models;
using Library.Core.Repositories;
using Library.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Commands.BookCommands.DeleteBook;

internal class DeleteBookHandler : IRequestHandler<DeleteBookCommand, ResultViewModel>
{

    private readonly IBookRepository _repository;

    public DeleteBookHandler(IBookRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultViewModel> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _repository.GetById(request.Id);

        if (book is null)
        {
            return ResultViewModel.Error("Livro não existe!");
        }

        book.SetAsDeleted();
        await _repository.Update(book);

        return ResultViewModel.Sucess();
    }
}
