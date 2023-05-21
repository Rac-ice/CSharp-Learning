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
    public partial class HallInfoDal
    {
        public List<HallInfo> GetList()
        {
            string sqlText = "select hid,htitle from hallinfo where hisdelete=0";
            DataTable dt = SqliteHelper.ExecuteDataTable(sqlText);
            List<HallInfo> list = new List<HallInfo>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new HallInfo()
                {
                    HId = Convert.ToInt32(row["HId"]),
                    HTitle = row["HTitle"].ToString(),
                });
            }
            return list;
        }

        public int Insert(HallInfo hi)
        {
            string sqlText = "insert into hallinfo(htitle) values(@title)";
            SQLiteParameter p = new SQLiteParameter("@title",hi.HTitle);
            return SqliteHelper.ExecuteNonQuery(sqlText, p);
        }

        public int Update(HallInfo hi)
        {
            string sqlText = "update hallinfo set htitle=@title where hid=@id";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@title",hi.HTitle),
                new SQLiteParameter("@id",hi.HId)
            };
            return SqliteHelper.ExecuteNonQuery(sqlText, ps);
        }

        public int Delete(int id)
        {
            string sqlText = "update hallinfo set hisdelete=1 where hid=@id";
            SQLiteParameter p = new SQLiteParameter("@id",id);
            return SqliteHelper.ExecuteNonQuery(sqlText,p);
        }
    }
}
