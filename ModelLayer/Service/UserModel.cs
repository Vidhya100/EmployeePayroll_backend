﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer.Service
{
    public class UserModel
    {
        public int UserId { get; set; } 
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
