using CRM.Models.AuthData;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.Controllers
{
    [Authentication]
    public class PaymentStatusController : Controller
    {
        // GET: PaymentStatus
        public ActionResult Index()
        {

            PaymentStatus obj = new PaymentStatus();
            return View(obj._Select("procPaymentStatus").Tables[0]);
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult SaveData(PaymentStatus obj)
        {
            string msg = obj._Insert("procPaymentStatus", obj);
            return Json(msg);
        }
    }
}