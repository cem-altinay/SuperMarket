using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.UserService
{
    public interface IUserInfoService
    {
        int UserId { get; }
        int UserFullName { get; }
    }
}
