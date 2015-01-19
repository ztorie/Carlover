using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using Kendo.Mvc.UI;

namespace KMITL.Carlover.Models
{
    public class loginmodel
    {
        //[Required]
        [Display(Name = "MemberID :")]
        public decimal MemberID { get; set; }
        //[Required]
        [Display(Name = "Username :")]
        public string Username { get; set; }
        //[Required]
        [Display(Name = "Password :")]
        public string Password { get; set; }
        //[Required]
        [Display(Name = "MemberType :")]
        public string MemberType { get; set; }

        public static List<loginmodel> login(string Username1, string Password1)
        {
            List<loginmodel> list = new List<loginmodel>();
            SqlConnection cn = new SqlConnection(GlobalVariables.ConnCarlover);
            cn.Open();
            SqlCommand cmd = new SqlCommand("Select MemberID,Username,Password,MemberType From Member where Username = '" + Username1 + "' and Password = '" + Password1 + "'", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                loginmodel u = new loginmodel();
                u.MemberID = ((decimal)dr["MemberID"]);
                u.Username = dr["Username"].ToString();
                u.Password = dr["Password"].ToString();
                u.MemberType = dr["MemberType"].ToString();
                list.Add(u);
            }
            cn.Close();
                return list;

        }
    }
}

