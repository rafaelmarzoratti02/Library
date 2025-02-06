using Biblioteca.Models;
using Biblioteca.Persistence;
using Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;

[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{

    private readonly BooksDbContext _context;

    public UserController(BooksDbContext context)
    {
        _context = context;
    }

  
}
