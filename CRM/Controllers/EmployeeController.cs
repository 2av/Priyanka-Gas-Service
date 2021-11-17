using CRM.Models.AuthData;
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
    [Authentication]
    public class EmployeeController : BaseController
    {
        // GET: Employee
        public ActionResult Index()
        {
            Employee obj = new Employee();
            return View(obj._Select("procEmployee").Tables[0]);
         }
        public ActionResult Create()
        {
            ViewBag.GasCompanyType = DropDownData("GasCompanyTypeDropDown", null, false, "procGasCompanyType");
            Employee obj = new Employee();
            string ID = Convert.ToString(RouteData.Values["id"]);
            if (!string.IsNullOrEmpty(ID))
            {
                obj.Employeeid = Convert.ToInt32(ID);
                DataTable dt = obj._Select("procEmployee", "SELECT", obj).Tables[0];
                obj = GlobalFunctions.ConverDataTableToList<Employee>(dt).FirstOrDefault();
                //if (dt.Rows.Count > 0)
                //{
                //    obj.FirstName = Convert.ToString(dt.Rows[0]["FirstName"]);
                //    obj.LastName = Convert.ToString(dt.Rows[0]["LastName"]);
                //    obj.Address = Convert.ToString(dt.Rows[0]["Address"]);
                //    obj.EmployeeCode = Convert.ToString(dt.Rows[0]["EmployeeCode"]);
                //    obj.Mobileno = Convert.ToString(dt.Rows[0]["Mobileno"]);
                //    obj.AlternateNo = Convert.ToString(dt.Rows[0]["AlternateNo"]);
                //    obj.Position = Convert.ToString(dt.Rows[0]["Position"]);
                //    obj.GasCompanyTypeId = Convert.ToInt32(dt.Rows[0]["GasCompanyTypeId"]);
                //    obj.ProfileImage = Convert.ToString(dt.Rows[0]["ProfileImage"]);

                //}

            }

            return View(obj);
        }
        public ActionResult SaveData(Employee obj)
        {
            string msg = string.Empty;
            if (obj.Employeeid > 0)
            {
                msg = obj._Update("procEmployee", obj);
            }
            else
            {
                msg = obj._Insert("procEmployee", obj);
            }
            return Json(msg);
        }
        public ActionResult DeleteData(Employee obj)
        {
            DataTable dt= obj._Select("procEmployee","DeleteData" ,obj).Tables[0];
            string msg = Convert.ToString(dt.Rows[0]["msg"]);
            return Json(msg);
        }

        [HttpPost]
        public ActionResult UploadFiles()
        {
            // Checking no of files injected in Request object  
            if (Request.Files.Count > 0)
            {
                try
                {
                    //  Get all files from Request object  
                    HttpFileCollectionBase files = Request.Files;
                    string fname = Guid.NewGuid().ToString();
                    string returnpath = "";
                    for (int i = 0; i < files.Count; i++)
                    {
                        //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";  
                        //string filename = Path.GetFileName(Request.Files[i].FileName);  

                        HttpPostedFileBase file = files[i];
                        

                        // Checking for Internet Explorer  
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            //fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            //fname = file.FileName;
                        }
                        string [] filetype= file.FileName.Split('.');
                        fname +="."+filetype[filetype.Length - 1].ToString();
                        // Get the complete folder path and store the file inside it.  
                        returnpath = fname;
                        fname = System.IO.Path.Combine(Server.MapPath("~/Uploads/"), fname);
                        file.SaveAs(fname);
                    }
                    // Returns message that successfully uploaded  
                    return Json("File Uploaded Successfully!|"+ returnpath);
                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            else
            {
                return Json("No files selected.");
            }
        }
    }
}