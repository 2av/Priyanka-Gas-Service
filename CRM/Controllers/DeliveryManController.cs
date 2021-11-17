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
    public class DeliveryManController : Controller
    {
        // GET: DeliveryMan
        public ActionResult Index()
        {
            DeliveryMan obj = new DeliveryMan();
            return View(obj._Select("procDeliveryMan").Tables[0]);
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult SaveData(DeliveryMan obj)
        {
            string msg = obj._Insert("procDeliveryMan",obj);
            return Json(msg);
        }
    }
}