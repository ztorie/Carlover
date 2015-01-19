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
        public ActionResult BanMember([DataSourceRequest] DataSourceRequest request, BanMemberModel _model)
        {
            List<BanMemberModel> list = BanMemberModel.MemberSelect();
            return View(list);
        }

        public ActionResult MemberSelect([DataSourceRequest] DataSourceRequest request, BanMemberModel _model)
        {
            List<BanMemberModel> list = BanMemberModel.MemberSelect();
            return Json(list.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult MemberInsert([DataSourceRequest] DataSourceRequest request, BanMemberModel _model)
        {
            if (ModelState.IsValid)
            {

                int result = BanMemberModel.MemberAdd(_model.Username, _model.Password, _model.MemberType);
                if (result > 0)
                {
                    return RedirectToAction("BanMember", "Carlover");
                }
                else
                    ModelState.AddModelError("", "Can Not Insert");
            }
            //return View(insertmodel);
            return Json(new[] { _model }.ToDataSourceResult(request, ModelState));
        }
        public ActionResult MemberUpdate([DataSourceRequest] DataSourceRequest request, BanMemberModel _model)
        {
            List<BanMemberModel> list = BanMemberModel.MemberSelect();
            return View(list);
        }

        public ActionResult MemberDelete([DataSourceRequest]DataSourceRequest request, BanMemberModel _model)
        {
            int result = BanMemberModel.MemberDelete(_model.MemberID);
            if (result > 0)
                return RedirectToAction("BanMember", "Carlover");
            else
            {
                ModelState.AddModelError("", "Can Not Delete");
                //return Json(ModelState.ToDataSourceResult());

                // Return the removed task. Also return any validation errors.
                return Json(new[] { _model }.ToDataSourceResult(request, ModelState));
            }
        }
    }
}
