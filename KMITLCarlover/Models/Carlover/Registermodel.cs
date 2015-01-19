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
    public class Registermodel
    {     
        //[Required]
        [Display(Name = "Username :")]
        public string Username { get; set; }
        //[Required]
        
        [Display(Name = "Password :")]
        public string Password { get; set; }
        //[Required]
        
        [Display(Name = "CheckPassword :")]
        public string CheckPassword { get; set; }
        //[Required]
        [Display(Name = "Email :")]
        public string Email { get; set; }
        //[Required]
        [Display(Name = "MemberType :")]
        public string MemberType { get; set; }
        //[Required]
        [Display(Name = "Name :")]
        public string Name { get; set; }
        //[Required]
        [Display(Name = "Surname :")]
        public string Surname { get; set; }
        //[Required]
        [Display(Name = "Gender :")]
        public string Gender { get; set; }
        //[Required]
        [Display(Name = "Latitude :")]
        public double Latitude { get; set; }
        //[Required]
        [Display(Name = "Longitude :")]
        public double Longitude { get; set; }
        //[Required]
        [Display(Name = "SubDistrictName :")]
        public string  SubDistrictName { get; set; }
        //[Required]
        [Display(Name = "DistrictName :")]
        public string  DistrictName { get; set; }
        //[Required]
        [Display(Name = "ProvinceName :")]
        public string ProvinceName { get; set; }

        public static int Registercheck(string Username1, string Password1, string Email1, string MemberType1)
        {
            List<Registermodel> list = new List<Registermodel>();
            SqlConnection cn = new SqlConnection(GlobalVariables.ConnCarlover);
            cn.Open();
            SqlCommand cmd = new SqlCommand("Select Username,Password,Email From Member", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                Registermodel u = new Registermodel();
                u.Username = dr["Username"].ToString();
                u.Password = dr["Password"].ToString();
                u.Email = dr["Email"].ToString();
                list.Add(u);
            }
            cn.Close();
            int i = list.Count;
            int result = 1;
            for (int j=0; j < i; j++)
            {
                if (Username1 == list[j].Username || Email1 == list[j].Email) { result = 0; }       
            }
            return result;
            
        }

        public static int RegisterMemberinsert(string Username1, string Password1, string Email1, double Latitude1, double Longitude1 , string Name1 , string Gender1)
        {
            SqlConnection cn = new SqlConnection(GlobalVariables.ConnCarlover);
            cn.Open();
            int i;
            SqlCommand cmd = new SqlCommand("insert into Member(Username,Password,Email,Latitude,Longitude,MemberType) Values('" + Username1 + "','" + Password1 + "','" + Email1 + "'," + Latitude1 + "," + Longitude1 + ",'Member')"
                + " insert into NormalMember(MemberID,Name,Gender) Values((select MemberID from Member where Username = '" + Username1 + "'),'" + Name1 + "','" + Gender1 + "')", cn);
            i = cmd.ExecuteNonQuery();
            cn.Close();
            return i;
        }
        public static int RegisterGarageinsert(string Username1, string Password1, string Email1, double Latitude1, double Longitude1, string Name1, string SubDistrictName1)
        {
            SqlConnection cn = new SqlConnection(GlobalVariables.ConnCarlover);
            cn.Open();
            int i;
            SqlCommand cmd = new SqlCommand("insert into Member(Username,Password,Email,Latitude,Longitude,MemberType) Values('" + Username1 + "','" + Password1 + "','" + Email1 + "'," + Latitude1 + "," + Longitude1 + ",'GarageMember')"
                + " insert into GarageMember(GarageMemberID,Name,SubDistrictName) Values((select MemberID from Member where Username = '" + Username1 + "'),'" + Name1 + "','" + SubDistrictName1 + "')", cn);
            i = cmd.ExecuteNonQuery();
            cn.Close();
            return i;
        }
        public static List<Registermodel> CSubDistrict(string Districtfilter)
        {
            List<Registermodel> list = new List<Registermodel>();
            SqlConnection cn = new SqlConnection(GlobalVariables.ConnCarlover);
            cn.Open();
            SqlCommand cmd = new SqlCommand("Select SubDistrictName From SubDistrict where DistrictName = '" + Districtfilter + "'", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                Registermodel u = new Registermodel();
                u.SubDistrictName = dr["SubDistrictName"].ToString();
                list.Add(u);
            }
            cn.Close();
            return list;
        }
        public static List<Registermodel> CDistrict(string Provincefilter)
        {
            List<Registermodel> list = new List<Registermodel>();
            SqlConnection cn = new SqlConnection(GlobalVariables.ConnCarlover);
            cn.Open();
            SqlCommand cmd = new SqlCommand("Select DistrictName From District where ProvinceName = '" + Provincefilter + "'", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                Registermodel u = new Registermodel();
                u.DistrictName = dr["DistrictName"].ToString();
                list.Add(u);
            }
            cn.Close();
            return list;
        }
        public static List<Registermodel> CProvince()
        {
            List<Registermodel> list = new List<Registermodel>();
            SqlConnection cn = new SqlConnection(GlobalVariables.ConnCarlover);
            cn.Open();
            SqlCommand cmd = new SqlCommand("Select ProvinceName From District", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                Registermodel u = new Registermodel();
                u.ProvinceName = dr["ProvinceName"].ToString();
                list.Add(u);
            }
            cn.Close();
            return list;
        }

        public static void insertmap(string province1,string district1, string subdistrict1)
        {
            SqlConnection cn = new SqlConnection(GlobalVariables.ConnCarlover);
            cn.Open();
            int i;
            SqlCommand cmd = new SqlCommand("declare @check int"
                + " set @check = 1"
                + " select @check = 0 from SubDistrict where SubDistrictName <> '" + subdistrict1 + "'"
                + " if(@check = 0)"
                + " begin"
                + " insert into District(ProvinceName,DistrictName) Values('" + province1 + "','" + district1 + "')"
                + " insert into SubDistrict(DistrictName,SubDistrictName) Values('" + district1 + "','" + subdistrict1 + "')"
                + " end", cn);
            i = cmd.ExecuteNonQuery();
            cn.Close();
        }
        //public static List<Registermodel> SelectMemberType()
        //{
        //    List<Registermodel> list = new List<Registermodel>();
        //    SqlConnection cn = new SqlConnection(GlobalVariables.ConnCarlover);
        //    cn.Open();
        //    SqlCommand cmd = new SqlCommand("Select MemberType From Member where MemberType <> 'Administrator' ", cn);
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        Registermodel u = new Registermodel();
        //        u.MemberType = dr["MemberType"].ToString();
        //        list.Add(u);
        //    }
        //    cn.Close();
        //    return list;
        //}
    }
}

