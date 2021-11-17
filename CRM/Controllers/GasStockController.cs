using CRM.Models.Global;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.Controllers
{
    public class GasStockController : Controller
    {
        GasStock objGasStock = new GasStock();
        // GET: GasStock
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MahulStockDetails()
        {
            return View(objGasStock._Select("procGasStock", "MahulStockDetails").Tables[0]);
        }
        public ActionResult NewStock()
        {
            return View();
        }
        public ActionResult SaveStock(GasStock obj)
        {
            string msg = obj._Insert("procGasStock", obj);
            return Json(msg);
        }


        public ActionResult StockReplacement()
        {
            return View();
        }
        public ActionResult StockReplacementSave(List<GasStock> objlist)
        {
            string msg = "";
            foreach (var item in objlist)
            {
                msg = item._Insert("procGasStock", item);
            }
            return Json(msg);
        }
        public ActionResult StockReplacementDetails()
        {
            return View(objGasStock._Select("procGasStock", "StockReplacementDetails").Tables[0]);
        }


        public ActionResult StaffStockEntry()
        {
            Employee e = new Employee();
            DataTable dt = e._Select("procEmployee", "FindIsGasDeliveryMan").Tables[0];
            ViewBag.listemployee = GlobalFunctions.ConverDataTableToList<Employee>(dt);
            return View();
        }
        public ActionResult StaffStockEntrySave(List<GasStock> objlist)
        {
            string msg = "";
            foreach (var item in objlist)
            {
                msg = item._Insert("procGasStock", item);
            }
            return Json(msg);
        }
        public ActionResult StaffStockEntryDetails()
        {
            string FromDate = Request.QueryString["FromDate"];
            string ToDate = Request.QueryString["ToDate"];
            if (!string.IsNullOrEmpty(FromDate))
            {
                objGasStock.FromDate = FromDate;
            }
            if (!string.IsNullOrEmpty(ToDate))
            {
                objGasStock.ToDate = ToDate;
            }
            //return View(objGasStock._Select("procGasStock", "StaffStockEntryDetails").Tables[0]);
            List<vmGasStockDetails> gasStocks = new List<vmGasStockDetails>();
            gasStocks = GlobalFunctions.ConverDataTableToList<vmGasStockDetails>(objGasStock._Select("procGasStock", "StaffDetailForGasStock",objGasStock).Tables[0]).ToList();
            return View(gasStocks);
        }
        public ActionResult _StaffStockDetails(GasStock obj)
        {
            string EntryForId= Request.QueryString["efid"];
            string FromDate = Request.QueryString["FromDate"];
            string ToDate = Request.QueryString["ToDate"];
            if (!string.IsNullOrEmpty(FromDate))
            {
                obj.FromDate = FromDate;
            }
            if (!string.IsNullOrEmpty(ToDate))
            {
                obj.ToDate = ToDate;
            }
            if (!string.IsNullOrEmpty(EntryForId))
            {
                obj.EntryForId = Convert.ToInt32(EntryForId);              
            }
            List<GasStock> gasStocks = new List<GasStock>();
            DataSet ds = obj._Select("procGasStock", "_StaffStockDetails", obj) ;
            GasStock gsFull= GlobalFunctions.ConverDataTableToList<GasStock>(ds.Tables[0]).FirstOrDefault();
            GasStock gsSale = GlobalFunctions.ConverDataTableToList<GasStock>(ds.Tables[1]).FirstOrDefault();
            GasStock gsReturn = GlobalFunctions.ConverDataTableToList<GasStock>(ds.Tables[2]).FirstOrDefault();
            GasStock gsEmpty = GlobalFunctions.ConverDataTableToList<GasStock>(ds.Tables[3]).FirstOrDefault();
            GasStock gsBalnce = GlobalFunctions.ConverDataTableToList<GasStock>(ds.Tables[4]).FirstOrDefault();

            ViewBag.employee = GlobalFunctions.ConverDataTableToList<Employee>(ds.Tables[5]).FirstOrDefault();
            if (string.IsNullOrEmpty(obj.FromDate))
            {
                ViewBag.FromDate = DateTime.Now.ToShortDateString();
            }
            else
            {
                ViewBag.FromDate = "From: "+ obj.FromDate;
            }
            
            if (!string.IsNullOrEmpty(obj.ToDate))
            {
                ViewBag.ToDate = " to:  "+obj.ToDate;
            }

            ViewBag.EntryForId = EntryForId;
            List<GasStock> gas = new List<GasStock>();
            gas.Add(gsFull);
            gas.Add(gsSale);
            gas.Add(gsReturn);
            gas.Add(gsEmpty);
            gas.Add(gsBalnce);

            ViewBag.Url = "/GasStock/_StaffStockDetails?efid="+obj.EntryForId+"&FromDate="+obj.FromDate+"&ToDate="+obj.ToDate;

            return View(gas);
        }


        public ActionResult CheckFullGasStock(GasStock obj)
        {
            DataSet ds = obj._Select("procGasStock", "CheckFullGasStock", obj);
            List<GasStock> objlist = new List<GasStock>();
            objlist.Add(GlobalFunctions.ConverDataTableToList<GasStock>(ds.Tables[0]).FirstOrDefault());
            objlist.Add(GlobalFunctions.ConverDataTableToList<GasStock>(ds.Tables[1]).FirstOrDefault());
            objlist.Add(GlobalFunctions.ConverDataTableToList<GasStock>(ds.Tables[2]).FirstOrDefault());
            objlist.Add(GlobalFunctions.ConverDataTableToList<GasStock>(ds.Tables[3]).FirstOrDefault());
            objlist.Add(GlobalFunctions.ConverDataTableToList<GasStock>(ds.Tables[4]).FirstOrDefault());
            if (objlist[0] == null)
            {
                return Json("");
            }
            else
            {
                return Json(objlist);
            }

        }
    }
}