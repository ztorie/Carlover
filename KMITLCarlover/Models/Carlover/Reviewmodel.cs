using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using Kendo.Mvc.UI;
using System.Web.Mvc;

namespace KMITL.Carlover.Models
{
    public class Reviewmodel
    {     
        ////[Required]
        //[Display(Name = "Username :")]
        //public string Username { get; set; }
        ////[Required]
        
        //[Display(Name = "Password :")]
        //public string Password { get; set; }
        ////[Required]
        
        //[Display(Name = "CheckPassword :")]
        //public string CheckPassword { get; set; }
        ////[Required]
        //[Display(Name = "Email :")]
        //public string Email { get; set; }
        ////[Required]
        //[Display(Name = "MemberType :")]
        //public int MemberType { get; set; }
        ////[Required]
        //[Display(Name = "StatusName :")]
        //public string StatusName { get; set; }
        ////[Required]
        //[Display(Name = "Name :")]
        //public string Name { get; set; }
        ////[Required]
        //[Display(Name = "Surname :")]
        //public string Surname { get; set; }
        ////[Required]
        //[Display(Name = "Gender :")]
        //public string Gender { get; set; }
        ////[Required]
        //[Display(Name = "Latitude :")]
        //public string Latitude { get; set; }
        ////[Required]
        //[Display(Name = "Longitude :")]
        //public string Longitude { get; set; }

        [AllowHtml]
        public string Content { get; set; }




        //public static int Registercheck(string Username1, string Password1, string Email1, int MemberType1)
        //{
        //    List<Registermodel> list = new List<Registermodel>();
        //    SqlConnection cn = new SqlConnection(GlobalVariables.ConnCarlover);
        //    cn.Open();
        //    SqlCommand cmd = new SqlCommand("Select Username,Password,Email From Member", cn);
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        Registermodel u = new Registermodel();
        //        u.Username = dr["Username"].ToString();
        //        u.Password = dr["Password"].ToString();
        //        u.Email = dr["Email"].ToString();
        //        list.Add(u);
        //    }
        //    cn.Close();
        //    int i = list.Count;
        //    int result = 1;
        //    for (int j=0; j < i; j++)
        //    {
        //        if (Username1 == list[j].Username || Email1 == list[j].Email) { result = 0; }       
        //    }
        //    return result;
            
        //}

        public static int insertreview(string _content,string _memberID)
        {
            string c = _content;
            //List<Registermodel> list = new List<Registermodel>();
            //SqlConnection cn = new SqlConnection(GlobalVariables.ConnCarlover);
            //cn.Open();
            //SqlCommand cmd = new SqlCommand("Select MemberType,StatusName From Status where MemberType <> 4 ", cn);
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //foreach (DataRow dr in dt.Rows)
            //{
            //    Registermodel u = new Registermodel();
            //    u.MemberType = ((int)dr["MemberType"]);
            //    u.StatusName = dr["StatusName"].ToString();
            //    list.Add(u);
            //}
            //cn.Close();
            return 0;
        }
    }
}

