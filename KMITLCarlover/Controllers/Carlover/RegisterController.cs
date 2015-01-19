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


        public ActionResult Register()
        {
            return View();
        }
        public ActionResult comparedata(Registermodel _model)
        {

            int i = Registermodel.Registercheck(_model.Username, _model.Password, _model.Email, _model.MemberType);
            if (i == 1 && _model.MemberType == "Member")
                return View("MemberRegister", _model);
            else if (i == 1 && _model.MemberType == "GarageMember")
                return View("GarageMemberRegister", _model);
            //return PartialView("Register",_model);
            //return RedirectToAction("Register", "Carlover");
            else
                return RedirectToAction("Register", "Carlover");
            //return Json(i, JsonRequestBehavior.AllowGet);
        }
        public ActionResult comparedataMember(Registermodel _model, string latitudeStr, string longitudeStr)
        {
            _model.Latitude = Convert.ToDouble(latitudeStr);
            _model.Longitude = Convert.ToDouble(longitudeStr);
            _model.Name = _model.Name + " " + _model.Surname;
            int i = Registermodel.RegisterMemberinsert(_model.Username, _model.Password, _model.Email, _model.Latitude, _model.Longitude, _model.Name, _model.Gender);
            if (i == 2)
                return RedirectToAction("Index", "Home");
            else
                return View("MemberRegister", _model);
        }
        public ActionResult comparedataGarageMember(Registermodel _model, string latitudeStr, string longitudeStr)
        {
            _model.Latitude = Convert.ToDouble(latitudeStr);
            _model.Longitude = Convert.ToDouble(longitudeStr);
            int i = Registermodel.RegisterGarageinsert(_model.Username, _model.Password, _model.Email, _model.Latitude, _model.Longitude, _model.Name, _model.SubDistrictName);
            if (i == 2)
                return RedirectToAction("Index", "Home");
            else
                return View("GarageMemberRegister", _model);
        }
        public ActionResult comparedataSubDistrict(Registermodel _model)
        {
            List<Registermodel> _SubDistrict = Registermodel.CSubDistrict(_model.DistrictName);
            return Json(_SubDistrict, JsonRequestBehavior.AllowGet);
        }
        public ActionResult comparedataDistrict(Registermodel _model)
        {
            List<Registermodel> _District = Registermodel.CDistrict(_model.ProvinceName);
            return Json(_District, JsonRequestBehavior.AllowGet);
        }
        public ActionResult comparedataProvince()
        {
            List<Registermodel> _Province = Registermodel.CProvince();
            return Json(_Province, JsonRequestBehavior.AllowGet);
        }
    }
}
