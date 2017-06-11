using System;
using System.Collections.Generic;

namespace TechnologySquare.Models
{
    public partial class Product
    {
        public Product()
        {
            Orders = new HashSet<Orders>();
            Productclass = new HashSet<Productclass>();
        }

        public int ObjId { get; set; }
        public string Productname { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ProductId { get; set; }
        public string Product_Img { get; set; }
        public int? ProductState { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
        public virtual ICollection<Productclass> Productclass { get; set; }
    }
}
