using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Diagnostics;
 
namespace KMITL.Carlover.Models
{
    public class SQLQuery
    {
        static TraceSwitch tsw = new TraceSwitch("mySwitch", "SQLQuery trace switch");

        static public bool ExecStored(string connStr, string storeName, SqlParameter[] parameter)
        {
            /*
            System.Data.SqlClient.SqlParameter[] sPara = new System.Data.SqlClient.SqlParameter[2];
            sPara[0] = new System.Data.SqlClient.SqlParameter("@passport_id",SqlDbType.VarChar);
            sPara[0].Value = "ss";
            sPara[1] = new System.Data.SqlClient.SqlParameter("@cancelled_by",SqlDbType.VarChar);
            sPara[1].Value = "ss";
            
            if (tsw.TraceInfo && parameter != null)
            {
                string paraValue = string.Empty;
                for (int iLog = 0; iLog < parameter.Length; iLog++)
                {
                    paraValue += string.Format(" Para[{0}] = {1}", iLog, parameter[iLog].Value.ToString());
                }
                WriteLog(tsw.TraceInfo, "ExecStored", String.Format("ConnStr : {0}\r\nstoreName :{1} \r\nParameter : {2}", connStr, storeName, paraValue));
            }
*/
 
            bool success = false;
            SqlConnection sqlconn = new SqlConnection(connStr);
            try
            {
                SqlCommand cm = new SqlCommand();
                cm.Connection = sqlconn;
                cm.CommandText = storeName;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandTimeout = 1000000;
              /*  if (_commandTimeout != null && _commandTimeout != string.Empty)
                {
                    cm.CommandTimeout = Convert.ToInt32(_commandTimeout);
                }*/
                if (parameter != null && parameter.Length > 0)
                {
                    for (int iPara = 0; iPara < parameter.Length; iPara++)
                    {
                        cm.Parameters.Add(parameter[iPara]);
                    }

                }

                sqlconn.Open();
                cm.ExecuteNonQuery();
                sqlconn.Close();
                success = true;
            }
            catch (SqlException ex)
            {
                if (sqlconn != null)
                {
                    sqlconn.Close();
                }
               
                //EventLogInfo.WriteLog(tsw.TraceError, String.Format("ConnStr : {0}\r\nStoredName :{1}\r\nError : {2}", connStr, storeName, ex.Message + "\r\n" + ex.StackTrace));
            }
            catch (Exception ex)
            {
                //EventLogInfo.WriteLog(tsw.TraceError, String.Format("ConnStr : {0}\r\nStoredName :{1}\r\nError : {2}", connStr, storeName, ex.Message + "\r\n" + ex.StackTrace));
            }
            return success;
        }


        static public SqlParameter[] ExecStored(string connStr, string storeName, SqlParameter[] parameter, SqlParameter[] parameterOutput)
        {
            //System.Data.SqlClient.SqlParameter[] sPara = new System.Data.SqlClient.SqlParameter[1];
            //sPara[0] = new System.Data.SqlClient.SqlParameter("@response", SqlDbType.VarChar, 5);
            //sPara[0].Direction = System.Data.ParameterDirection.Output;

            SqlParameter[] result = new SqlParameter[parameterOutput.Length];
            SqlConnection sqlconn = new SqlConnection(connStr);
            try
            {

                SqlCommand cm = new SqlCommand();
                cm.Connection = sqlconn;
                cm.CommandText = storeName;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandTimeout = 1000000;
                
                if (parameter != null && parameter.Length > 0)
                {
                    for (int iPara = 0; iPara < parameter.Length; iPara++)
                    {
                        cm.Parameters.Add(parameter[iPara]);
                    }
                }

                if (parameterOutput != null && parameterOutput.Length > 0)
                {
                    for (int iPara = 0; iPara < parameterOutput.Length; iPara++)
                    {
                        cm.Parameters.Add(parameterOutput[iPara]);
                    }
                }

                sqlconn.Open();
                cm.ExecuteNonQuery();
                sqlconn.Close();

                for (int iResult = 0; iResult < parameterOutput.Length; iResult++)
                {
                    result[iResult] = parameterOutput[iResult];
                }
            }
            catch (Exception ex)
            {
                if (sqlconn != null)
                {
                    sqlconn.Close();
                }
            }

            return result;
        }

        /*
        static public bool ExecStored(string connStr, string storeName, SqlParameter[] parameter)
        {

            bool success = false;
            SqlConnection sqlconn = new SqlConnection(connStr);
            try
            {
                SqlCommand cm = new SqlCommand();
                cm.Connection = sqlconn;
                cm.CommandText = storeName;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandTimeout = 1000000;
                
                if (parameter != null && parameter.Length > 0)
                {
                    for (int iPara = 0; iPara < parameter.Length; iPara++)
                    {
                        cm.Parameters.Add(parameter[iPara]);
                    }

                }

                sqlconn.Open();
                cm.ExecuteNonQuery();
                sqlconn.Close();
                success = true;
            }
            catch (SqlException ex)
            {
                if (sqlconn != null)
                {
                    sqlconn.Close();
                }
                // WriteLog(tsw.TraceError, "ExecStored", String.Format("ConnStr : {0}\r\nStoredName :{1}\r\nError : {2}", connStr, storeName, ex.Message + "\r\n" + ex.StackTrace));
            }
            catch (Exception ex)
            {
                //   WriteLog(tsw.TraceError, "ExecStored", String.Format("ConnStr : {0}\r\nStoredName :{1}\r\nError : {2}", connStr, storeName, ex.Message + "\r\n" + ex.StackTrace));
            }
            return success;
        }

       
          public static int AssignmentInsert(int _InId, int _CoId, int _RtId, List<int> _SeId, int _Duration, int _TimePerWeek, int _TimePerTerm)
        {
           
            SqlConnection cn = new SqlConnection(GlobalVariables.ConnTimeTable);
            cn.Open();


            DataTable dt = new DataTable();
            dt.Columns.Add("@Seid", typeof(int));
            
                foreach (int  item in _SeId  )
                {
                    dt.Rows.Add(item);
                }

            
                SqlCommand cmd = new SqlCommand(" exec AssignmentInsert1 " + _InId.ToString() + "," + _CoId.ToString() + "," + _RtId.ToString() + "," + _Duration.ToString() + "," + _TimePerWeek.ToString() + "," + _TimePerTerm.ToString()+ ",@SeId", cn); 
                cmd.CommandType = CommandType.Text;


                var parameter = cmd.Parameters.AddWithValue("@SeId", dt);
                parameter.SqlDbType = SqlDbType.Structured;
                parameter.TypeName = "dbo.Assignment";



                //SqlCommand cmdProc = new SqlCommand("ExamAssignmentInsert", cn);
                //cmdProc.CommandType = CommandType.StoredProcedure;
                //cmdProc.Parameters.AddWithValue("@InId", _InId);
                //cmdProc.Parameters.AddWithValue("@CoId", _CoId);
                //cmdProc.Parameters.AddWithValue("@RtId", _RtId);
                //cmdProc.Parameters.AddWithValue("@Duration", _Duration);
                //cmdProc.Parameters.AddWithValue("@TimePerWeek", _TimePerWeek);
                //cmdProc.Parameters.AddWithValue("@TimePerTerm", _TimePerTerm);
                // cmdProc.Parameters.AddWithValue("@SeId", dt);
                //int i = cmdProc.ExecuteNonQuery();





             int i = cmd.ExecuteNonQuery();
             cn.Close();
             return i; 
            
       }

         */
    }

}




  