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
    public class CustomerDetailsController : Controller
    {
        // GET: CustomerDetails
        ItemMaster objitem = new ItemMaster(); 
        public ActionResult Index()
        {
            CustomerDetails customerDetails = new CustomerDetails();
            return View(customerDetails._Select("procCustomerDetails").Tables[0]);
                        
        }
        public ActionResult Create()
        {
            
            DataTable dt = objitem._Select("procItemMaster", Common.Action_Select).Tables[0];
            vmCustomerDetailsItem objcd = new vmCustomerDetailsItem();
            objcd.ItemMaster = new List<vmItemMaster>();
            if (dt!=null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    vmItemMaster oim = new vmItemMaster();
                    oim.ItemId= Convert.ToInt32(dt.Rows[i]["ItemId"]);
                    oim.ItemName = Convert.ToString(dt.Rows[i]["ItemName"]);
                    oim.SecurityDeposite = Convert.ToDouble(dt.Rows[i]["SecurityDeposite"]);
                    oim.ServiceCharges = Convert.ToDouble(dt.Rows[i]["ServiceCharges"]);
                    oim.Qty =1;
                    oim.Price = Convert.ToDouble(dt.Rows[i]["Price"]);
                    objcd.ItemMaster.Add(oim);
                }
                dt.Dispose();
            }


            CustomerDetails cd = new CustomerDetails();
            int ID = Convert.ToInt32(RouteData.Values["id"]);
            if (ID > 0)
            {
                cd.ID = ID;
                DataTable dtCD = cd._Select("procCustomerDetails", Common.Action_Select, cd).Tables[0];
                if (dtCD.Rows.Count > 0)
                {
                    objcd.ID = Convert.ToInt32(dtCD.Rows[0]["ID"]);
                    objcd.FirstName = Convert.ToString(dtCD.Rows[0]["FirstName"]);
                    objcd.LastName = Convert.ToString(dtCD.Rows[0]["LastName"]);
                    objcd.Address = Convert.ToString(dtCD.Rows[0]["Address"]);
                    objcd.PhoneNo = Convert.ToString(dtCD.Rows[0]["PhoneNo"]);
                    objcd.AlternateNo = Convert.ToString(dtCD.Rows[0]["AlternateNo"]);
                    objcd.CustomerType = Convert.ToString(dtCD.Rows[0]["CustomerType"]);
                }
            }
            else
            {
                DataTable dt1 = cd._Select("procCustomerDetails", "NewConsumerNo").Tables[0];
                objcd.ConsumerNo = Convert.ToString(dt1.Rows[0]["ConsumerNo"]);
            }


            return View(objcd);
        }
        public ActionResult SaveData(vmCustomerDetailsItem obj)
        {
            CustomerDetails customerdetails = new CustomerDetails();
            customerdetails.FirstName = obj.FirstName;
            customerdetails.LastName = obj.LastName;
            customerdetails.Address= obj.Address;
            customerdetails.PhoneNo= obj.PhoneNo;
            customerdetails.AlternateNo = obj.AlternateNo;
            customerdetails.AreaCode = obj.AreaCode;
            customerdetails.CustomerType = obj.CustomerType;
            customerdetails.ConsumerNo = obj.ConsumerNo;

            if (obj.ID > 0)
            {
                customerdetails.ID = obj.ID;
                string msg = customerdetails._Update("procCustomerDetails", customerdetails);
            }
            else
            {


                string msg = customerdetails._Insert("procCustomerDetails", customerdetails);

                for (int i = 0; i < obj.ItemMaster.Count; i++)
                {
                    NewConnectionItems objNc = new NewConnectionItems();
                    objNc.ItemNo = obj.ItemMaster[i].ItemId;
                    objNc.ConsumerNo = customerdetails.ConsumerNo;
                    objNc.ItemDescription = obj.ItemMaster[i].ItemDescription;
                    objNc.SecurityDeposit = obj.ItemMaster[i].SecurityDeposite;
                    objNc.ServiceCharges = obj.ItemMaster[i].ServiceCharges;
                    objNc.Total = obj.ItemMaster[i].Total;
                    objNc.Qty = obj.ItemMaster[i].Qty;
                    objNc.TotalAmount = (objNc.SecurityDeposit + objNc.ServiceCharges + objNc.Total) * objNc.Qty;
                    string ncmsg = objNc._Insert("procNewConnectionItems", objNc);
                }
            }

            return Json("Save Successfully");
        }
    }
}