using Microsoft.AspNetCore.Mvc;
using Library.Application.Services;
using MediatR;
using Library.Application.Queries.BookQueries.GetAllBooks;
using Library.Application.Queries.BookQueries.GetBookById;
using Library.Application.Commands.BookCommands.DeleteBook;
using Library.Application.Commands.BookCommands.InsertBook;
using Library.Application.Commands.BookCommands.UpdateBook;

namespace Biblioteca.Controllers;

[Route("api/books")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IMediator _mediator;

    public BooksController( IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _mediator.Send(new GetAllBooksCommand());

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetBookByIdCommand(id));

        if(!result.IsSucess)
        {
            return NotFound(result.Message);
        }

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult> Post(InsertBookCommand command)
    {
       var result =  await _mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
    }

    [HttpPut]
    public async Task<IActionResult> Put(UpdateBookCommand command)
    {
        var result = await  _mediator.Send(command);

        if (!result.IsSucess)
        {
            return NotFound(result.Message);
        }

        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteBookCommand(id));

        if (!result.IsSucess)
        {
            return BadRequest(result.Message);
        }

        return NoContent();
    }

}
