﻿
using Entity.ModelDb;

namespace Core.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(Users user);
    }
}
