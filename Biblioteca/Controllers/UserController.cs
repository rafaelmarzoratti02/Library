﻿using Biblioteca.Models;
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

    [HttpGet]
    public IActionResult Get()
    {
        var users = _context.Users.Where(e => !e.IsDeleted);
        var model = users.Select(e => UserViewModel.FromEntity(e));

        return Ok(model);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var user = _context.Users.SingleOrDefault(e => e.Id == id);

        if (user is null)
        {
            return NotFound();
        }

        var model = UserViewModel.FromEntity(user);
        return Ok(model);
    }

    [HttpPost]
    public ActionResult Post(CreateUserInputModel model)
    {
        var user = model.ToEntity();
        _context.Users.Add(user);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, UpdateUserInputModel model)
    {
        var user = _context.Users.FirstOrDefault(e => e.Id == id);
        if (user is null)
        {
            return NotFound();
        }

        user.Update(model.Name, model.Email, model.Birthdate);
        _context.Users.Update(user);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        var user = _context.Users.FirstOrDefault(e => e.Id == id);
        if (user is null)
        {
            return NotFound();
        }

        user.SetAsDeleted();
        _context.Users.Update(user);
        _context.SaveChanges();

        return NoContent();
    }
}
