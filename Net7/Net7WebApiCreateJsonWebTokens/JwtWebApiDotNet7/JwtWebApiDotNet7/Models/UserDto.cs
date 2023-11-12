using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtWebApiDotNet7.Models
{
    public class UserDto
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
    }
}