using System;
using System.Collections.Generic;

namespace TechnologySquare.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Orders>();
        }

        public int ObjId { get; set; }
        public string UserName { get; set; }
        public string MobilePhone { get; set; }
        public string Adress { get; set; }
        public string Conname { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
