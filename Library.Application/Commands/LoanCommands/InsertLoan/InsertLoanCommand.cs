using Library.Application.Models;
using Library.Core.Entities;
using MediatR;

namespace Library.Application.Commands.LoanCommands.InsertLoan;

public class InsertLoanCommand : IRequest<ResultViewModel<int>>
{
    public InsertLoanCommand(int idBook, int idUser)
    {
        IdBook = idBook;
        IdUser = idUser;
    }

    public int IdBook { get; set; }
    public int IdUser { get; set; }

    public Loan ToEntity()
        => new(IdBook, IdUser);

}
