using Microsoft.AspNetCore.Mvc;
using Library.Application.Models;
using Library.Infrastructure.Persistence;
using Library.Application.Services;

namespace Biblioteca.Controllers;

[Route("api/books")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly BooksDbContext _context;
    private readonly IBookService _bookService;

    public BooksController(BooksDbContext context, IBookService bookService)
    {
        _context = context;
        _bookService = bookService;
    }

    [HttpGet]
    public IActionResult Get()
    {   
        var result = _bookService.GetAll(); 

        return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var result = _bookService.GetById(id);

        if(!result.IsSucess)
        {
            return NotFound(result.Message);
        }

        return Ok(result);
    }

    [HttpPost]
    public ActionResult Post(CreateBookInputModel model)
    {
       var result = _bookService.Insert(model);

        return CreatedAtAction(nameof(GetById), new { id = result.Data }, model);
    }

    [HttpPut]
    public IActionResult Put(UpdateBookInputModel model)
    {
        var result = _bookService.Update(model);

        if (!result.IsSucess)
        {
            return NotFound(result.Message);
        }

        return NoContent();
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        var result =_bookService.Delete(id);
        if (!result.IsSucess)
        {
            return BadRequest(result.Message);
        }

        return NoContent();
    }

}
