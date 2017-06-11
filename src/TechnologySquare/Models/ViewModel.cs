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

    public class ProductCat
    {
        public string typeName { get; set; }
        public List<Producttype> types { get; set; }
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

    public class OrderList
    {
        public DateTime orderTime { get; set; }
        public string orderState { get; set; }
        public string productName { get; set; }
        public string name { get; set; }
    }

    public class OrderInfo
    {
        public double price { get; set; }
        public int theProduct { get; set; }
        public string productName { get; set; }
    }

    public class OrderViewModel
    {
        public Customer curCustomer { get; set; }
        public Payment payment { get; set; }
        public List<OrderInfo> orders { get; set; }
        public int orderQty { get; set; }
    }

    public class PayRequestInfo
    {
        public string PostUrl { get; set; }
        public string MerId { get; set; }
        public string Amt { get; set; }
        public string PaymentTypeObjId { get; set; }
        public string MerTransId { get; set; }
        public string ReturnUrl { get; set; }
        public string CheckValue { get; set; }

    }

}
