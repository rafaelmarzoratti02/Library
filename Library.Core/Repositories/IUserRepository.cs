using Library.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Repositories;

public interface IUserRepository
{
    Task<List<User>> GetAll();
    Task<User?> GetDetailsById(int id);
    Task<User?> GetById(int id);
    Task<int> Add(User user);
    Task<bool> Exists(int id);
    Task Update(User user);
    Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash);
}
