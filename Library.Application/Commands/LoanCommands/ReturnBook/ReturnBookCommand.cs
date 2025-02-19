using Library.Application.Models;
using MediatR;

namespace Library.Application.Commands.LoanCommands.ReturnBook;

public class ReturnBookCommand : IRequest<ResultViewModel>
{
    public int Id { get; set; }

    public ReturnBookCommand(int id)
    {
        Id = id;
    }
}
