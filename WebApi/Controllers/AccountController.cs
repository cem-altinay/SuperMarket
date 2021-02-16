using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Services.UserService;
using Core.Extension;
using Entity.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _user;

        public AccountController(IUserService user)
        {
            _user = user;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDto loginRequest)
        {
            
            var token = _user.Login(loginRequest);

            if (token != null && token.Success==true)
            {
                return Ok(token.Data);
            }

            return NotFound(new ErrorDetails()
            {
                StatusCode = StatusCodes.Status404NotFound,
                Message = "Geçerisiz kullanıcı adı veya şifre"
            });

        }
    }
}
