using Library.Application.Models;
using Library.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Controllers;

[Route("api/loans")]
[ApiController]
public class LoansController : ControllerBase
{
    private readonly BooksDbContext _context;

    public LoansController(BooksDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var loans = _context.Loans
         .Include(e => e.User)
         .Include(e => e.Book)
         .Where(e => !e.IsDeleted);
        ;

        var model = loans.Select(e => LoanItemViewModel.FromEntity(e));

        return Ok(model);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var loan = _context.Loans
            .Include(e => e.User)
            .Include(e => e.Book)
           .FirstOrDefault(e => e.Id == id);

        if (loan is null)
        {
            return NotFound();
        }

        var model = LoanViewModel.FromEntity(loan);
        return Ok(model);
    }

    [HttpPost]
    public IActionResult Post(CreateLoanInputModel model)
    {
        var loan = model.ToEntity();

        _context.Loans.Add(loan);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetById), new { id = loan.Id }, model);

    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        var loan = _context.Loans.FirstOrDefault(e => e.Id == id);

        if (loan is null)
        {
            return NotFound();
        }

        loan.SetAsDeleted();
        _context.Loans.Update(loan);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpPut("{id}")]
    public IActionResult ReturnBook(int id)
    {
        var loan = _context.Loans.FirstOrDefault(e => e.Id == id);
        if (loan is null)
        {
            return NotFound();
        }

        loan.ReturnBook();
        _context.Loans.Update(loan);
        _context.SaveChanges();

        if (loan.ReturnDate > loan.Deadline)
        {
            TimeSpan diff = loan.ReturnDate - loan.Deadline;

            int diffInDays = diff.Days;

            return Ok($"Atrasado em {diffInDays}!");
        }

        return Ok("Entregue no tempo!");

    }


}
