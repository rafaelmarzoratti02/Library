using Library.Application.Models;

namespace Library.Application.Services;

public interface IUserService
{
    ResultViewModel<List<UserViewModel>> GetAll();
    ResultViewModel<UserViewModel> GetById(int id);
    ResultViewModel<int> Insert(CreateUserInputModel model);
    ResultViewModel Update(UpdateUserInputModel model);
    ResultViewModel Delete(int id);

}
