using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using System.Data.SqlClient;
namespace KMITL.Carlover
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }

    public static class GlobalVariables
    {
        // readonly variable
        public static string ConnTimeTable
        {
            get
            {
                //return @"Data Source=localhost;Initial Catalog=TimeTable;User ID=sa;Password=cross00;";
                return System.Configuration.ConfigurationManager.ConnectionStrings["TimeTableConnectionString"].ConnectionString;
            }
        }
        // readonly variable
        public static string ConnExamSchedule
        {
            get
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings["ExamScheduleConnectionString"].ConnectionString;
            }
        }
        public static string ConnAcademicCalender
        {
            get
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings["AcademicCalenderConnectionString"].ConnectionString;
            }
        }
        public static string ConnCarlover
        {
            get
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings["CarloverConnectionString"].ConnectionString;
            }
        }


        public static int TimeTableTabIndex { get; set; }
        public static int ExamScheduleIndex { get; set; }
        //public static SqlConnection CnTimeTable
        //{
        //    get
        //    {
                
        //        //SqlConnection sc = new SqlConnection(@"Data Source=localhost;Initial Catalog=TimeTable;User ID=sa;Password=cross00;");
        //        SqlConnection sc = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TimeTableConnectionString"].ConnectionString);
        //        //sc.Open();
                
        //        return sc;
        //    }
        //}


        // read-write variable
        //public static string LanguageCulture
        //{
        //    get
        //    {
        //        return HttpContext.Current.Application["LanguageCulture"] as string;
        //    }
        //    set
        //    {
        //        HttpContext.Current.Application["LanguageCulture"] = value;
        //    }
        //}

        public static int ACIdx { get; set; }
        public static int HoIdx { get; set; }
        private static DateTime startx;
        public static DateTime Startx
        {
            get
            {
                return startx;
            }
            set
            {
                startx = value.ToUniversalTime();
            }
        }
        private static DateTime endx;
        public static DateTime Endx
        {
            get
            {
                return endx;
            }
            set
            {
                endx = value.ToUniversalTime();
            }
        }
        public static string Descriptionx { get; set; }
        public static bool IsAllDayx { get; set; }
        public static string RecurrenceRulex { get; set; }
        public static string RecurrenceExceptionx { get; set; }
        public static int RecurrenceIDx { get; set; }
    }
}