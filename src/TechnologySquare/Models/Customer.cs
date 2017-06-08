using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TechnologySquare.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Order = new HashSet<Order>();
        }
        public int ObjId { get; set; }
        public string MobilePhone { get; set; }
        [Display(Name = "移动电话")]
        public string UserName { get; set; }
        [Display(Name = "用户名")]
        public string Adress { get; set; }
        [Display(Name = "详细地址")]
        public string Conname { get; set; }
        [Display(Name = "收货人姓名")]

        public virtual ICollection<Order> Order { get; set; }
    }
}
