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

        public ActionResult Garage()
        {
            return View();
        }
        public ActionResult sendreview(Reviewmodel _Model,string rating1,string rating2,string rating3,string rating4,string rating5)
        {
            int i = Reviewmodel.insertreview(_Model.Content, Session["MemberID"].ToString());
            return View("Garage",_Model);
        }
    }
}
