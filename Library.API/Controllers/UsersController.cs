using Library.Application.Commands.UserCommands.InsertUser;
using Library.Application.Commands.UserCommands.LoginUser;
using Library.Application.Models;
using Library.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Library.Application.Services;
using MediatR;

namespace Library.API.Controllers;

[Route("api/users")]
[ApiController]
public class UsersController : ControllerBase
{

    private readonly IUserService _userService;
    private readonly IMediator _mediator;

    public UsersController(IUserService userService, IMediator mediator)
    {
        _userService = userService;
        _mediator = mediator;
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
    public async Task<ActionResult> Post(InsertUserCommand command)
    {
        var result = await _mediator.Send(command);
        
        return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
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

    [HttpPut("login")]
    public async Task<IActionResult> Login(LoginUserCommand command)
    {
        var result = await _mediator.Send(command);

        if (!result.IsSucess)
        {
            return NotFound(result.Message);
        }

        return Ok(result);
    }
}
