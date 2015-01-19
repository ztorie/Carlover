using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Web.Security;
using CWN.LSP.TeachingArrangementSystem.Models;
using CWN.LSP.UAC.ClientService.Helpers;
using Newtonsoft.Json;

namespace CWN.LSP.TeachingArrangementSystem.Controllers
{
    public class AuthenticateController : Controller
    {
        //
        // GET: /Authenticate/

        #region Member
        private const string PROGRAM_ID = "";
        private const string MODULE_NAME = "Authenticate";

        private const string LOGIN_CONTROLLER = "Login";
        private const string WELCOME_CONTROLLER = "Home";
        private const string INDEX = "Index";

        private const string LOGIN_FAILED_MSG = "ไม่สามารถเข้าสู่ระบบ";

        #endregion

        public ActionResult Login(LoginViewModel model, string returnUrl)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    if (Membership.ValidateUser(model.UserID, model.Password))
                    {
                        var roles = Roles.GetRolesForUser(model.UserID);
                        string userName = UserHelper.GetInstance().GetUserName(model.UserID);

                        var userInfo = new UserInfo
                        {
                            FullNameTh = userName,
                            FullNameEn = string.Empty
                        };
                        userInfo.SetRoles(roles);

                        var userData = JsonConvert.SerializeObject(userInfo);

                        int ticketVersion = 1;
                        var authTicket = new FormsAuthenticationTicket(
                            ticketVersion,
                            model.UserID,
                            DateTime.Now,
                            DateTime.Now.AddMinutes(30),
                            false,
                            userData);

                        var ticketEnc = FormsAuthentication.Encrypt(authTicket);
                        Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, ticketEnc));

                        var result = new RedirectResult(returnUrl);
                        return result;
                    }
                    else
                    {
                        // Log Error
                        ViewBag.Message = LOGIN_FAILED_MSG;
                        return RedirectToAction(INDEX, LOGIN_CONTROLLER);
                    }
                }
                catch (Exception)
                {
                    // Log Error
                    ViewBag.Message = LOGIN_FAILED_MSG;
                    return RedirectToAction(INDEX, LOGIN_CONTROLLER);
                }
            }
            else
            {
                ViewBag.Message = LOGIN_FAILED_MSG;
                return RedirectToAction(INDEX, LOGIN_CONTROLLER);
            }

            //return RedirectToAction(INDEX, WELCOME_CONTROLLER);

            //string ticket = string.Empty;
            //bool isConfirmed = false;

            //try
            //{
            //    if (ModelState.IsValid)
            //    {
            //        if (GetTicket(vm.UserID, vm.Password, ref ticket))
            //        {
            //            ClientTicket = ticket;

            //            var checkConfirmResult = StudentService.CheckConfirmRegistration(vm.UserID);
            //            isConfirmed = checkConfirmResult.Success;
            //        }
            //        else
            //        {
            //            ViewMessage = Resource.LoginFailed;
            //        }
            //    }
            //    else
            //    {
            //        ViewMessage = ModelState.GetError();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    LogError(ex);
            //    ViewMessage = Resource.LoginFailed;
            //}

            //if (!string.IsNullOrEmpty(ticket))
            //{
            //    if (isConfirmed)
            //    {
            //        return RedirectToAction(INDEX, WELCOME_CONTROLLER, new { ticket = ticket });
            //    }
            //    else
            //    {
            //        return RedirectToAction(INDEX, REG_WARNING_CONTROLLER, new { ticket = ticket });
            //    }
            //}
            //else
            //{
            //    return RedirectToAction(INDEX, LOGIN_CONTROLLER);
            //}
        }

        //[Authenticated]
        public ActionResult Logout()
        {
            //try
            //{
            //    DoLogout();
            //    ClearTicket();
            //}
            //catch (Exception ex)
            //{
            //    LogError(ex);
            //}

            return RedirectToAction(INDEX, LOGIN_CONTROLLER);
        }

    }
}
