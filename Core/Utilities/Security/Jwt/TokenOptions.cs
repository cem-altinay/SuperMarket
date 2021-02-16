using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Jwt
{
    public class TokenOptions
    {
        public string Audience { get; set; } = "www.myapi.com";
        public string Issuer { get; set; } = "www.mysite.com";
        public int AccessTokenExpiration { get; set; } = 10;
        public string SecurityKey { get; set; } = "mysecretkeymysecretkey";
    }
}
