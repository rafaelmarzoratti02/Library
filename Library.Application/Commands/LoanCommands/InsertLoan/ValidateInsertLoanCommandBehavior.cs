using Library.Application.Models;
using Library.Infrastructure.Persistence;
using MediatR;

namespace Library.Application.Commands.LoanCommands.InsertLoan;

public class ValidateInsertLoanCommandBehavior : IPipelineBehavior<InsertLoanCommand, ResultViewModel<int>>
{

    private readonly BooksDbContext _context;

    public ValidateInsertLoanCommandBehavior(BooksDbContext context)
    {
        _context = context;
    }

    public async Task<ResultViewModel<int>> Handle(InsertLoanCommand request, RequestHandlerDelegate<ResultViewModel<int>> next, CancellationToken cancellationToken)
    {
        
        var userExists = _context.Users.Any(u => u.Id == request.IdUser);
        var bookExists = _context.Books.Any(u => u.Id == request.IdBook);

        if (!userExists || !bookExists)
        {
            return ResultViewModel<int>.Error("Livro ou usuário inexistente!");
        }
        return await next();
    }
}
