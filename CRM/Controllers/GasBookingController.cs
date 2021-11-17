using CRM.Models.AuthData;
using CRM.Models.Global;
using CRM.Models.ViewModel;
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
    public class GasBookingController : BaseController
    {
        // GET: GasBooking
        public ActionResult Index()
        {
            GasBooking obj = new GasBooking();
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

            return View(obj._Select("procGasBooking",Common.Action_Select,obj).Tables[0]);
        }
        public ActionResult Booking()
        {
            GasBooking obj = new GasBooking();
            ViewBag.GasMaster = DropDownData("GasBookingDropdown", null,false,"procGasMaster");
            ViewBag.DeliveryMan = DropDownData("DeliveryManDropDown", null, false, "procDeliveryMan");
            ViewBag.PaymentStatus = DropDownData("PaymentStatusDropDown", null, false, "procPaymentStatus");
            ViewBag.GasCompanyType = DropDownData("GasCompanyTypeDropDown", null, false, "procGasCompanyType");
            string search = Request.QueryString["search"];
            ViewBag.CustomerStatus = "Please search the customer for booking cylinder";
            ViewBag.color = "#0c91a7";
            List<SelectListItem> list = new List<SelectListItem>();
            if (!string.IsNullOrEmpty(search))
            {
                CustomerDetails objd = new CustomerDetails();
                objd.FirstName = search;
                ViewBag.SearchKeyword = "Search Keyword:" + search;
                DataTable dt = objd._Select("procCustomerDetails", "SearchCustomerForBookinGas", objd).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        list.Add(new SelectListItem() { Text = dt.Rows[i]["ID"].ToString(), Value = dt.Rows[i]["Name"].ToString() });
                    }
                    ViewBag.color = "#00dc11";
                    ViewBag.CUstomerStatus = "Status: Customer Found!Please select the customer and book the cylinder";
                }
                else
                {
                    ViewBag.color = "#ff0000";
                    ViewBag.CustomerStatus = "Status: Customer not found!";
                }
            }
            ViewBag.CustomerDetails = list;
            

            return View();
        }
        public ActionResult SearchCustomer(CustomerDetails obj ) {
            List<CustomerDetails> lstObj = new List<CustomerDetails>();
            DataTable dt = obj._Select("procCustomerDetails","SearchCustomerForBookinGas",obj).Tables[0];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CustomerDetails objd = new CustomerDetails();
                    objd.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    objd.FirstName = Convert.ToString(dt.Rows[i]["Name"]);
                    lstObj.Add(objd);
                }
            }
            return Json(lstObj);
        }
        public ActionResult BookGas(GasBooking obj)
        {
            string msg = obj._Insert("procGasBooking", obj);
            return Json(msg);
        }
        public ActionResult BookingHistory(GasBooking obj)
        {
            DataTable dt = obj._Select("procGasBooking", "BookingHistory", obj).Tables[0];

            List<BookingHistory> listbh = new List<BookingHistory>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    BookingHistory bh = new DAL.BookingHistory();
                    bh.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    bh.ItemName = Convert.ToString(dt.Rows[i]["ItemName"]);
                    bh.ItemWeight = Convert.ToString(dt.Rows[i]["ItemWeight"]);
                    bh.ItemCharges = Convert.ToString(dt.Rows[i]["ItemCharges"]);
                    bh.BookingDate = Convert.ToString(dt.Rows[i]["BookingDate"]);
                    bh.Quantity = Convert.ToString(dt.Rows[i]["Quantity"]);
                    bh.TotalCharges = Convert.ToString(dt.Rows[i]["TotalCharges"]);
                    bh.CompanyName = Convert.ToString(dt.Rows[i]["CompanyName"]);
                    listbh.Add(bh);
                }                
            }
            return Json(listbh);
        }
        public ActionResult LastBookingHistory(GasBooking obj)
        {
            DataTable dt = obj._Select("procGasBooking", "LastBookingHistory", obj).Tables[0];

            List<BookingHistory> listbh = new List<BookingHistory>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    BookingHistory bh = new DAL.BookingHistory();
                    bh.ItemName = Convert.ToString(dt.Rows[i]["ItemName"]);
                    bh.ItemWeight = Convert.ToString(dt.Rows[i]["ItemWeight"]);
                    bh.ItemCharges = Convert.ToString(dt.Rows[i]["ItemCharges"]);
                    bh.BookingDate = Convert.ToString(dt.Rows[i]["BookingDate"]);
                    bh.Quantity = Convert.ToString(dt.Rows[i]["Quantity"]);
                    bh.TotalCharges = Convert.ToString(dt.Rows[i]["TotalCharges"]);
                    bh.CompanyName = Convert.ToString(dt.Rows[i]["CompanyName"]);
                    listbh.Add(bh);
                }
            }
            return Json(listbh);
        }
        public ActionResult Last6MonthBookingDetails()
        {
            return View(new GasBooking()._Select("procGasBooking", "Last6MonthBookingDetails").Tables[0]);
        }
        public ActionResult Last6MonthNotBookingDetails()
        {
            return View(new GasBooking()._Select("procGasBooking", "Last6MonthNotBookingDetails").Tables[0]);
        }
    }
}
