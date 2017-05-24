using System;
using System.Collections.Generic;

namespace TechnologySquare.Models
{
    public partial class Order
    {
        public int ObjId { get; set; }
        public int? Customermessage { get; set; }
        public int? TheProduct { get; set; }
        public int? ThePayment { get; set; }
        public DateTime? OrderTime { get; set; }
    }
}
