using Library.Application.Models;
using Library.Application.Services;
using Library.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Controllers;

[Route("api/loans")]
[ApiController]
public class LoansController : ControllerBase
{

    private readonly ILoanService _loanService;

    public LoansController(ILoanService loanService)
    {
        _loanService = loanService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var result = _loanService.GetAll();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
       var result = _loanService.GetById(id);

        return Ok(result);
    }

    [HttpPost]
    public IActionResult Post(CreateLoanInputModel model)
    {

        var result = _loanService.Insert(model);

        return CreatedAtAction(nameof(GetById), new { Id = result.Data }, model);

    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        var result = _loanService.Delete(id);

        if (!result.IsSucess)
        {
            return BadRequest(result.Message);
        }

        return NoContent();
    }

    [HttpPut("{id}")]
    public IActionResult ReturnBook(int id)
    {
        var result = _loanService.ReturnBook(id);

        if (!result.IsSucess)
        {
            return NotFound(result.Message);
        }

        return Ok(result);

    }

}
