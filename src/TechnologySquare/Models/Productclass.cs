using System;
using System.Collections.Generic;

namespace TechnologySquare.Models
{
    public partial class Productclass
    {
        public int ObjId { get; set; }
        public int? TheProduct { get; set; }
        public int? TheProductType { get; set; }

        public virtual Product TheProductNavigation { get; set; }
        public virtual Producttype TheProductTypeNavigation { get; set; }
    }
}
