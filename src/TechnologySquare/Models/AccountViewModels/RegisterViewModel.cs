using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechnologySquare.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "邮箱")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0}长度至少为{2}且最大为{1}个字符长。", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "确认密码")]
        [Compare("Password", ErrorMessage = "密码和确认密码不一致.")]
        public string ConfirmPassword { get; set; }


    }

    public class RegisterModel
    {
        //[Display(Name = "用户名")]
        //public string UserName { get; set; }

        [Display(Name = "真实姓名")]
        public string Conname { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} 必须至少包含 {2} 个字符。", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "确认密码")]
        [Compare("Password", ErrorMessage = "密码和确认密码不匹配。")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email地址格式不正确.")]
        [Display(Name = "电子邮箱")]
        public string Email { get; set; }

        [RegularExpression(@"^1\d{10}$", ErrorMessage = "移动电话号码不符合格式.")]
        [Display(Name = "移动电话")]
        public string MobilePhone { get; set; }

        [Display(Name = "地址")]
        public string Adress { get; set; }
    }
}
