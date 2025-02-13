using Library.Application.Models;

namespace Library.Application.Services;

public interface ILoanService
{
    ResultViewModel<List<LoanItemViewModel>> GetAll();
    ResultViewModel<LoanViewModel> GetById(int id);
    ResultViewModel<int> Insert(CreateLoanInputModel model);
    ResultViewModel Delete(int id);
    ResultViewModel ReturnBook(int id);

}

