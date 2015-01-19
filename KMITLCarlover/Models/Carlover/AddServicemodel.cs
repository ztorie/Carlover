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
    public class AddServiceModel
    {
        //[Required]
        [Display(Name = "ServiceID :")]
        public int ServiceID { get; set; }
        //[Required]
        [Display(Name = "Service :")]
        public string Service { get; set; }


        public static List<AddServiceModel> MemberSelect()
        {
            List<AddServiceModel> list = new List<AddServiceModel>();
            SqlConnection cn = new SqlConnection(GlobalVariables.ConnCarlover);
            cn.Open();
            SqlCommand cmd = new SqlCommand("Select ServiceID,Service From Service", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                AddServiceModel u = new AddServiceModel();
                u.ServiceID = ((int)dr["ServiceID"]);
                u.Service = dr["Service"].ToString();

                list.Add(u);
            }
            cn.Close();
            return list;

        }
        public static int MemberAdd(int _ServiceID, string _Service)
        {
            SqlConnection cn = new SqlConnection(GlobalVariables.ConnCarlover);
            cn.Open();
            SqlCommand cmd = new SqlCommand("Insert Into Service(ServiceID,Service) Values((select isnull(max(ServiceID),0)+1 from Service),'" + _Service + "')", cn);
            int i = cmd.ExecuteNonQuery();

            cn.Close();
            return i;
        }
        public static int MemberUpdate(int _ServiceID, string _Service)
        {
            SqlConnection cn = new SqlConnection(GlobalVariables.ConnCarlover);
            cn.Open();
            SqlCommand cmd = new SqlCommand("Update Service set Service = '" + _Service + "' where ServiceID = " + _ServiceID, cn);
            int i = cmd.ExecuteNonQuery();

            cn.Close();
            return i;
        }
        public static int MemberDelete(int _ServiceID)
        {
            SqlConnection cn = new SqlConnection(GlobalVariables.ConnCarlover);
            cn.Open();
            SqlCommand cmd = new SqlCommand("Delete from Service where ServiceID = " + _ServiceID, cn);
            int i = cmd.ExecuteNonQuery();

            cn.Close();
            return i;

        }
    }
}

