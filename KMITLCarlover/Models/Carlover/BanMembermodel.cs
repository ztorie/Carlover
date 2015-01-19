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

        public static List<BanMemberModel> MemberSelect()
        {
            List<BanMemberModel> list = new List<BanMemberModel>();
            SqlConnection cn = new SqlConnection(GlobalVariables.ConnCarlover);
            cn.Open();
            SqlCommand cmd = new SqlCommand("Select MemberID,Username,Password,MemberType From Member", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                BanMemberModel u = new BanMemberModel();
                u.MemberID = ((int)dr["MemberID"]);
                u.Username = dr["Username"].ToString();
                u.Password = dr["Password"].ToString();
                u.MemberType = ((int)dr["MemberType"]);
                list.Add(u);
            }
            cn.Close();
            return list;
            
        }
        public static int MemberAdd(String _Username,String _Password,int _MemberType)
        {
            SqlConnection cn = new SqlConnection(GlobalVariables.ConnCarlover);
            cn.Open();
            SqlCommand cmd = new SqlCommand("Insert Into Member(MemberID,Username,Password,MemberType) Values((select isnull(max(MemberID),0)+1 from Member),'" + _Username + "','" + _Password + "'," + _MemberType + ")", cn);
            int i = cmd.ExecuteNonQuery();
            
            cn.Close();
            return i;

        }

        public static int MemberDelete(int _MemberID)
        {
            SqlConnection cn = new SqlConnection(GlobalVariables.ConnCarlover);
            cn.Open();
            SqlCommand cmd = new SqlCommand("Delete from Member where MemberID = " + _MemberID , cn);
            int i = cmd.ExecuteNonQuery();

            cn.Close();
            return i;

        }
    }
}

