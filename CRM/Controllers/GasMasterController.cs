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
    public class GasMasterController : BaseController
    {
        // GET: GasMaster
        public ActionResult Index()
        {
            GasMaster gasMaster = new GasMaster();
            return View(gasMaster._Select("procGasMaster").Tables[0]);
        }
        public ActionResult Create(string id)
        {
            int ID= Convert.ToInt32(RouteData.Values["id"]);
            GasMaster gasMaster = new GasMaster();
            if (ID != 0)
            {
                
                gasMaster.ID = ID;
                DataTable dt = gasMaster._Select("procGasMaster","",gasMaster).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    gasMaster.ID = ID;
                    gasMaster.ItemName = Convert.ToString(dt.Rows[0]["ItemName"]);
                    gasMaster.ItemWeight = Convert.ToString(dt.Rows[0]["ItemWeight"]);
                    gasMaster.ItemCharges = Convert.ToDouble(dt.Rows[0]["ItemCharges"]);
                    gasMaster.BuyPrice = Convert.ToDouble(dt.Rows[0]["BuyPrice"]);
                }

            }
            return View(gasMaster);

        }
        public ActionResult SaveData(GasMaster obj)
        {
            string msg = string.Empty;
            if (obj.ID > 0)
            {
                msg = obj._Update("procGasMaster", obj);
            }
            else
            {
                msg = obj._Insert("procGasMaster", obj);
            }
            
            return Json(msg);
        }
    }
}