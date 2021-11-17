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
    public class EnquiryController : BaseController
    {
        // GET: Enquiry
        Enquiry objEnquiry = new Enquiry();
        public ActionResult Index()
        {
            fillDropDown();
            return View(objEnquiry._Select("procEnquiry").Tables[0]);
        }
        public ActionResult Create()
        {
            fillDropDown();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Enquiry obj)
        {
            string msg = objEnquiry._Insert("procEnquiry",obj);
            return Json(msg);
        }
        public void fillDropDown()
        {
            ViewBag.GenderList = DropDownData("Gender");
            ViewBag.ddEnquiryAction = DropDownData("tblEnquiryAction");
        }
        public ActionResult GetEnquiryDetails(int EnquiryId)
        {
            objEnquiry.EnquiryId = EnquiryId;
            DataTable dt = objEnquiry._Select("procEnquiry",Common.Action_Find,objEnquiry).Tables[0];
            List<Enquiry> lstObj = Base.BindList<Enquiry>(dt);
            return Json(lstObj);
        }
    }
}