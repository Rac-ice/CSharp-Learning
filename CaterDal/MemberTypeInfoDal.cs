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
    public partial class MemberTypeInfoDal
    {
        /// <summary>
        /// 查询获取结果集
        /// </summary>
        /// <returns>结果集合</returns>
        public List<MemberTypeInfo> GetList()
        {
            //查询未删除的数据
            string sqlText = "select MId,MTitle,MDiscount,MIsDelete from MemberTypeInfo where MIsDelete=0";
            //执行查询返回表格
            DataTable dt = SqliteHelper.ExecuteDataTable(sqlText);
            //定义集合对象
            List<MemberTypeInfo> list = new List<MemberTypeInfo>();
            //遍历表格，将数据转存到集合中
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new MemberTypeInfo()
                {
                    MId = Convert.ToInt32(row["MId"]),
                    MTitle = row["MTitle"].ToString(),
                    MDiscount = Convert.ToDecimal(row["MDiscount"])
                });
            }
            return list;
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="mti">MemberTypeInfo对象</param>
        /// <returns>受影响行数</returns>
        public int Insert(MemberTypeInfo mti)
        {
            //构造insert语句
            string sqlText = "insert into MemberTypeInfo(mtitle,mdiscount) values(@title,@discount)";
            //为sql语句构造参数
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@title",mti.MTitle),
                new SQLiteParameter("@discount",mti.MDiscount)
            };
            //执行
            return SqliteHelper.ExecuteNonQuery(sqlText, ps);
        }

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="mti">MemberTypeInfo对象</param>
        /// <returns>受影响行数</returns>
        public int Update(MemberTypeInfo mti)
        {
            //构造update语句
            string sqlText = "update MemberTypeInfo set mtitle=@title, mdiscount=@discount where mid=@id";
            //为语句构造参数
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@title",mti.MTitle),
                new SQLiteParameter("@discount",mti.MDiscount),
                new SQLiteParameter("@id",mti.MId)
            };
            //执行
            return SqliteHelper.ExecuteNonQuery(sqlText, ps);
        }

        /// <summary>
        /// 软删除操作，修改语句
        /// </summary>
        /// <param name="id">主键编号</param>
        /// <returns>受影响行数</returns>
        public int Delete(int id)
        {
            //构建sql语句
            string sqlText = "update MemberTypeInfo set MIsDelete=1 where mid=@id";
            //设置参数
            SQLiteParameter p = new SQLiteParameter("@id", id);
            //执行
            return SqliteHelper.ExecuteNonQuery(sqlText, p);
        }
    }
}
