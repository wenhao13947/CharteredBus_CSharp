using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApi.DAL
{
    public class SqlHelper
    {
        public static string SqlConnString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        }

        /// <summary>
        /// 获取命令
        /// </summary>
        /// <param name="conn">连接字符串</param>
        /// <param name="transaction">事务，无可为null</param>
        /// <param name="sqlStr">数据库代码</param>
        /// <param name="parms">参数</param>
        /// <returns></returns>
        public static SqlCommand GetCommand(SqlConnection conn, SqlTransaction transaction, string sqlStr, SqlParameter[] parms)
        {
            //using (SqlConnection conn = new SqlConnection(connStr))
            //{
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 1000;
            if (transaction != null)
            {
                cmd.Transaction = transaction;
            }
            if (parms != null && parms.Length != 0)
            {
                cmd.Parameters.AddRange(parms);
            }
            return cmd;
            //}
        }
        public static DataTable GetDataTable(string sqlStr, SqlParameter[] parms)
        {
            if (string.IsNullOrEmpty(sqlStr))
            {
                throw new Exception("未设置参数：sql");
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(SqlConnString()))
                {
                    conn.Open();
                    using (SqlDataAdapter sda = new SqlDataAdapter(GetCommand(conn, null, sqlStr, parms)))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (SqlException ex)
            {
                System.Text.StringBuilder log = new System.Text.StringBuilder();
                log.Append("查询数据出错：");
                log.Append(ex);
                throw new Exception(log.ToString());
            }
        }

        public static DataSet GetDataSet(string sqlStr, SqlParameter[] parms)
        {
            if (string.IsNullOrEmpty(sqlStr))
            {
                throw new Exception("未设置参数：sql");
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(SqlConnString()))
                {
                    conn.Open();
                    using (SqlDataAdapter sda = new SqlDataAdapter(GetCommand(conn, null, sqlStr, parms)))
                    {
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        return ds;
                    }
                }
            }
            catch (SqlException ex)
            {
                System.Text.StringBuilder log = new System.Text.StringBuilder();
                log.Append("查询数据出错：");
                log.Append(ex);
                throw new Exception(log.ToString());
            }
        }

        public static object GetScalar(string sqlStr, SqlParameter[] parms)
        {
            if (string.IsNullOrEmpty(sqlStr))
            {
                throw new Exception("未设置参数：sql");
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(SqlConnString()))
                {
                    conn.Open();

                    using (SqlCommand cmd = GetCommand(conn, null, sqlStr, parms))
                    {
                        return cmd.ExecuteScalar();
                    }
                }
            }
            catch (SqlException ex)
            {
                System.Text.StringBuilder log = new System.Text.StringBuilder();
                log.Append("处理出错：");
                log.Append(ex);
                throw new Exception(log.ToString());
            }
        }

        public static int ExcuteResult(string sqlStr, SqlParameter[] parms)
        {
            if (string.IsNullOrEmpty(sqlStr))
            {
                throw new Exception("未设置参数：sql");
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(SqlConnString()))
                {
                    conn.Open();
                    SqlCommand cmd = GetCommand(conn, null, sqlStr, parms);
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                System.Text.StringBuilder log = new System.Text.StringBuilder();
                log.Append("处理出错：");
                log.Append(ex);
                throw new Exception(log.ToString());
            }
        }
    }
}