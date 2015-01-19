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
    public class SearchModel
    {     
        //[Required]
        [Display(Name = "MemberID :")]
        public int MemberID { get; set; }
        //[Required]
        [Display(Name = "Username :")]
        public string Username { get; set; }
        //[Required]
        [Display(Name = "Username :")]
        public string Password { get; set; }
        //[Required]
        [Display(Name = "CitizenID :")]
        public decimal CitizenID { get; set; }
        //[Required]
        [Display(Name = "Email :")]
        public string Email { get; set; }
        //[Required]
        [Display(Name = "MemberType :")]
        public int MemberType { get; set; }
        //[Required]
        [Display(Name = "StatusName :")]
        public string StatusName { get; set; }

        public static List<SearchModel> SearchSelect()
        {
            List<SearchModel> list = new List<SearchModel>();
            SqlConnection cn = new SqlConnection(GlobalVariables.ConnCarlover);
            cn.Open();
            SqlCommand cmd = new SqlCommand("Select MemberID,Username,Password From Member",cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                SearchModel u = new SearchModel();
                u.MemberID = ((int)dr["MemberID"]);
                u.Username = dr["Username"].ToString();
                u.Password = dr["Password"].ToString();
                list.Add(u);
            }
            cn.Close();
            return list;
            
        }
    }
}

