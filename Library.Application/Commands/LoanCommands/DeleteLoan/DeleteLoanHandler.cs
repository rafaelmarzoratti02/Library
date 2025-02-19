using Library.Application.Commands.LoanCommands.InsertLoan;
using Library.Application.Models;
using Library.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Commands.LoanCommands.DeleteLoan;

public class DeleteLoanHandler : IRequestHandler<DeleteLoanCommand, ResultViewModel>
{

    private readonly BooksDbContext _context;

    public DeleteLoanHandler(BooksDbContext context)
    {
        _context = context;
    }

    public async Task<ResultViewModel> Handle(DeleteLoanCommand request, CancellationToken cancellationToken)
    {
        var loan = await _context.Loans.FirstOrDefaultAsync(e => e.Id == request.Id);

        if (loan is null)
        {
            return ResultViewModel.Error("Emprestimo não existe!");
        }

        loan.SetAsDeleted();
        _context.Loans.Update(loan);
        _context.SaveChanges();

        return ResultViewModel.Sucess();
    }
}
