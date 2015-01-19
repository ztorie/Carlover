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
        public ActionResult BanUser()
        {
            ViewBag.Banbag = 0;
            return View();
        }
        public ActionResult Ban(string Username, string Command)
        {
            if (Command == "Search")
            {
                List<BanMemberModel> list = BanMemberModel.MemberSearch(Username);
                if (list.Count > 0)
                {
                    ViewBag.Banbag = 1;
                    return View("BanUser", list[0]);
                }
                else
                    return View("BanUser");
            }
            else if (Command == "Cancel")
            {
                ModelState.Clear();
                return View("BanUser");
            }

            else if (Command == "Ban")
            {
                List<BanMemberModel> list = BanMemberModel.MemberBan(Username);
                //int p = BanMemberModel.MemberBan1(Username);
                    //BanMemberModel.MemberBan1(Username);
                    ViewBag.Banbag = 0;
                    return View("BanUser");
            }

            else if (Command == "UnBan")
            {
                List<BanMemberModel> list = BanMemberModel.MemberUnBan(Username);
                ViewBag.Banbag = 0;
                return View("BanUser");
            }

            else return View("BanUser");               
        }
    }       
}
