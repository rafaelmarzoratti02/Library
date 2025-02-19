using Library.Application.Models;
using Library.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Commands.LoanCommands.InsertLoan;

internal class InsertLoanHandler : IRequestHandler<InsertLoanCommand, ResultViewModel<int>>
{

    private readonly BooksDbContext _context;

    public InsertLoanHandler(BooksDbContext context)
    {
        _context = context;
    }

    public async Task<ResultViewModel<int>> Handle(InsertLoanCommand request, CancellationToken cancellationToken)
    {
        var loan = request.ToEntity();

        await  _context.Loans.AddAsync(loan);
        await  _context.SaveChangesAsync();

        return ResultViewModel<int>.Sucess(loan.Id);
    }
}
