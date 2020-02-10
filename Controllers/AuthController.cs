using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AuthExample.Services;
using SportsPicksApi.Models;
using SportsPicksApi.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace AuthExample.Controllers
{
  [Route("auth")]
  [EnableCors]
  [ApiController]
  public class AuthController : ControllerBase
  {
    private readonly DatabaseContext db;

    public AuthController(DatabaseContext context)
    {
      this.db = context;
    }

    [HttpPost("signup")]
    public async Task<ActionResult> SignUpUser(NewUserModel userData)
    {
      var existingUserEmail = await this.db.Users.FirstOrDefaultAsync(f => f.Email.ToLower() == userData.Email.ToLower());
      if (existingUserEmail != null)
      {
        return BadRequest(new { Message = "email address is already exists" });
      }

      var user = new User
      {
        Id = 0,
        Email = userData.Email.ToLower(),
        FullName = userData.FullName,
        HashedPassword = ""
      };

      var hashed = new PasswordHasher<User>().HashPassword(user, userData.Password);
      user.HashedPassword = hashed;

      this.db.Users.Add(user);
      await this.db.SaveChangesAsync();
      var rv = new AuthService().CreateToken(user);
      return Ok(rv);
    }


    [HttpPost("login")]
    public async Task<ActionResult> LoginUser(LoginViewModel loginData)
    {
      var user = await this.db.Users.FirstOrDefaultAsync(f => f.Email.ToLower() == loginData.Email.ToLower());
      if (user == null)
      {
        return BadRequest(new { Message = "User does not exist" });
      }

      var verificationResult = new PasswordHasher<User>().VerifyHashedPassword(user, user.HashedPassword, loginData.Password);

      if (verificationResult == PasswordVerificationResult.Success)
      {
        var rv = new AuthService().CreateToken(user);
        return Ok(rv);
      }
      else
      {
        return BadRequest(new { message = "Wrong password" });
      }
    }
    [HttpPut("Update/{id}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public async Task<ActionResult> UpdateUser(int id, User updatedUser)
    {
      var user = await this.db.Users.FirstOrDefaultAsync(f => f.Id == id);
      if (user == null)
      {
        return BadRequest(new { Message = "User does not exist" });
      }

      else
      {
        user.Email = user.Email;
        user.FullName = user.FullName;
        user.HashedPassword = user.HashedPassword;
        user.isPaying = updatedUser.isPaying;
        user.MembershipExpiration = updatedUser.MembershipExpiration;
        await this.db.SaveChangesAsync();
        var rv = new AuthService().CreateToken(user);
        return Ok(rv);
      }

    }
    [HttpPut("update/password")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public async Task<ActionResult> UpdatePassword(User updatedUser, string prevPassword)
    {
      var user = await this.db.Users.FirstOrDefaultAsync(f => f.Email.ToLower() == updatedUser.Email.ToLower());
      if (user == null)
      {
        return BadRequest(new { Message = "User does not exist" });
      }

      var verificationResult = new PasswordHasher<User>().VerifyHashedPassword(user, user.HashedPassword, prevPassword);

      if (verificationResult == PasswordVerificationResult.Success)
      {
        user.HashedPassword = "";
        var hashed = new PasswordHasher<User>().HashPassword(user, updatedUser.HashedPassword);
        user.HashedPassword = hashed;
        await this.db.SaveChangesAsync();
        var rv = new AuthService().CreateToken(user);
        return Ok(rv);
      }

      else
      {
        return BadRequest();
      }

    }
  }
}