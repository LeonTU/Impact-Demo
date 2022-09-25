using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class AuthController : ControllerBase
  {
    private readonly IAuthRepository _repo;
    public AuthController(IAuthRepository repo)
    {
      _repo = repo;
    }

    [HttpPost("login/{userName}")]
    public async Task<ActionResult<AuthDto>> UserLogin(string userName)
    {
      if (string.IsNullOrWhiteSpace(userName))
      {
        return BadRequest();
      }

      var authDto = await _repo.Login(userName.Trim());
      return Ok(authDto);
    }
  }
}
