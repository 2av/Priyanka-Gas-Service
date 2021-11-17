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
    public class PrintController : Controller
    {
        // GET: Print
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult NewConnectionBill()
        {
            CustomerDetails obj = new CustomerDetails();
            obj.ID = Convert.ToInt32(RouteData.Values["id"]);
            string FromDate=Request.QueryString["FromDate"];
            string ToDate = Request.QueryString["ToDate"];
            if (!string.IsNullOrEmpty(FromDate))
            {
                obj.FromDate = FromDate;
            }
            if (!string.IsNullOrEmpty(ToDate))
            {
                obj.ToDate= ToDate;
            }
            DataSet ds = obj._Select("procCustomerDetails", "NewCustomerBillPrint",obj);
            vmCustomerDetailsItem print = new vmCustomerDetailsItem();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    print.ConsumerNo = Convert.ToString(dt.Rows[0]["ConsumerNo"]);
                    print.FirstName = Convert.ToString(dt.Rows[0]["FirstName"]);
                    print.LastName = Convert.ToString(dt.Rows[0]["LastName"]);
                    print.Address = Convert.ToString(dt.Rows[0]["Address"]);
                    print.PhoneNo = Convert.ToString(dt.Rows[0]["PhoneNo"]);
                    print.AlternateNo = Convert.ToString(dt.Rows[0]["AlternateNo"]);
                    print.CustomerType = Convert.ToString(dt.Rows[0]["CustomerType"]);
                    print.CreatedDate=Convert.ToString(dt.Rows[0]["CreatedDate"]);
                }
                print.ItemMaster = new List<vmItemMaster>();
                if (ds.Tables.Count > 1)
                {
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        DataTable dt = ds.Tables[1];
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {

                        vmItemMaster vim = new vmItemMaster();
                        vim.ItemName = Convert.ToString(dt.Rows[i]["ItemName"]);
                        vim.ItemDescription = Convert.ToString(dt.Rows[i]["ItemDescription"]);
                      //  vim.Price = Convert.ToDouble(dt.Rows[0]["Price"]);
                        vim.SecurityDeposite = Convert.ToDouble(dt.Rows[i]["SecurityDeposite"]);
                        vim.ServiceCharges = Convert.ToDouble(dt.Rows[i]["ServiceCharges"]);
                        vim.Qty = Convert.ToInt32(dt.Rows[i]["Qty"]);
                        vim.Total = Convert.ToDouble(dt.Rows[i]["Total"]);
                        print.ItemMaster.Add(vim);

                        }
                    }
                }
            }
            return View(print);
        }

        public ActionResult GasBookedBill()
        {
            List<GasBillPrint> lstBill = new List<GasBillPrint>();
            try
            {
                GasBooking obj = new GasBooking();
                obj.ID = Convert.ToInt32(RouteData.Values["id"]);
                string PrintId = Convert.ToString(Request.QueryString["printid"]);
                if (!string.IsNullOrEmpty(PrintId))
                {
                    obj.PrintId = PrintId;
                }
                lstBill = ListOfBill(obj);
            }catch(Exception ex)
            {

            }
            return View(lstBill);
        }
        public List<GasBillPrint> ListOfBill(GasBooking obj)
        {
            DataTable dt = obj._Select("procGasBooking", "GasBillPrint",obj).Tables[0];
            List<GasBillPrint> lstBill = new List<GasBillPrint>();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    GasBillPrint gasbillprint = new GasBillPrint();
                    gasbillprint.CustomerNo = Convert.ToString(dt.Rows[i]["CustomerNo"]);
                    gasbillprint.OrderNo = Convert.ToString(dt.Rows[i]["OrderNo"]);
                    gasbillprint.Name = Convert.ToString(dt.Rows[i]["Name"]);
                    gasbillprint.MemoNo = Convert.ToString(dt.Rows[i]["MemoNo"]);
                    gasbillprint.Address = Convert.ToString(dt.Rows[i]["Address"]);
                    gasbillprint.MobileNo = Convert.ToString(dt.Rows[i]["MobileNo"]);
                    gasbillprint.MemoDate = Convert.ToString(dt.Rows[i]["MemoDate"]);
                    gasbillprint.DeliveryDate = Convert.ToString(dt.Rows[i]["DeliveryDate"]);
                    gasbillprint.DeliveryMan = Convert.ToString(dt.Rows[i]["DeliveryMan"]);
                    gasbillprint.BookingDate = Convert.ToString(dt.Rows[i]["BookingDate"]);
                    gasbillprint.BillPrinted = Convert.ToString(dt.Rows[i]["BillPrinted"]);
                    gasbillprint.ItemCharges = Convert.ToString(dt.Rows[i]["ItemCharges"]);
                    gasbillprint.ItemWeight = Convert.ToString(dt.Rows[i]["ItemWeight"]);
                    gasbillprint.CompanyName = Convert.ToString(dt.Rows[i]["CompanyName"]);
                    gasbillprint.Quantity = Convert.ToString(dt.Rows[i]["Quantity"]);
                    gasbillprint.TotalCharge = Convert.ToString(dt.Rows[i]["TotalCharge"]);
                    lstBill.Add(gasbillprint);
                }
             
            }
            return lstBill;
        }
           
        public ActionResult BuyProductBill()
        {
            vmBuyProduct objbp = new vmBuyProduct();
            try
            {
                BuyProduct obj = new BuyProduct();
                
                obj.InvoiceNo =Convert.ToInt32( RouteData.Values["id"]);
                if (obj.InvoiceNo>0)
                {
                  DataTable dt = obj._Select("procBuyProduct", "BuyProductBill", obj).Tables[0];
                    if (dt.Rows.Count>0)
                    {
                        List<vmBuyProductItems> objlst = new List<vmBuyProductItems>();
                        objbp.Total = 0;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            vmBuyProductItems b = new vmBuyProductItems();
                            objbp.InvoiceNo = Convert.ToInt32(dt.Rows[i]["InvoiceNo"]);
                            objbp.SellerName= Convert.ToString(dt.Rows[i]["SellerName"]);
                            objbp.Address = Convert.ToString(dt.Rows[i]["Address"]);
                            objbp.CompanyName = Convert.ToString(dt.Rows[i]["CompanyName"]);
                            objbp.CreatedDate = Convert.ToString(dt.Rows[i]["CreatedDate"]);

                            b.ProductName = Convert.ToString(dt.Rows[i]["ProductName"]);
                            b.ProductPrice = Convert.ToDouble(dt.Rows[i]["ProductPrice"]);
                            b.Quantity= Convert.ToInt32(dt.Rows[i]["Quantity"]);
                            objbp.Total += (b.ProductPrice * b.Quantity);
                            objlst.Add(b);
                        }

                        objbp.BuyProductItems = new List<vmBuyProductItems>();
                        objbp.BuyProductItems = objlst;
                    }
                }
                
            }
            catch (Exception ex)
            {

            }
            return View(objbp);
        }     

        public ActionResult CardPrint()
        {
            Employee obj = new DAL.Employee();
            vmEmployee obje = new vmEmployee();
            try
            {
                obj.Employeeid = Convert.ToInt32(RouteData.Values["id"]);
                DataTable dt = obj._Select("procEmployee", "PrintEmployee", obj).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    obje.EmployeeCode = Convert.ToString(dt.Rows[0]["EmployeeCode"]);
                    obje.FirstName = Convert.ToString(dt.Rows[0]["FirstName"]);
                    obje.LastName = Convert.ToString(dt.Rows[0]["LastName"]);
                    obje.MobileNo = Convert.ToString(dt.Rows[0]["Mobileno"]);
                    obje.AlternateNo = Convert.ToString(dt.Rows[0]["AlternateNo"]);
                    obje.Address = Convert.ToString(dt.Rows[0]["Address"]);
                    obje.Position = Convert.ToString(dt.Rows[0]["Position"]);
                    obje.CompanyName = Convert.ToString(dt.Rows[0]["CompanyName"]);
                    obje.ProfileImage = Convert.ToString(dt.Rows[0]["ProfileImage"]);
                }
            }
            catch (Exception e) { }
            return View(obje);
        }

        public ActionResult EmergencyDuty()
        {
            return View();
        }
        public ActionResult SellProductBill()
        {
            vmSellProduct objbp = new vmSellProduct();
            try
            {
                SellProduct obj = new SellProduct();

                obj.InvoiceNo = Convert.ToInt32(RouteData.Values["id"]);
                if (obj.InvoiceNo > 0)
                {
                    DataTable dt = obj._Select("procSellProduct", "SellProductBill", obj).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        List<vmSellProductItems> objlst = new List<vmSellProductItems>();
                        objbp.Total = 0;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            vmSellProductItems b = new vmSellProductItems();
                            objbp.InvoiceNo = Convert.ToInt32(dt.Rows[i]["InvoiceNo"]);
                            objbp.CustomerName = Convert.ToString(dt.Rows[i]["CustomerName"]);
                            objbp.Address = Convert.ToString(dt.Rows[i]["Address"]);
                            objbp.CreatedDate = Convert.ToString(dt.Rows[i]["CreatedDate"]);

                            b.ProductName = Convert.ToString(dt.Rows[i]["ProductName"]);
                            b.ProductPrice = Convert.ToDouble(dt.Rows[i]["ProductPrice"]);
                            b.Quantity = Convert.ToInt32(dt.Rows[i]["Quantity"]);
                            objbp.Total += (b.ProductPrice * b.Quantity);
                            objlst.Add(b);
                        }

                        objbp.SellProductItems = new List<vmSellProductItems>();
                        objbp.SellProductItems = objlst;
                    }
                }

            }
            catch (Exception ex)
            {

            }
            return View(objbp);
        }

        public ActionResult Quotation()
        {
            return View();
        }
        public ActionResult Letterhead()
        {
            return View();
        }
        public ActionResult CombineBill()
        {

            GasBooking obj = new GasBooking();
            obj.ConsumerNo = Request.QueryString["cn"];
            List<BookingHistory> listbh = new List<BookingHistory>();
            if (!string.IsNullOrEmpty(obj.ConsumerNo))
            {
                string[] bookingno = Request.QueryString["bn"].Split(',');

                DataTable dt = obj._Select("procGasBooking", "BookingHistory", obj).Tables[0];
                
                double total = 0;
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        foreach (var item in bookingno)
                        {
                            if (item == Convert.ToString(dt.Rows[i]["ID"]))
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
                                total += Convert.ToDouble(bh.TotalCharges);
                            }

                        }

                    }
                }
                CustomerDetails cd = new CustomerDetails();
                cd.ID = Convert.ToInt32(obj.ConsumerNo);
                cd = GlobalFunctions.ConverDataTableToList<CustomerDetails>(cd._Select("procCustomerDetails", "SELECT", cd).Tables[0]).FirstOrDefault();
                ViewBag.CustomerName = cd.FirstName + " " + cd.LastName;
                ViewBag.Address = cd.Address;
                ViewBag.MobileNo1 = cd.PhoneNo;
                ViewBag.Alternateno = cd.AlternateNo;
                ViewBag.total = total;
            }
            return View(listbh);
        }
    }
}