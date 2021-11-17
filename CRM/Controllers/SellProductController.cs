using CRM.Models.AuthData;
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
    public class SellProductController : BaseController
    {
        // GET: SellProduct
        public ActionResult Index()
        {
            SellProduct sellProduct = new SellProduct();
            return View(sellProduct._Select("procSellProduct").Tables[0]);
        }
        public ActionResult SellProduct()
        {
            CustomerDetails objCustomer = new CustomerDetails();
            objCustomer.ID= Convert.ToInt32(RouteData.Values["id"]);

            DataTable dtUser = null;
            if (objCustomer.ID > 0)
            {
                dtUser=objCustomer._Select("procCustomerDetails", "SELECT", objCustomer).Tables[0];

            }
            ViewBag.ConsumerNo = "0";
            ViewBag.Name = "User Not Available";
            if (dtUser!=null && dtUser.Rows.Count > 0)
            {
                ViewBag.ConsumerNo = dtUser.Rows[0]["ConsumerNo"];
                ViewBag.Name = dtUser.Rows[0]["FirstName"] +" "+ dtUser.Rows[0]["LastName"];
            }
            // ViewBag.SellerMaster = DropDownData("SellerDetailsDropDown", null, false, "procSellerDetails");
            ViewBag.GasMaster = DropDownData("GasBookingDropdown", null, false, "procGasMaster");
            SellProduct obj = new DAL.SellProduct();
            DataTable dt1 = obj._Select("procSellProduct", "NewInvoiceNo").Tables[0];
            obj.InvoiceNo = Convert.ToInt32(dt1.Rows[0]["InvoiceNo"]);
            vmSellProduct objbp = new vmSellProduct();
            objbp.InvoiceNo = obj.InvoiceNo;
            return View(obj);
        }
        public ActionResult SaveData(vmSellProduct objbuy)
        {
            string msg = string.Empty;
            if (objbuy != null)
            {
                string GroupId = Guid.NewGuid().ToString();
                foreach (var item in objbuy.SellProductItems)
                {
                    SellProduct obj = new SellProduct();
                    obj.InvoiceNo = objbuy.InvoiceNo;
                    obj.ConsumerNo = objbuy.ConsumerNo;
                    obj.ProductId = item.ProductId;
                    obj.ProductName = item.ProductName;
                    obj.ProductPrice = item.ProductPrice;
                    obj.Quantity = item.Quantity;
                    msg = obj._Insert("procSellProduct", obj);

                }
            }

            return Json(msg);
        }
    }
}