using CRM.Models.AuthData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.Controllers
{
    [Authentication]
    public class OfficeDocumentsController : Controller
    {
        // GET: OfficeDocuments
        public ActionResult Index()
        {
            return View();
        }
    }
}