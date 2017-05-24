using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnologySquare.Models
{
    public class ViewModel
    {
    }

    public class HomeIndexViewModel
    {
        public List<ProductList> hotProducts { get; set; }
    }

    public class ProductList
    {
        public Product p { get; set; }
    }

    public class CartItem
    {
        public string productName { get; set; }
        public double price { get; set; }
        public string description { get; set; }
        public string id { get; set; }
        public string action { get; set; }
        public int amount { get; set; }
    }
}
