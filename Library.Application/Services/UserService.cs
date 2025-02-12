using Library.Application.Models;
using Library.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Services;

public class UserService : IUserService
{

    private readonly BooksDbContext _context;

    public UserService(BooksDbContext context)
    {
        _context = context;
    }

    public ResultViewModel<List<UserViewModel>> GetAll()
    {
        var users = _context.Users
            .Include(e => e.Loans)
            .ThenInclude(e => e.Book)
            .Where(e => !e.IsDeleted);

        var model = users.Select(e => UserViewModel.FromEntity(e)).ToList();

        return ResultViewModel<List<UserViewModel>>.Sucess(model);
    }

    public ResultViewModel<UserViewModel> GetById(int id)
    {
        var user = _context.Users.SingleOrDefault(e => e.Id == id);

        if (user is null)
        {
            return ResultViewModel<UserViewModel>.Error("Usuário não existe!");
        }

        var model = UserViewModel.FromEntity(user);


        return ResultViewModel<UserViewModel>.Sucess(model);
    }

    public ResultViewModel<int> Insert(CreateUserInputModel model)
    {
        var user = model.ToEntity();

        _context.Users.Add(user);
        _context.SaveChanges();

        return ResultViewModel<int>.Sucess(user.Id);
    }

    public ResultViewModel Update(UpdateUserInputModel model)
    {
        var user = _context.Users.FirstOrDefault(e => e.Id == model.IdUser);

        if (user is null)
        {
            return ResultViewModel.Error("Usuário não existe");
        }

        user.Update(model.Name, model.Email, model.Birthdate);
        _context.Users.Update(user);
        _context.SaveChanges();

        return ResultViewModel.Sucess();
    }

    public ResultViewModel Delete(int id)
    {
        var user = _context.Users.FirstOrDefault(e => e.Id == id);

        if (user is null)
        {
            return ResultViewModel.Error("Usuário não existe!");
        }

        user.SetAsDeleted();
        _context.Users.Update(user);
        _context.SaveChanges();

        return ResultViewModel.Sucess();
    }
}
