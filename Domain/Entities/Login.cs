﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Login
    {
        //[Required]
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
