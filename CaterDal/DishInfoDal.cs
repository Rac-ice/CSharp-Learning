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
    public partial class DishInfoDal
    {
        public List<DishInfo> GetList(Dictionary<string,string> dic)
        {
            string sqlText = "select di.*,dti.DTitle as DTypeTitle from DishInfo as di inner join DishTypeInfo as dti on di.DTypeId=dti.DId where di.DIsDelete=0 and dti.DIsDelete=0";
            List<SQLiteParameter> listP = new List<SQLiteParameter>();
            //接受筛选条件
            if (dic.Count > 0)
            {
                foreach (var pair in dic)
                {
                    sqlText += " and di." + pair.Key + " like '%" + pair.Value + "%'";
                    listP.Add(new SQLiteParameter("@" + pair.Key, "%" + pair.Value + "%"));
                }
            }
            DataTable dt = SqliteHelper.ExecuteDataTable(sqlText,listP.ToArray());
            List<DishInfo> list = new List<DishInfo>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new DishInfo()
                {
                    DId = Convert.ToInt32(row["DId"]),
                    DTitle = row["DTitle"].ToString(),
                    DTypeTitle = row["DTypeTitle"].ToString(),
                    DPrice = Convert.ToDecimal(row["DPrice"]),
                    DChar = row["DChar"].ToString()
                });
            }
            return list;
        }

        public int Insert(DishInfo di)
        {
            string sqlText = "insert into DishInfo(DTitle,DTypeId,DPrice,DChar) values(@title,@typeid,@price,@char)";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@title",di.DTitle),
                new SQLiteParameter("@typeid",di.DTypeId),
                new SQLiteParameter("@price",di.DPrice),
                new SQLiteParameter("@char",di.DChar)
            };
            return SqliteHelper.ExecuteNonQuery(sqlText,ps);
        }

        public int Update(DishInfo di)
        {
            string sqlText = "update DishInfo set DTitle=@title,DTypeId=@typeid,DPrice=@price,DChar=@char where DId=@id";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@title",di.DTitle),
                new SQLiteParameter("@typeid",di.DTypeId),
                new SQLiteParameter("@price",di.DPrice),
                new SQLiteParameter("@char",di.DChar),
                new SQLiteParameter("@id",di.DId)
            };
            return SqliteHelper.ExecuteNonQuery(sqlText,ps);
        }

        public int Delete(int id)
        {
            string sqlText = "update DishInfo set DIsDelete=1 where DId=@id";
            SQLiteParameter p = new SQLiteParameter("@id", id);
            return SqliteHelper.ExecuteNonQuery(sqlText, p);
        }
    }
}
