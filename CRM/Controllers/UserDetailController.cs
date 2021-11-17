using CRM.Models.AuthData;
using CRM.Models.Global;
using DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.Controllers
{
    public class UserDetailController : BaseController
    {
        // GET: /UserDetail/
        [Authentication]
        public ActionResult Index()
        {
            return View();
        }


        // POST: /UserDetail/Create
        [Authentication]
        [HttpPost]
        public ActionResult Create(UserDetails obj)
        {
            string returnSms = obj._Insert("procUserDetails", obj);
            return Json(returnSms, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Login()
        {
            Session.Abandon();
            GlobalFunctions.ExpireAllCookies();
            return View();
        }

        public ActionResult CheckLogin(string UserId,string Password)
        {
            UserDetails obj = new UserDetails();
            obj.UserID = UserId;
            obj.EmailID = UserId;
            obj.Password = Password;
            DataTable dt = obj._Select("procUserDetails", "Login", obj).Tables[0];
            string msg = "";
            if (dt.Rows.Count == 0) {
                msg = "User Id or Paswword is Incorrect! Login Fail";
                Session.Abandon();
            }
            else
            {
                msg = "Success";
                GlobalFunctions.SetUsersCookies(dt);
            }
            return Json(msg);
        }
        
    }
}
