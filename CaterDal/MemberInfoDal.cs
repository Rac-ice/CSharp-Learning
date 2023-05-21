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
    public partial class MemberInfoDal
    {
        /// <summary>
        /// 查询获取结果集
        /// </summary>
        /// <returns>结果集合</returns>
        public List<MemberInfo> GetList(Dictionary<string,string> dic)
        {
            string sqlText = "select mi.*,mti.MTitle as MTypeTitle,mti.MDiscount from MemberInfo as mi inner join MemberTypeInfo as mti on mi.MTypeId = mti.MId where mi.MIsDelete=0";
            //参数化
            List<SQLiteParameter> listP = new List<SQLiteParameter>();
            //拼接条件
            if (dic.Count > 0)
            {
                foreach (var pair in dic)
                {
                    sqlText += " and mi." + pair.Key + " like '%" + pair.Value + "%'";
                    listP.Add(new SQLiteParameter("@" + pair.Key, "%" + pair.Value + "%"));
                }
            }
            DataTable dt = SqliteHelper.ExecuteDataTable(sqlText,listP.ToArray());
            List<MemberInfo> list = new List<MemberInfo>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new MemberInfo()
                {
                    MId = Convert.ToInt32(row["MId"]),
                    MTypeId = Convert.ToInt32(row["MTypeId"]),
                    MName = row["MName"].ToString(),
                    MPhone = row["MPhone"].ToString(),
                    MMoney = Convert.ToDecimal(row["MMoney"]),
                    MTypeTitle = row["MTypeTitle"].ToString(),
                    MDiscount = Convert.ToDecimal(row["MDiscount"])
                });
            }
            return list;
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="mi">MemberInfo对象</param>
        /// <returns>受影响行数</returns>
        public int Insert(MemberInfo mi)
        {
            string sqlText = "insert into memberinfo(mtypeid,mname,mphone,mmoney) values(@typeid,@name,@phone,@money)";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@typeid",mi.MTypeId),
                new SQLiteParameter("@name",mi.MName),
                new SQLiteParameter("@phone",mi.MPhone),
                new SQLiteParameter("@money",mi.MMoney)
            };
            return SqliteHelper.ExecuteNonQuery(sqlText,ps);
        }

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="mi">MemberInfo对象</param>
        /// <returns>受影响行数</returns>
        public int Update(MemberInfo mi)
        {
            string sqlText = "update memberinfo set mtypeid=@typeid,mname=@name,mphone=@phone,mmoney=@money where mid=@id";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@typeid",mi.MTypeId),
                new SQLiteParameter("@name",mi.MName),
                new SQLiteParameter("@phone",mi.MPhone),
                new SQLiteParameter("@money",mi.MMoney),
                new SQLiteParameter("@id",mi.MId)
            };
            return SqliteHelper.ExecuteNonQuery(sqlText, ps);
        }

        /// <summary>
        /// 软删除，修改数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>受影响行数</returns>
        public int Delete(int id)
        {
            string sqlText = "update memberinfo set MIsDelete=1 where mid=@id";
            SQLiteParameter p = new SQLiteParameter("@id", id);
            return SqliteHelper.ExecuteNonQuery(sqlText,p);
        }
    }
}
