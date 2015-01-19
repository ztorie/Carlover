using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace CWN.LSP.TeachingArrangementSystem.Models
{
    public class UserInfo
    {

        #region Member
        private const string ROL_PAT = ",{0}";
        #endregion

        public string FullNameTh { get; set; }

        public string FullNameEn { get; set; }

        public string Roles { get; set; }

        public void SetRoles(string[] roles)
        {
            var roleBuilder = new StringBuilder(64);

            foreach (var role in roles)
            {
                roleBuilder.AppendFormat(ROL_PAT, role);
            }

            Roles = roleBuilder.ToString().Substring(1);
        }
    }

    public class UserRoles
    {
        public string Application { get; set; }

        public string Roles { get; set; }
    }
}