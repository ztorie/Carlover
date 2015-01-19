using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CWN.LSP.TeachingArrangementSystem.Controllers
{
    using CWN.LSP.UAC.ClientService.Filters;
    public class LoginController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index(string returnUrl)
        {
            if (Request.IsAuthenticated)
            {
                return WelcomePage();
            }
            else
            {
                ViewBag.ReturnUrl = returnUrl;
                ViewBag.ViewMessage = "xxxxxxxx";
                return View();
            }
        }


        protected ActionResult WelcomePage()
        {
            return RedirectToAction("Index", "Home");
        }

    }
}
