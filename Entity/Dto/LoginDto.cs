﻿using Entity.ModelDb;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Dto
{
    public class LoginDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class LoginResponseModel
    {

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
    }
}
