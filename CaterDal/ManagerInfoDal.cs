using CaterCommon;
using CaterModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaterDal
{
    public partial class ManagerInfoDal
    {
        /// <summary>
        /// 查询获取结果集
        /// </summary>
        /// <returns>结果集合</returns>
        public List<ManagerInfo> GetList()
        {
            //构造要查询的sql语句
            string sqlText = "select MId,MName,MPwd,MType from ManagerInfo";
            //使用helper进行查询，得到结果
            DataTable dt = SqliteHelper.ExecuteDataTable(sqlText);
            //将di中的数据转存到list中
            List<ManagerInfo> list = new List<ManagerInfo>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new ManagerInfo()
                {
                    MId = Convert.ToInt32(row["MId"]),
                    MName = row["MName"].ToString(),
                    MPwd = row["MPwd"].ToString(),
                    MType = Convert.ToInt32(row["MType"])
                });
            }
            //将集合返回
            return list;
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="mi">ManagerInfo类型对象</param>
        /// <returns>受影响行数</returns>
        public int Insert(ManagerInfo mi)
        {
            //构造insert语句
            string sqlText = "insert into ManagerInfo(mname,mpwd,mtype) values(@name,@pwd,@type)";
            //构造sql语句的参数
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@name",mi.MName),
                new SQLiteParameter("@pwd",Md5Helper.EncryptString(mi.MPwd)),//将密码进行MD5加密
                new SQLiteParameter("@type",mi.MType)
            };
            //执行插入操作
            return SqliteHelper.ExecuteNonQuery(sqlText, ps);
        }

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="mi">ManagerInfo类型对象</param>
        /// <returns>受影响行数</returns>
        public int Update(ManagerInfo mi)
        {
            //定义参数集合 可以动态添加元素
            List<SQLiteParameter> listPs = new List<SQLiteParameter>();
            //构造update的ssql语句
            string sqlText = "update ManagerInfo set mname=@name";
            listPs.Add(new SQLiteParameter("@name", mi.MName));
            //判断是否修改密码
            if (!mi.MPwd.Equals("这是原来的密码吗？"))
            {
                sqlText += ",mpwd=@pwd";
                listPs.Add(new SQLiteParameter("@pwd", Md5Helper.EncryptString(mi.MPwd)));
            }
            //拼接sql语句
            sqlText += ",mtype=@type where mid=@id";
            listPs.Add(new SQLiteParameter("@type", mi.MType));
            listPs.Add(new SQLiteParameter("@id", mi.MId));
            //执行语句并返回结果
            return SqliteHelper.ExecuteNonQuery(sqlText, listPs.ToArray());
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id">主键编号</param>
        /// <returns>受影响行数</returns>
        public int Delete(int id)
        {
            //构造删除的sql语句
            string sqlText = "delete from ManagerInfo where mid=@id";
            //根据语句删除构造参数
            SQLiteParameter p = new SQLiteParameter("@id", id);
            //执行操作
            return SqliteHelper.ExecuteNonQuery(sqlText,p);
        }

        /// <summary>
        /// 根据用户名查找对象
        /// </summary>
        /// <param name="name">用户名</param>
        /// <returns>ManagerInfo对象</returns>
        public ManagerInfo GetByName(string name)
        {
            //声明ManagerInfo对象
            ManagerInfo mi = null;
            //构造语句
            string sqlText = "select mid,mname,mpwd,mtype from ManagerInfo where mname=@name";
            //设置参数
            SQLiteParameter p = new SQLiteParameter("@name", name);

            #region ExecuteDataTable获取结果
            //执行查询 获取结果
            DataTable dt = SqliteHelper.ExecuteDataTable(sqlText, p);
            //判断是否根据用户名查找到了对象
            if (dt.Rows.Count > 0)
            {
                //用户名存在
                mi = new ManagerInfo()
                {
                    MId = Convert.ToInt32(dt.Rows[0][0]),
                    MName = name,
                    MPwd = dt.Rows[0][2].ToString(),
                    MType = Convert.ToInt32(dt.Rows[0][3])
                };
            }
            else
            {
                //用户名不存在
            }
            #endregion

            #region ExecuteReader获取结果
            //执行查询得到结果
            //SQLiteDataReader reader = SqliteHelper.ExecuteReader(sqlText, p);
            ////
            //if (reader.Read())
            //{
            //    //用户名存在
            //    mi = new ManagerInfo()
            //    {
            //        MId = Convert.ToInt32(reader["MId"].ToString()),
            //        MName = name,
            //        MPwd = reader["MPwd"].ToString(),
            //        MType = Convert.ToInt32(reader["MType"].ToString())
            //    };
            //}
            //else
            //{
            //    //用户名不存在
            //}
            #endregion

            return mi;
        }
    }
}
