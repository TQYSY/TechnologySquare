using System;
using System.Collections.Generic;

namespace TechnologySquare.Models
{
    public partial class Producttype
    {
        public Producttype()
        {
            Productclass = new HashSet<Productclass>();
        }

        public int ObjId { get; set; }
        public string Type { get; set; }
        public string ClassType { get; set; }

        public virtual ICollection<Productclass> Productclass { get; set; }
    }
}
