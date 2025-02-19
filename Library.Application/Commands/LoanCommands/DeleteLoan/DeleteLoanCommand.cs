using Library.Application.Models;
using MediatR;

namespace Library.Application.Commands.LoanCommands.DeleteLoan;

public class DeleteLoanCommand : IRequest<ResultViewModel>
{
    public int Id { get; set; }

    public DeleteLoanCommand(int id)
    {
        Id = id;
    }
}
