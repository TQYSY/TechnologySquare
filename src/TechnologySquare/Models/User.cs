using System;
using System.Collections.Generic;

namespace TechnologySquare.Models
{
    public partial class User
    {
        public int ObjId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string TheRole { get; set; }
    }
}
