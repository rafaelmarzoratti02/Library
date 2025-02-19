using Library.Application.Models;
using MediatR;

namespace Library.Application.Queries.LoanQueries.GetLoanById;

internal class GetLoanByIdCommand : IRequest<ResultViewModel<LoanViewModel>>
{
    public int Id { get; set; }

    public GetLoanByIdCommand(int id)
    {
        Id = id;
    }
}
