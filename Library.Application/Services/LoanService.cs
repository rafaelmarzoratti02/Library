using Library.Application.Models;
using Library.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Services
{
    internal class LoanService : ILoanService
    {

        private readonly BooksDbContext _context;

        public LoanService(BooksDbContext context)
        {
            _context = context;
        }


        public ResultViewModel<List<LoanItemViewModel>> GetAll()
        {
            var loans = _context.Loans
               .Include(e => e.User)
               .Include(e => e.Book)
               .Where(e => !e.IsDeleted);

            var model = loans.Select(e => LoanItemViewModel.FromEntity(e)).ToList();

            return ResultViewModel<List<LoanItemViewModel>>.Sucess(model);
        }

        public ResultViewModel<LoanViewModel> GetById(int id)
        {
            var loan = _context.Loans
               .Include(e => e.User)
               .Include(e => e.Book)
              .FirstOrDefault(e => e.Id == id);

            if (loan is null)
            {
                return ResultViewModel<LoanViewModel>.Error("Empréstimo não existe!");
            }

            var model = LoanViewModel.FromEntity(loan);

            return ResultViewModel<LoanViewModel>.Sucess(model);
        }

        public ResultViewModel<int> Insert(CreateLoanInputModel model)
        {
            var loan = model.ToEntity();

            _context.Loans.Add(loan);
            _context.SaveChanges();

            return ResultViewModel<int>.Sucess(loan.Id);
        }
        public ResultViewModel Delete(int id)
        {
            var loan = _context.Loans.FirstOrDefault(e => e.Id == id);

            if (loan is null)
            {
                return ResultViewModel.Error("Emprestimo não existe!");
            }

            loan.SetAsDeleted();
            _context.Loans.Update(loan);
            _context.SaveChanges();

            return ResultViewModel.Sucess();
        }

        public ResultViewModel ReturnBook(int id)
        {
            var loan = _context.Loans.FirstOrDefault(e => e.Id == id);

            if (loan is null)
            {
                return ResultViewModel.Error("Empréstimo não existe!");
            }

            loan.ReturnBook();
            _context.Loans.Update(loan);
            _context.SaveChanges();

            if (loan.ReturnDate > loan.Deadline)
            {
                TimeSpan diff = loan.ReturnDate - loan.Deadline;

                int diffInDays = diff.Days;

                return ResultViewModel.Sucess("Entregue com atraso!");
            }

            return ResultViewModel.Sucess("Entregue a tempo!");
        }
    }
}
