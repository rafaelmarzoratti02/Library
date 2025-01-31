using Biblioteca.Models;
using Biblioteca.Persistency;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers;

[Route("api/books")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly BooksDbContext _context;

    public BooksController(BooksDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Get()
    {   
        var books = _context.Books.Where(e => !e.IsDeleted);
        var model = books.Select(e=> BookItemViewModel.FromEntity(e));

        return Ok(model);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var book = _context.Books.SingleOrDefault(e => e.Id == id);
        var model = BookViewModel.FromEntity(book);
        return Ok(model);
    }

    [HttpPost]
    public ActionResult Post(CreateBookInputModel model)
    {
        return CreatedAtAction(nameof(GetById), new { id = 1}, model);
    }


}
