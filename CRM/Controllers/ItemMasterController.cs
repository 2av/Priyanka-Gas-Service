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
    public class ItemMasterController : Controller
    {
        // GET: ItemMaster
        ItemMaster objCity = new ItemMaster();
        public ActionResult Index()
        {
            return View(objCity._Select("procItemMaster").Tables[0]);
        }
        public ActionResult Create()
        {
            int ID = Convert.ToInt32(RouteData.Values["id"]);
            ItemMaster itemMaster = new ItemMaster();
            if (ID != 0)
            {

                itemMaster.ItemId = ID;
                DataTable dt = itemMaster._Select("procItemMaster", "", itemMaster).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    itemMaster.ItemId = ID;
                    itemMaster.ItemName = Convert.ToString(dt.Rows[0]["ItemName"]);
                    itemMaster.ItemDescription = Convert.ToString(dt.Rows[0]["ItemDescription"]);
                    itemMaster.Price = Convert.ToDouble(dt.Rows[0]["Price"]);
                    itemMaster.SecurityDeposite = Convert.ToDouble(dt.Rows[0]["SecurityDeposite"]);
                    itemMaster.ServiceCharges = Convert.ToDouble(dt.Rows[0]["ServiceCharges"]);
                }

            }
            return View(itemMaster);

        }
        public ActionResult SaveData(ItemMaster obj)
        {
            string msg = string.Empty;
            if (obj.ItemId > 0)
            {
                msg = obj._Update("procItemMaster", obj);
            }
            else
            {
                msg = obj._Insert("procItemMaster", obj);
            }

            return Json(msg);
        }
    }
}