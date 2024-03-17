using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraCloud.Application.Exceptions.Auth
{
    public sealed class EmailExistsException : Exception
    {
        public EmailExistsException(string email) : base($"Email: {email} exists!")
        {           
        }
    }
}
