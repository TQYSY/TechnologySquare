using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TechnologySquare.Models.AccountViewModels;

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
        public int ObjId { get; set; }
        public Product p { get; set; }
        public List<Product> Catproduct { get; set; }
        public Orders o { get; set; }
        public List<Product> PProducts { get; set; }
        public Customer co { get; set; }
        public List<Customer> COrders { get; set; }
        public string ProductName { get; set; }
        public double? Price { get; set; }
        public string Product_img { get; set; }

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
        public int ObjId { get; set; }
        public DateTime orderTime { get; set; }
        public double amount { get; set; }
        public string orderState { get; set; }
        public string productName { get; set; }
        public string name { get; set; }
        public string product_Img { get; set; }
        public DateTime transTime { get; set; }
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

    public class MemberHomeModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "当前密码")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} 必须至少包含 {2} 个字符。", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "新密码")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "确认新密码")]
        [Compare("NewPassword", ErrorMessage = "新密码和确认密码不匹配。")]
        public string ConfirmPassword { get; set; }
        //public LocalPasswordModel PassWordModel { get; set; }
        public RegisterModel CustomerInfo { get; set; }
        public List<OrderList> Orders { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }

    public class PagingInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
    }
}
