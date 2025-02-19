using Library.Application.Commands.LoanCommands.DeleteLoan;
using Library.Application.Commands.LoanCommands.InsertLoan;
using Library.Application.Commands.LoanCommands.ReturnBook;
using Library.Application.Models;
using Library.Application.Queries.BookQueries.GetAllBooks;
using Library.Application.Queries.BookQueries.GetBookById;
using Library.Application.Services;
using Library.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Library.API.Controllers;

[Route("api/loans")]
[ApiController]
public class LoansController : ControllerBase
{

    private readonly ILoanService _loanService;
    private readonly IMediator _mediator;

    public LoansController(ILoanService loanService, IMediator mediator)
    {
        _loanService = loanService;
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

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post(InsertLoanCommand command)
    {

        var result = await _mediator.Send(command);

        if (!result.IsSucess)
        {
            return BadRequest(result.Message);
        }

        return CreatedAtAction(nameof(GetById), new { Id = result.Data }, command);

    }

    [HttpDelete]
    public async Task <IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteLoanCommand(id));

        if (!result.IsSucess)
        {
            return BadRequest(result.Message);
        }

        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> ReturnBook(int id)
    {
        var result = await _mediator.Send(new ReturnBookCommand(id));

        if (!result.IsSucess)
        {
            return NotFound(result.Message);
        }

        return Ok(result);

    }

}
