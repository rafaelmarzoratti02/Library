using Library.Application.Models;
using MediatR;

namespace Library.Application.Queries.LoanQueries.GetAllLoans
{
    public class GetAllLoansCommand : IRequest<ResultViewModel<List<LoanItemViewModel>>>
    {
        public GetAllLoansCommand()
        {
        }
    }
}
