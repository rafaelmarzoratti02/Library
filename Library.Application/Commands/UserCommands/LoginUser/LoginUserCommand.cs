using Azure;
using Library.Application.Models;
using MediatR;

namespace Library.Application.Commands.UserCommands.LoginUser;

public class LoginUserCommand : IRequest<ResultViewModel<LoginUserViewModel>>
{
    public string Email { get; set; }
    public string Senha { get; set; }

}