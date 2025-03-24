using Library.Application.Models;
using Library.Core.Entities;
using Library.Core.Repositories;
using Library.Core.Services;
using MediatR;

namespace Library.Application.Commands.UserCommands.InsertUser;

public class InsertUserHandler : IRequestHandler<InsertUserCommand, ResultViewModel<int>>
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthService _authService;

    public InsertUserHandler(IUserRepository userRepository, IAuthService authService)
    {
        _userRepository = userRepository;
        _authService = authService;
    }

    public async Task<ResultViewModel<int>> Handle(InsertUserCommand request, CancellationToken cancellationToken)
    {   
        var senhaHash =_authService.ComputeSha256Hash(request.Password);
        var user = request.ToEntity(senhaHash);
        var result = await _userRepository.Add(user);
        
        return ResultViewModel<int>.Sucess(result);
    }
}