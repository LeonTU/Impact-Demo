using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.Dtos;
using API.Interface;
using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace API.Repository
{
  public class AuthRepository : IAuthRepository
  {
    private readonly PostgresDbContext _context;
    private readonly IConfiguration _config;

    public AuthRepository(PostgresDbContext context, IConfiguration config)
    {
      _config = config;
      _context = context;
    }

    public async Task<AuthDto> Login(string userName)
    {
      var user = await _context.Users.FirstOrDefaultAsync(u => u.FullName.ToLower() == userName.ToLower());
      var userId = "";

      if (user == null)
      {
        userId = Guid.NewGuid().ToString();
        _context.Users.Add(new User
        {
          Id = userId,
          FullName = userName
        });
        await _context.SaveChangesAsync();
      }
      else
      {
        userId = user.Id;
      }

      var token = CreateToken(userId);
      return new AuthDto
      {
        Token = token,
        UserName = userName
      };
    }

    private string CreateToken(string userId)
    {
      List<Claim> claims = new List<Claim> {
        new Claim("UserId", userId),
      };

      SymmetricSecurityKey key = new SymmetricSecurityKey(
        Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value)
      );

      SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

      SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(claims),
        Expires = DateTime.Now.AddDays(30),
        SigningCredentials = creds
      };

      JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
      SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

      return tokenHandler.WriteToken(token);
    }
  }
}
