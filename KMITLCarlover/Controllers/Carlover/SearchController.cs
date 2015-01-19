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


        //public ActionResult Search()
        //{
        //    return View();
        //}
        public ActionResult SelectSearch([DataSourceRequest] DataSourceRequest request, SearchModel _model)
        {
            List<SearchModel> list = SearchModel.SearchSelect();
            //return View(list);
            //return PartialView("Search", list);
            return Json(list.ToDataSourceResult(request),JsonRequestBehavior.AllowGet);
        }
        public ActionResult Search([DataSourceRequest] DataSourceRequest request, SearchModel _model)
        {
            List<SearchModel> list = SearchModel.SearchSelect();
            return View(list);
            //return PartialView("Search", list);
            //return Json(list.ToDataSourceResult(request),JsonRequestBehavior.AllowGet);
        }
    }
}
