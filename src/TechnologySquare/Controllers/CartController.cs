using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechnologySquare.Models;
using Microsoft.AspNetCore.Http;
using TechnologySquare.Infrastructure;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TechnologySquare.Controllers
{
    public class CartController : Controller
    {
        private readonly TechnologySquareContext db;

        public CartController(TechnologySquareContext _db)
        {
            db = _db;
        }
        // GET: /<controller>/
        public ActionResult Index()
        {
            if (Request.Query["retUrl"].ToString() != "")
            {
                ViewBag.continueBuy = Request.Query["retUrl"].ToString();
            }
            else
            {
                ViewBag.continueBuy = Request.Headers["Referer"].ToString();
            }
            ViewBag.contBuy = ViewBag.continueBuy;

            List<int[]> curCart = HttpContext.Session.GetJson<List<int[]>>("Cart");

            if (curCart == null) curCart = new List<int[]>();

            List<CartItem> cart = new List<CartItem>();

            foreach (int[] i in curCart)
            {
                int curId = i[0];
                int curQty = i[1];
                int curAccount = i[1];
                CartItem cartItem = (from p in db.Product
                                     where p.ObjId == curId
                                     select
                                         new CartItem
                                         {

                                             productName = p.Productname,
                                             description = p.Description,
                                             price = p.Price,
                                             id = p.ProductId,
                                             //qty = curQty,
                                             //smallImg = p.SmallImg
                                             amount = curAccount
                                         }).FirstOrDefault<CartItem>();
                cart.Add(cartItem);
            }

            ViewBag.cart = cart;
            return View("Cart");
        }

        public ActionResult AddCart(int id)
        {
            List<int[]> curCart = HttpContext.Session.GetJson<List<int[]>>("Cart");

            if (curCart == null)
                HttpContext.Session.SetJson("Cart", new List<int[]> { new int[] { id, 1 } });
            else
            {
                bool found = false;
                foreach (var p in curCart)
                {
                    if (p[0] == id)
                    {
                        found = true;
                        p[1] += 1;
                        break;
                    }
                }
                if (!found)
                {
                    curCart.Add(new int[] { id, 1 });
                }
                HttpContext.Session.SetJson("Cart", curCart);
            }

            return Index();
        }

        public RedirectResult deleCartRow(int id)
        {
            List<int[]> curCart = HttpContext.Session.GetJson<List<int[]>>("Cart");
            curCart.RemoveAt(id);
            HttpContext.Session.SetJson("Cart", curCart);
            return Redirect("/Cart?retUrl=" + Request.Query["retUrl"].ToString());
        }

        public RedirectResult updateCartRow(int id)
        {
            int value = int.Parse(Request.Query["value"].ToString());
            List<int[]> curCart = HttpContext.Session.GetJson<List<int[]>>("Cart");
            curCart[id][1] = value;
            HttpContext.Session.SetJson("Cart", curCart);
            return Redirect("/Cart?retUrl=" + Request.Query["retUrl"].ToString());
        }



        public IActionResult Cart()
        {
            return View();
        }
    }
}
