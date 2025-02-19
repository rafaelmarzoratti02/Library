using Library.Application.Models;
using MediatR;

namespace Library.Application.Commands.BookCommands.DeleteBook;

public class DeleteBookCommand : IRequest<ResultViewModel>
{

    public int Id { get; set; }

    public DeleteBookCommand(int id)
    {
        Id = id;
    }
}
