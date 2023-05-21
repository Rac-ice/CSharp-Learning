using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaterDal
{
    public static class SqliteHelper
    {
        //从配置文件中读取连接字符串
        #region Sqlite连接字符串
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["SqliteConnectionString"].ConnectionString;
        } 
        #endregion

        //执行命令的方法：insert，update，delete
        #region ExecuteNonQuery方法
        public static int ExecuteNonQuery(string sqlText, params SQLiteParameter[] parameters)
        {
            using (SQLiteConnection conn = new SQLiteConnection(GetConnectionString()))
            {
                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = sqlText;
                    cmd.Parameters.AddRange(parameters);//把参数添加到cmd命令中
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        #endregion

        //获取首行首列的方法
        #region ExecuteScalar方法
        public static object ExecuteScalar(string sqlText, params SQLiteParameter[] parameters)
        {
            using (SQLiteConnection conn = new SQLiteConnection(GetConnectionString()))
            {
                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = sqlText;
                    cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteScalar();
                }
            }
        }
        #endregion

        //获取结果集
        #region ExecuteDataTable方法
        public static DataTable ExecuteDataTable(string sqlText,params SQLiteParameter[] parameters)
        {
            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlText,GetConnectionString()))
            {
                DataTable dt = new DataTable();
                adapter.SelectCommand.Parameters.AddRange(parameters);
                adapter.Fill(dt);
                return dt;
            }
        }
        #endregion

        #region ExecuteReader方法
        public static SQLiteDataReader ExecuteReader(string sqlText,params SQLiteParameter[] parameters)
        {
            SQLiteConnection conn = new SQLiteConnection(GetConnectionString());
            SQLiteCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = sqlText;
            cmd.Parameters.AddRange(parameters);
            //CommandBehavior.CloseConnection：当sqlitedatareader释放时，顺便把sqliteconnection对象也释放掉
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
        #endregion
    }
}
