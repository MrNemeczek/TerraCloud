﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraCloud.Application.DTOs.Error
{
    public enum ErrorCode
    {
        LoginExists = 1,
        EmailExists,
        ApplicationError
    }
}
