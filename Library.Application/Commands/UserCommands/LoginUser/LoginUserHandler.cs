using Library.Application.Models;
using Library.Core.Repositories;
using Library.Core.Services;
using MediatR;

namespace Library.Application.Commands.UserCommands.LoginUser;

public class LoginUserHandler : IRequestHandler<LoginUserCommand,ResultViewModel<LoginUserViewModel>>
{
    private readonly IUserRepository _userRepository; 
    private readonly IAuthService  _authService;

    public LoginUserHandler(IUserRepository userRepository, IAuthService authService)
    {
        _userRepository = userRepository;
        _authService = authService;
    }

    public async Task<ResultViewModel<LoginUserViewModel>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var passworhHash = _authService.ComputeSha256Hash(request.Senha);
        var user = await _userRepository.GetUserByEmailAndPasswordAsync(request.Email, passworhHash);

        if (user is null)
        {
            return ResultViewModel<LoginUserViewModel>.Error("Usuário ou senha inválidos!");
        }
        var token = _authService.GenerateJWTToken(user.Email, user.Role);

        var model = new LoginUserViewModel(user.Email, token);

        return ResultViewModel<LoginUserViewModel>.Sucess(model);
    }
}