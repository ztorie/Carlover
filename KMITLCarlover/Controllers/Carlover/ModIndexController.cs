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



namespace KMITL.Carlover.Controllers
{
    public partial class CarloverController : Controller
    {

        // GET: /Home/
        public ActionResult ModIndex()
        {
            //string temp = Request.QueryString["TabIndex"];
            //ViewBag.Tab = temp;
            return View();
        }

        public ActionResult GetOthRecommend([DataSourceRequest] DataSourceRequest request)
        {
            //GlobalVariables.TimeTableTabIndex = 0;
            return PartialView("OthRecommend");
        }

        public ActionResult GetModRecommend([DataSourceRequest] DataSourceRequest request)
        {
            //GlobalVariables.TimeTableTabIndex = 2;
            return PartialView("Recommend");
        }

        public ActionResult GetModSearch([DataSourceRequest] DataSourceRequest request)
        {
            //GlobalVariables.TimeTableTabIndex = 1;
            return PartialView("Search");
        } 
    }
}
