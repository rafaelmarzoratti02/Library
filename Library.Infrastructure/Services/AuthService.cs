﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Library.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Library.Infrastructure.Services;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;

    public AuthService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateJWTToken(string email, string role)
    {
        var issuer = _configuration["Jwt:Issuer"];
        var audience = _configuration["Jwt:Audience"];
        var key = _configuration["Jwt:Key"];

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim("Username",email),
            new Claim(ClaimTypes.Role, role) 
        };

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience, 
            expires: DateTime.Now.AddHours(8), 
            signingCredentials: credentials, 
            claims: claims);

        var tokenHandler = new JwtSecurityTokenHandler();

        var stringToken = tokenHandler.WriteToken(token);

        return stringToken;         
    }

    public string ComputeSha256Hash(string password)
    {
        using (SHA256 sha256Hash = SHA256.Create())//Inicializando o método do sha256 Create
        {
            //ComputeHash - retorna byte array
            var bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));


            //Converte byte array para string
            var builder = new StringBuilder();//concatenação de string


            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));// 2x faz com que sseja convertido em representação hexadecimal
            }


            return builder.ToString();
        }
    }
}