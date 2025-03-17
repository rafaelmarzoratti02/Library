using Library.Core.Entities;
using Library.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    public Task<User> GetById(int id)
    {
        throw new NotImplementedException();
    }
}
