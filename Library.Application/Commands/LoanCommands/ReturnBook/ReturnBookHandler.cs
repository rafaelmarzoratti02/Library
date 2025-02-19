using Library.Application.Models;
using Library.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Commands.LoanCommands.ReturnBook;

public class ReturnBookHandler : IRequestHandler<ReturnBookCommand, ResultViewModel>
{

    private readonly BooksDbContext _context;

    public ReturnBookHandler(BooksDbContext context)
    {
        _context = context;
    }

    public async Task<ResultViewModel> Handle(ReturnBookCommand request, CancellationToken cancellationToken)
    {
        var loan = await _context.Loans.FirstOrDefaultAsync(e => e.Id == request.Id);

        if (loan is null)
        {
            return ResultViewModel.Error("Empréstimo não existe!");
        }

        loan.ReturnBook();
        _context.Loans.Update(loan);
        await _context.SaveChangesAsync();

        if (loan.ReturnDate > loan.Deadline)
        {
            TimeSpan diff = loan.ReturnDate - loan.Deadline;

            int diffInDays = diff.Days;

            return ResultViewModel.Sucess("Entregue com atraso!");
        }

        return ResultViewModel.Sucess("Entregue a tempo!");
    }
}
