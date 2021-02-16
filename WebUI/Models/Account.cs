using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class Account
    {
    }

    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class LoginAccessToken
    {
        public string Token { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
    }

    public class LoginResponseViewModel: BaseResponseViewModel { }
}
