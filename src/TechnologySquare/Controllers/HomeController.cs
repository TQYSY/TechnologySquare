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


        public IActionResult Error()
        {
            return View();
        }
    }
}
