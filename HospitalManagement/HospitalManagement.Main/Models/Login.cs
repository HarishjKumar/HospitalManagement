﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalManagement.Main.Models
{
    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string LoginBy { get; set; }
    }
}