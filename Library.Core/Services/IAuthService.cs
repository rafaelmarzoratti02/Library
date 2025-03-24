using Library.Core.Entities;

namespace Library.Core.Services;

public interface IAuthService
{
    string GenerateJWTToken(string email, string role);

    string ComputeSha256Hash(string password);

}