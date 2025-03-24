using Library.Application.Models;
using Library.Core.Entities;
using MediatR;

namespace Library.Application.Commands.UserCommands.InsertUser;

public class InsertUserCommand : IRequest<ResultViewModel<int>>
{
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime Birthdate { get; set; } 
    public string Password { get; set; }
    public string Role { get; set; }



    public User ToEntity(string password)
        => new(Name, Email, Birthdate,password, Role);
}