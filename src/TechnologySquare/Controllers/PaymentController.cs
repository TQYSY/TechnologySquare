using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechnologySquare.Models;
using TechnologySquare.Infrastructure;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TechnologySquare.Controllers
{
    public class PaymentController : Controller
    {
        private readonly TechnologySquareContext db;
        public PaymentController(TechnologySquareContext _db)
        {
            db = _db;
        }
        // GET: /<controller>/
        public ActionResult Index()
        {
            string merId, amt, merTransId, transId, transTime;
            int paymentTypeObjId = int.Parse(Request.Form["paymentTypeObjId"]);
            PaymentType paymentMethod = db.PaymentType.Single(m => m.ObjId == paymentTypeObjId);
            //这里要根据paymentMethod的值构造验证类的实例，然后调用其验证方法。以下写法为暂时的，无扩展性。    
            if (RemotePost.PaymentVerify(Request, out merId, out amt, out merTransId, out transId, out transTime) && merId == "Flower001")
            {
                Payment pay = db.Payment.Single(m => m.ObjId == int.Parse(merTransId));
                Order[] orders = db.Order.Where(m => m.ThePayment == int.Parse(merTransId)).ToArray<Order>();
                pay.TransTime = DateTime.Parse(transTime);
                pay.TransNo = transId;
                foreach (Order or in orders)
                {
                    or.OrderState = 1;
                }
                db.SaveChanges();
                ViewBag.paymentMsg = "付款成功！     付款号：" + merTransId.ToString() + "；   金额：" + amt.ToString() + "元。";//付款成功！显示付款信息作为测试。
            }
            return View();
        }
    }
}
