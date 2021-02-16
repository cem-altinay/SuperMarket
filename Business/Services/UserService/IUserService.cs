using Core.Utilities.Result;
using Core.Utilities.Security.Jwt;
using Entity.Dto;
using Entity.ModelDb;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.UserService
{
  public  interface IUserService
    {
        List<Users> TestList();
        IDataResult<LoginResponseModel> Login(LoginDto login);
    }
}
