using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using TechnologySquare.Models;
using TechnologySquare.Models.AccountViewModels;
using TechnologySquare.Services;
using TechnologySquare.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace TechnologySquare.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ISmsSender _smsSender;
        private readonly ILogger _logger;
        private readonly TechnologySquareContext db;

        public HomeController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender,
            ISmsSender smsSender,
            ILoggerFactory loggerFactory,
            TechnologySquareContext phonedb)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _smsSender = smsSender;
            _logger = loggerFactory.CreateLogger<HomeController>();
            db = phonedb;
        }

        public IActionResult Index()
        {
            HomeIndexViewModel ivm = new HomeIndexViewModel();
            ivm.hotProducts = new List<ProductList>();

            var hotProducts = db.Product.Where<Product>(m => m.ObjId > 0).OrderBy<Product, float>(m => (float)m.Price).Take<Product>(6);
            foreach (var p in hotProducts)
            {
                ProductList pl = new ProductList();
                pl.p = new Product { ObjId = p.ObjId, Productname = p.Productname, Price = p.Price, ProductId = p.ProductId, Product_Img = p.Product_Img };
                ivm.hotProducts.Add(pl);
            }
            return View(ivm);
        }
        public IActionResult Detail(int id)
        {
            ProductList pl = new ProductList();
            pl.p = db.Product.Single<Product>(m => m.ObjId == id);

            return View(pl);
        }
        public IActionResult Browse(int typeId, string typeName)
        {
            ViewBag.catalogName = typeName;

            List<ProductCat> productCats = new List<ProductCat>();
            List<ProductList> hotProducts = new List<ProductList>();
            foreach (var pt in db.Producttype.Where<Producttype>(m => m.ObjId > 0).GroupBy<Producttype, string>(m => m.Type))
            {
                ProductCat pc = new ProductCat();
                pc.typeName = pt.Key;
                pc.types = new List<Producttype>();
                foreach (var p in pt)
                {
                    pc.types.Add(new Producttype { ObjId = p.ObjId, Type = p.Type, ClassType = p.ClassType });
                }
                productCats.Add(pc);
            }
            var products = from p in db.Product where p.ProductState == 1 && (from t in db.Productclass where t.TheProductType == typeId select t.TheProduct).Contains(p.ObjId) select p;
            foreach (var p in products)
            {
                ProductList p1 = new ProductList();
                p1.p = new Product { ObjId = p.ObjId, Productname = p.Productname, Product_Img = p.Product_Img, Price = p.Price };
                hotProducts.Add(p1);
            }
            ViewBag.productCats = productCats;
            ViewBag.catProducts = hotProducts;
            ViewBag.contBuy = Request.Path + Request.QueryString;
            return View();
        }

        [Authorize]
        public ActionResult MemberHome(int page = 1, int pageSize = 3)
        {
            ViewBag.pwdDisp = "none";
            string[] orderStates = { "初始", "已付款"};
            string curName = User.Identity.Name;
            MemberHomeModel mhm = new MemberHomeModel();
            mhm.Orders = new List<OrderList>();
            //var Orders = db.Orders.Where<Orders>(m => m.Customermessage = db.Customer.SingleOrDefault(n => n.UserName == curName).ObjId);
            //var theCustomerId = db.Customer.SingleOrDefault(u => u.UserName == curName).ObjId;
            //foreach (var p in Orders)
            //{
            //    OrderList ol = new OrderList();
            //    ol = new OrderList { ObjId = p.}
            //}

            Customer c = db.Customer.Single(m => m.UserName == curName);

            int custId = ViewBag.uid = c.ObjId;
            mhm.CustomerInfo = new RegisterModel { Email = c.UserName, Conname = c.Conname, Adress = c.Adress, MobilePhone = c.MobilePhone };
            var orderlist = from a in db.Orders
                            where a.OrderState < 6 && a.Customermessage == custId
                            join b in db.Product on a.TheProduct equals b.ObjId
                            //join p in db.Payment on a.ThePayment equals p.ObjId
                            join d in db.Customer on a.Customermessage equals d.ObjId
                            //orderby a.OrderTime descending
                            select new
                            {
                                name = d.Conname,
                                orderTime = a.OrderTime,
                                //amount = p.Amount,
                                orderState = (int)(a.OrderState),
                                productName = b.Productname,
                                product_Img = b.Product_Img,
                                //transTime = p.TransTime
                            };
            //var orders = orderlist.Skip((page - 1) * pageSize).Take(pageSize);
            foreach (var o in orderlist)
            {
                mhm.Orders.Add(new OrderList
                {
                    name = o.name,
                    orderTime = o.orderTime == null ? default(DateTime) : o.orderTime.Value,
                    orderState = orderStates[o.orderState],
                    productName = o.productName,
                    product_Img = o.product_Img
                    //amount = (double)(o.amount)
                });
            }


            //foreach (var o in orderlist)
            //{
            //    mhm.Orders.Add(new OrderList
            //    {
            //        name = o.name,
            //        orderTime = o.orderTime == null ? default(DateTime) : o.orderTime.Value,
            //        amount = (double)(o.amount),
            //        orderState = orderStates[o.orderState],
            //        productName = o.productName,
            //        product_Img = o.product_Img,
            //        transTime = o.transTime == null ? default(DateTime) : o.transTime.Value
            //    });
            //}

            //foreach (var o in orders)
            //{
            //    mhm.Orders.Add(new OrderList
            //    {
            //        name = o.name,
            //        orderTime = o.orderTime == null ? default(DateTime) : o.orderTime.Value,
            //        amount = (double)(o.amount),
            //        orderState = orderStates[o.orderState],
            //        productName = o.productName,
            //        product_Img = o.product_Img,
            //        transTime = o.transTime == null ? default(DateTime) : o.transTime.Value
            //    });
            //}
            //mhm.PagingInfo = new PagingInfo { CurrentPage = page, ItemsPerPage = pageSize, TotalItems = orderlist.Count() };
            return View("MemberHome", mhm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> MemberHome(MemberHomeModel mhm, int page = 1, int pageSize = 3)
        {
            ViewBag.pwdDisp = "block";

            string curUser = User.Identity.Name;
            var c = await _userManager.FindByNameAsync(curUser);
            Customer cust = db.Customer.Single(m => m.UserName == curUser);
            int custId = ViewBag.uid = cust.ObjId;
            IdentityResult r = await _userManager.ChangePasswordAsync(c, mhm.OldPassword, mhm.NewPassword);
            if (r.Succeeded)
            {
                ViewBag.pwdDisp = "none";
            }
            else
            {
                await Response.WriteAsync("<script>alert('密码更新失败！');</script>");
            }

            string[] orderStates = { "初始", "已付款" };
            mhm.Orders = new List<OrderList>();
            mhm.CustomerInfo = new RegisterModel { Email = cust.UserName, Conname = cust.Conname, MobilePhone = cust.MobilePhone, Adress = cust.Adress };
            var orderlist = from a in db.Orders
                            where a.OrderState < 6 && a.Customermessage == custId
                            join b in db.Product on a.TheProduct equals b.ObjId
                            //join p in db.Payment on a.ThePayment equals p.ObjId
                            join d in db.Customer on a.Customermessage equals d.ObjId
                            //orderby a.OrderTime descending
                            select new
                            {
                                name = d.Conname,
                                orderTime = a.OrderTime,
                                //amount = p.Amount,
                                orderState = (int)(a.OrderState),
                                productName = b.Productname,
                                product_Img = b.Product_Img
                                //transTime = p.TransTime
                            };
            //var orders = orderlist.Skip((page - 1) * pageSize).Take(pageSize);
            foreach (var o in orderlist)
            {
                mhm.Orders.Add(new OrderList
                {
                    name = o.name,
                    orderTime = o.orderTime == null ? default(DateTime) : o.orderTime.Value,
                    orderState = orderStates[o.orderState],
                    productName = o.productName,
                    product_Img = o.product_Img
                    //amount = (double)(o.amount)
                });
            }
            //var orderlist = from a in db.Orders
            //                where a.OrderState < 6 && a.Customermessage == custId
            //                join b in db.Product on a.TheProduct equals b.ObjId
            //                join p in db.Payment on a.ThePayment equals p.ObjId
            //                join d in db.Customer on a.Customermessage equals d.ObjId
            //                orderby a.OrderTime descending
            //                select new
            //                {
            //                    name = d.Conname,
            //                    orderTime = a.OrderTime,
            //                    amount = p.Amount,
            //                    orderState = (int)(a.OrderState),
            //                    productName = b.Productname,
            //                    product_Img = b.Product_Img,
            //                    transTime = p.TransTime
            //                };

            //foreach (var o in orderlist)
            //{
            //    mhm.Orders.Add(new OrderList
            //    {
            //        name = o.name,
            //        orderTime = o.orderTime == null ? default(DateTime) : o.orderTime.Value,
            //        amount = (double)(o.amount),
            //        orderState = orderStates[o.orderState],
            //        productName = o.productName,
            //        product_Img = o.product_Img,
            //        transTime = o.transTime == null ? default(DateTime) : o.transTime.Value
            //    });
            //}

            //var orders = orderlist.Skip((page - 1) * pageSize).Take(pageSize);
            //foreach (var o in orders)
            //{
            //    mhm.Orders.Add(new OrderList
            //    {
            //        name = o.name,
            //        orderTime = o.orderTime == null ? default(DateTime) : o.orderTime.Value,
            //        amount = (double)(o.amount),
            //        orderState = orderStates[o.orderState],
            //        productName = o.productName,
            //        product_Img = o.product_Img,
            //        transTime = o.transTime == null ? default(DateTime) : o.transTime.Value

            //    });
            //}
            //mhm.PagingInfo = new PagingInfo { CurrentPage = page, ItemsPerPage = pageSize, TotalItems = orderlist.Count() };


            return View("MemberHome", mhm);
        }

        public async void updateMemberInfo(int memberId, string memberConname, string memberMobile, string memberAdress)
        {
            Customer c = db.Customer.Single(m => m.ObjId == memberId);
            c.Conname = memberConname;
            c.MobilePhone = memberMobile;
            c.Adress = memberAdress;
            int result = db.SaveChanges();

            Response.ContentType = "text/plain";
            await Response.WriteAsync(result.ToString());
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
