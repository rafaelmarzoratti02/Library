using Biblioteca.Models;
using Biblioteca.Persistence;
using Library.Models;
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

        if(book is null)
        {
            return NotFound();
        }

        var model = BookViewModel.FromEntity(book);
        return Ok(model);
    }

    [HttpPost]
    public ActionResult Post(CreateBookInputModel model)
    {
        var book = model.ToEntity();
        _context.Books.Add(book);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetById), new { id = book.Id}, book);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, UpdateBookInputModel model)
    { 
        var book = _context.Books.FirstOrDefault(e => e.Id == id);
        if(book is null)
        {
            return NotFound();
        }

        book.Update(model.Title, model.Autor, model.ISBN, model.AnoDePublicacao);
        _context.Books.Update(book);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        var book = _context.Books.FirstOrDefault(e => e.Id == id);
        if(book is null)
        {
            return NotFound();
        }

        book.SetAsDeleted();
        _context.Books.Update(book);
        _context.SaveChanges();

        return NoContent();
    }

}
