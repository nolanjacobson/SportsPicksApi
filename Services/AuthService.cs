using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SportsPicksApi.Models;
using SportsPicksApi.ViewModels;

namespace AuthExample.Services
{
  public class AuthService
  {
    // private readonly IConfiguration configuration;

    // public AuthService(IConfiguration config)
    // {
    //   this.configuration = config;
    // }
    public AuthenticatedData CreateToken(User user)
    {
      var TokenKey = Environment.GetEnvironmentVariable("TOKEN_KEY");
      var expirationTime = DateTime.UtcNow.AddMinutes(30);

      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new[]
        {
            new Claim("id", user.Id.ToString()),
            new Claim("isPaying", user.isPaying.ToString()),
            new Claim("membershipExpiration", user.MembershipExpiration.ToString())
      }),
        Expires = expirationTime,
        SigningCredentials = new SigningCredentials(
               new SymmetricSecurityKey(Encoding.ASCII.GetBytes(TokenKey)),
              SecurityAlgorithms.HmacSha256Signature
          )
      };
      var tokenHandler = new JwtSecurityTokenHandler();
      var token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
      return new AuthenticatedData
      {
        Token = token,
      }; ;
    }
  }
}