﻿using DatabaseLayer.ViewModels.Users;
using DataBaseLayer.Models.Users;
using System;
using System.Collections.Generic;

namespace Auth.Models
{
    public class AuthResult
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public bool Expire { get; set; }
        public List<Permission> Permissions { get; set; }
        public List<Permission> UnavailablePermissions { get; set; }
        public object User { get; set; }
    }
}
