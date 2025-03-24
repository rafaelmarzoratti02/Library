using Library.Core.Entities;
using Library.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
  private readonly BooksDbContext _context;

  public UserRepository(BooksDbContext context)
  {
    _context = context;
  }

  public async Task<int> Add(User user)
  {
    await _context.Users.AddAsync(user);
    await _context.SaveChangesAsync();
    return user.Id;
  }

  public async Task<bool> Exists(int id)
  {
    return await _context.Users.AnyAsync(p => p.Id == id);
  }

  public Task<List<User>> GetAll()
  {
    throw new NotImplementedException();
  }

  public async Task<User?> GetById(int id)
  {
    return await _context.Users.SingleOrDefaultAsync(p => p.Id == id);
  }

  public Task<User?> GetDetailsById(int id)
  {
    throw new NotImplementedException();
  }

  public async Task<User> GetUserByEmailAndPasswordAsync(string email, string password)
  {
    return await _context.Users.SingleOrDefaultAsync(x => x.Email == email && x.Password == password);
  }

  public async Task Update(User user)
  {
    _context.Update(user);
    await _context.SaveChangesAsync();
  }
}
