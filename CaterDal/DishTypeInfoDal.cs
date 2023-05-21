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
    public partial class DishTypeInfoDal
    {
        public List<DishTypeInfo> GetList()
        {
            string sqlText = "select DId,DTitle from DishTypeInfo where DIsDelete=0";
            DataTable dt = SqliteHelper.ExecuteDataTable(sqlText);
            List<DishTypeInfo> list = new List<DishTypeInfo>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new DishTypeInfo()
                {
                    DId = Convert.ToInt32(row["DId"]),
                    DTitle = row["DTitle"].ToString()
                });
            }
            return list;
        }

        public int Insert(DishTypeInfo dti)
        {
            string sqlText = "insert into DishTypeInfo(DTitle) values(@title)";
            SQLiteParameter p = new SQLiteParameter("@title",dti.DTitle);
            return SqliteHelper.ExecuteNonQuery(sqlText, p);
        }

        public int Update(DishTypeInfo dti)
        {
            string sqlText = "update DishTypeInfo set DTitle=@title where DId=@id";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@title",dti.DTitle),
                new SQLiteParameter("@id",dti.DId)
            };
            return SqliteHelper.ExecuteNonQuery(sqlText, ps);
        }

        public int Delete(int id)
        {
            string sqlText = "update DishTypeInfo set DIsDelete=1 where DId=@id";
            SQLiteParameter p = new SQLiteParameter("@id", id);
            return SqliteHelper.ExecuteNonQuery(sqlText, p);
        }
    }
}
