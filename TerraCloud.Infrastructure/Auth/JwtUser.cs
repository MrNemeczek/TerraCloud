﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraCloud.Infrastructure.Auth
{
    public class JwtUser
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
    }
}
