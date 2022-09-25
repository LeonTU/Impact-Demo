using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;

namespace API.Interface
{
  public interface IAuthRepository
  {
    // return a token contains userId
    Task<AuthDto> Login(string userName);
  }
}
