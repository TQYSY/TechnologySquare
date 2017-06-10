using System;
using System.Collections.Generic;

namespace TechnologySquare.Models
{
    public partial class PaymentType
    {
        public PaymentType()
        {
            Orders = new HashSet<Orders>();
            Payment = new HashSet<Payment>();
        }

        public int ObjId { get; set; }
        public string TypeName { get; set; }
        public string Url { get; set; }
        public string MethodName { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
        public virtual ICollection<Payment> Payment { get; set; }
    }
}
