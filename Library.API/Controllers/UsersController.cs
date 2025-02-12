using Library.Application.Models;
using Library.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Library.Application.Services;

namespace Library.API.Controllers;

[Route("api/users")]
[ApiController]
public class UsersController : ControllerBase
{

    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var result = _userService.GetAll();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var result = _userService.GetById(id);

        if (!result.IsSucess)
        {
            return NotFound(result.Message);
        }

        return Ok(result);
    }

    [HttpPost]
    public ActionResult Post(CreateUserInputModel model)
    {
        var result = _userService.Insert(model);

        return CreatedAtAction(nameof(GetById), new { Id = result.Data }, model);
    }

    [HttpPut("{id}")]
    public IActionResult Put(UpdateUserInputModel model)
    {
        var result = _userService.Update(model);

        if (!result.IsSucess)
        {
            return NotFound(result.Message);
        }

        return NoContent();
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        var result = _userService.Delete(id);

        if (!result.IsSucess)
        {
            return NotFound(result.Message);
        }

        return NoContent();
    }
}
