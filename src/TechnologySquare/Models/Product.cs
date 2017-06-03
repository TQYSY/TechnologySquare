using System;
using System.Collections.Generic;

namespace TechnologySquare.Models
{
    public partial class Product
    {
        public int ObjId { get; set; }
        public string Productname { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ProductId { get; set; }
        public string Product_img { get; set; }
    }
}
