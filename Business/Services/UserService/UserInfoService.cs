using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Business.Services.UserService
{
  public  class UserInfoService :IUserInfoService
    {
        private readonly IHttpContextAccessor _accessor;

        public UserInfoService(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public int UserId
        {
            get
            {
                var claim = GetClaim(ClaimTypes.NameIdentifier);
                if (!string.IsNullOrEmpty(claim))
                {
                    return Convert.ToInt32(claim);
                }

                return 0;
            }
        }

        public int UserFullName
        {
            get
            {
                var claim = GetClaim(ClaimTypes.Name);
                if (!string.IsNullOrEmpty(claim))
                {
                    return Convert.ToInt32(claim);
                }

                return 0;
            }
        }


        public string GetClaim(string claimType)
        {
            if (this.IsAuthenticated())
                foreach (var item in _accessor.HttpContext.User.Claims)
                    if (item.Type == claimType)
                        return item.Value;
            return string.Empty;
        }

        public bool IsAuthenticated()
        {
            if (_accessor.HttpContext != null && _accessor.HttpContext.User != null && _accessor.HttpContext.User.Identity != null)
            {
                return _accessor.HttpContext.User.Identity.IsAuthenticated;
            }

            return false;
        }

    }
}
