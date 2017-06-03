using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnologySquare.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.AspNetCore.Http;
using TechnologySquare.Infrastructure;
using Newtonsoft.Json;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TechnologySquare.Controllers
{
    public class OrderController : Controller
    {
        private readonly TechnologySquareContext db;
        public OrderController(TechnologySquareContext _db)
        {
            db = _db;
        }

        // GET: /<controller>/
        [Authorize]
        public ActionResult Index()
        {

            return View();
        }


        
    }
}
