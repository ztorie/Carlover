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
        public ActionResult AddService([DataSourceRequest] DataSourceRequest request, AddServiceModel _model)
        {
            List<AddServiceModel> list = AddServiceModel.MemberSelect();
            return View(list);
        }

        public ActionResult MemberSelect([DataSourceRequest] DataSourceRequest request, AddServiceModel _model)
        {
            List<AddServiceModel> list = AddServiceModel.MemberSelect();
            return Json(list.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult MemberInsert([DataSourceRequest] DataSourceRequest request, AddServiceModel _model)
        {
            if (ModelState.IsValid)
            {

                int result = AddServiceModel.MemberAdd(_model.ServiceID, _model.Service);
                if (result > 0)
                {
                    return RedirectToAction("AddService", "Carlover");
                }
                else
                    ModelState.AddModelError("", "Can Not Insert");
            }
            //return View(insertmodel);
            return Json(new[] { _model }.ToDataSourceResult(request, ModelState));
        }
        public ActionResult MemberUpdate([DataSourceRequest] DataSourceRequest request, AddServiceModel _model)
        {
            int result = AddServiceModel.MemberUpdate(_model.ServiceID, _model.Service);
            if (result > 0)
            {
                return RedirectToAction("AddService", "Carlover");
            }
            else
                ModelState.AddModelError("", "Can Not Update");
            return Json(new[] { _model }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult MemberDelete([DataSourceRequest]DataSourceRequest request, AddServiceModel _model)
        {
            int result = AddServiceModel.MemberDelete(_model.ServiceID);
            if (result > 0)
                return RedirectToAction("AddService", "Carlover");
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
