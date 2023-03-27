using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace TestApplication.Models
{
    public static class Common
    {
        public static DataTable ExecuteProcedure(string ProcedureName, string[,] Param)
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings.Get("DBConnection"));
            SqlCommand cmd = new SqlCommand(ProcedureName, con);
            cmd.CommandType = CommandType.StoredProcedure;
            for(int i=0; i<Param.Length/2;i++)
            {
                cmd.Parameters.AddWithValue(Param[i,0], Param[i,1]);
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static DataTable ExecuteProcedure(string ProcedureName)
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings.Get("DBConnection"));
            SqlCommand cmd = new SqlCommand(ProcedureName, con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}