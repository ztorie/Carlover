using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

using System.Data;
using System.Data.SqlClient;
using KMITL.Carlover.Models;

using System.Web.SessionState;

namespace KMITL.Carlover.Controllers
{
    public partial class CarloverController : Controller
    {
        //
        // GET: /login1/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult login(loginmodel _model)
        {
            
             List<loginmodel> a = loginmodel.login(_model.Username, _model.Password);
             

             if (a.Count == 1) 
             {
                 Session["Username"] = _model.Username.ToString();
                 Session["MemberID"] = a[0].MemberID.ToString();
                 Session["MemberType"] = a[0].MemberType.ToString();
                 //int b = Convert.ToInt32(Session["MemberType"]);
                 return RedirectToAction("Index", "Home");
             }
             else return View("LoginFail");
        }
        public ActionResult logout() 
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult postmap(string Country, string SubDistrict, string District, string Province)
        {
            if (Country == "ประเทศไทย" && Province != "" && District != "" && SubDistrict != "" && SubDistrict != "กรุงเทพมหานคร") { Registermodel.insertmap(Province, District, SubDistrict); }
            return View("Copy of MemberRegister");
        }
        public ActionResult CopyMemberRegister()
        {
           

            return View("Copy of MemberRegister");
        }
    }
}
