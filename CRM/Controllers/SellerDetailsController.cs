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
    public class SellerDetailsController : BaseController
    {
        // GET: SellerDetails
        public ActionResult Index()
        {
            SellerDetails sellerDetails = new SellerDetails();
            return View(sellerDetails._Select("procSellerDetails").Tables[0]);
        }
        public ActionResult Create()
        {
            SellerDetails sellerDetails = new SellerDetails();
            int ID = Convert.ToInt32(RouteData.Values["id"]);
            if (ID > 0)
            {
                sellerDetails.ID = ID;
                DataTable dt = sellerDetails._Select("procSellerDetails", Common.Action_Select, sellerDetails).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    sellerDetails.FirstName = Convert.ToString(dt.Rows[0]["FirstName"]);
                    sellerDetails.LastName = Convert.ToString(dt.Rows[0]["LastName"]);
                    sellerDetails.Address = Convert.ToString(dt.Rows[0]["Address"]);
                    sellerDetails.PhoneNo = Convert.ToString(dt.Rows[0]["PhoneNo"]);
                    sellerDetails.AlternateNo = Convert.ToString(dt.Rows[0]["AlternateNo"]);
                    sellerDetails.CompanyName = Convert.ToString(dt.Rows[0]["CompanyName"]);
                    
                }
            }
            return View(sellerDetails);

        }
        public ActionResult SaveData(SellerDetails obj)
        {
            string msg = string.Empty;
            if (obj.ID > 0)
            {
                msg = obj._Update("procSellerDetails", obj);
            }
            else
            {
                msg= obj._Insert("procSellerDetails", obj);
            }
            
            return Json(msg);
        }
        
    }
}