using CRM.Models.AuthData;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.Controllers
{
    [Authentication]
    public class DashboardController : BaseController
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            Dashboard obj = new Dashboard();
            return View(obj._Select("procDashboard").Tables[0]);
        }
    }
}