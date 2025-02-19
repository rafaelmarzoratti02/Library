using Library.Application.Models;
using Library.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Queries.LoanQueries.GetAllLoans;

internal class GetAllLoanssHandler : IRequestHandler<GetAllLoansCommand, ResultViewModel<List<LoanItemViewModel>>>
{

    private readonly BooksDbContext _context;

    public GetAllLoanssHandler(BooksDbContext context)
    {
        _context = context;
    }

    public async Task<ResultViewModel<List<LoanItemViewModel>>> Handle(GetAllLoansCommand request, CancellationToken cancellationToken)
    {
        var loans = await _context.Loans
              .Include(e => e.User)
              .Include(e => e.Book)
              .Where(e => !e.IsDeleted)
              .ToListAsync();

        var model = loans.Select(e => LoanItemViewModel.FromEntity(e)).ToList();

        return ResultViewModel<List<LoanItemViewModel>>.Sucess(model);
    }
}
