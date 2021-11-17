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
    public class BuyProductController : BaseController
    {
        // GET: BuyProduct
        public ActionResult Index()
        {
            BuyProduct buyproduct = new BuyProduct();
            return View(buyproduct._Select("procBuyProduct").Tables[0]);


        }
        public ActionResult Create()
        {
            ViewBag.SellerMaster = DropDownData("SellerDetailsDropDown", null, false, "procSellerDetails");
            ViewBag.GasMaster = DropDownData("GasBookingDropdownSeller", null, false, "procGasMaster");
            BuyProduct obj = new BuyProduct();
            DataTable dt1 = obj._Select("procBuyProduct", "NewInvoiceNo").Tables[0];
            obj.InvoiceNo= Convert.ToInt32(dt1.Rows[0]["InvoiceNo"]);
            vmBuyProduct objbp = new vmBuyProduct();
            objbp.InvoiceNo = obj.InvoiceNo;
            return View(obj);
        }
        public ActionResult SaveData(vmBuyProduct objbuy)
        {
            string msg = string.Empty;
            if (objbuy != null)
            {
                string GroupId = Guid.NewGuid().ToString();
                foreach (var item in objbuy.BuyProductItems)
                {
                    BuyProduct obj = new BuyProduct();
                    obj.InvoiceNo = objbuy.InvoiceNo;
                    obj.SellerId = objbuy.SellerId;
                    obj.ProductId = item.ProductId;
                    obj.ProductName = item.ProductName;
                    obj.ProductPrice = item.ProductPrice;
                    obj.Quantity = item.Quantity;
                    msg=obj._Insert("procBuyProduct", obj);

                }
            }

            return Json(msg);
        }
    }
}