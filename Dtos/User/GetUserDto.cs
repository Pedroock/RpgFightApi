using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RpgFight.Dtos.User
{
    public class GetUserDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
    }
}