using Library.Application.Models;
using Library.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Queries.LoanQueries.GetLoanById;

internal class GetLoanByIdHandler : IRequestHandler<GetLoanByIdCommand, ResultViewModel<LoanViewModel>>
{

    private readonly BooksDbContext _context;

    public GetLoanByIdHandler(BooksDbContext context)
    {
        _context = context;
    }

    public async Task<ResultViewModel<LoanViewModel>> Handle(GetLoanByIdCommand request, CancellationToken cancellationToken)
    {
        var loan = await _context.Loans
              .Include(e => e.User)
              .Include(e => e.Book)
             .FirstOrDefaultAsync(e => e.Id == request.Id);

        if (loan is null)
        {
            return ResultViewModel<LoanViewModel>.Error("Empréstimo não existe!");
        }

        var model = LoanViewModel.FromEntity(loan);

        return ResultViewModel<LoanViewModel>.Sucess(model);
    }
}
