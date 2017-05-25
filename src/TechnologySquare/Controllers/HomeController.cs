using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechnologySquare.Models;

namespace TechnologySquare.Controllers
{
    public class HomeController : Controller
    {
        private readonly TechnologySquareContext db;

        public HomeController(TechnologySquareContext phonedb)
        {
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
                pl.p = new Product { ObjId = p.ObjId, Productname = p.Productname, Price = p.Price, ProductId = p.ProductId };
                ivm.hotProducts.Add(pl);
            }
            return View(ivm);
        }
        public IActionResult Detail()
        {
            return View();
        }


        public IActionResult Error()
        {
            return View();
        }
    }
}
