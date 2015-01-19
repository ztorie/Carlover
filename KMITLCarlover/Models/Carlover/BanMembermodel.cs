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
    public class BanMemberModel
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
        [Display(Name = "Email :")]
        public string Email { get; set; }
        //[Required]
        [Display(Name = "MemberType :")]
        public string MemberType { get; set; }
        //[Required]
        [Display(Name = "MemberStatus :")]
        public string MemberStatus { get; set; }
        //[Required]
        [Display(Name = "Ban :")]
        public string Ban { get; set; }

        public static List<BanMemberModel> MemberSearch(string Username)
        { 
            List<BanMemberModel> list = new List<BanMemberModel>();
            SqlConnection cn = new SqlConnection(GlobalVariables.ConnCarlover);
            cn.Open();
            SqlCommand cmd = new SqlCommand("Select MemberID,Username,Password,MemberType,MemberStatus From Member where Username ='" + Username + "'", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                BanMemberModel u = new BanMemberModel();
                u.MemberID = ((decimal)dr["MemberID"]);
                u.Username = dr["Username"].ToString();
                u.Password = dr["Password"].ToString();
                u.Password = dr["MemberType"].ToString();
                u.MemberStatus = dr["MemberStatus"].ToString();
                list.Add(u);
            }
            cn.Close();
            return list;
        }
        public static List<BanMemberModel> MemberBan(string Username)
        {
            List<BanMemberModel> list = new List<BanMemberModel>();
            SqlConnection cn = new SqlConnection(GlobalVariables.ConnCarlover);
            cn.Open();
            SqlCommand cmd = new SqlCommand("Update Member set MemberStatus = 'Ban' where Username = '" + Username + "'", cn);
            int i = cmd.ExecuteNonQuery();
            cn.Close();
            return list;
        }
        public static List<BanMemberModel> MemberUnBan(string Username)
        {
            List<BanMemberModel> list = new List<BanMemberModel>();
            SqlConnection cn = new SqlConnection(GlobalVariables.ConnCarlover);
            cn.Open();
            SqlCommand cmd = new SqlCommand("Update Member set MemberStatus = NULL where Username = '" + Username + "'", cn);
            int i = cmd.ExecuteNonQuery();
            cn.Close();
            return list;
        }
        //public static void MemberBan1(string Username)
        //{
        //    List<BanMemberModel> list = new List<BanMemberModel>();
        //    SqlConnection cn = new SqlConnection(GlobalVariables.ConnCarlover);
        //    cn.Open();
        //    SqlCommand cmd = new SqlCommand("Update Member set Ban = 'Ban' where Username = '" + Username + "'", cn);
        //    int i = cmd.ExecuteNonQuery();
        //    cn.Close();
        //    //return i;
        //}
    }
}


