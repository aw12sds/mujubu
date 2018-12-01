using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using NetWork.util;
namespace mujubu
{
    class SQLhelp
    {
        private static readonly string connStr = "Data Source=10.15.1.252;Initial Catalog=db_xiangmuguanli;user id=sa;password=zttZTT123";
        public static DataTable GetDataTable(string sql, CommandType type, params SqlParameter[] pars)
        {
            DataTable dt = getData.getdata(sql, "db_xiangmuguanli");
            return dt;
        }
        public static DataTable GetDataTable_office(string sql, CommandType type, params SqlParameter[] pars)
        {
            DataTable dt = getData.getdata(sql, "db_office");
            return dt;
        }

        public static int ExecuteNonquery(string sql, CommandType type, byte[] files, params SqlParameter[] pars)
        {
            return getData.ExecuteNonquery(sql, "db_xiangmuguanli", files);
        }

        public static int ExecuteNonquerytuzhi(string sql, CommandType type, byte[] tuzhifiles, params SqlParameter[] pars)
        {
            return getData.ExecuteNonquerytuzhi(sql, "db_xiangmuguanli",tuzhifiles);
        }
        public static int ExecuteNonquery1(string sql, CommandType type, byte[] files, byte[] tuzhifiles, params SqlParameter[] pars)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    cmd.Parameters.Clear();

                    cmd.Parameters.Add("@pic", SqlDbType.VarBinary).Value = files;
                    cmd.Parameters.Add("@pictuzhi", SqlDbType.VarBinary).Value = tuzhifiles;
                    return cmd.ExecuteNonQuery();

                }
            }
        }
        public static int ExecuteNonquery2(string sql, CommandType type, params SqlParameter[] pars)
        {
            return int.Parse(getData.innn(sql, "db_xiangmuguanli").ToString());
        }
        public static object ExecuteScalar(string sql, CommandType type, params SqlParameter[] pars)
        {
            return getData.ExecuteScalar(sql, "db_xiangmuguanli");
        }
        public static object ExecuteScalar_db_office(string sql, CommandType type, params SqlParameter[] pars)
        {
            return getData.ExecuteScalar(sql, "db_office");
        }
      
        public static byte[] duqu(string sql, CommandType type, params SqlParameter[] pars)
        {

            byte[] bt = getData.duqu(sql, "db_xiangmuguanli");
            return bt;

           
        }
    }
}
