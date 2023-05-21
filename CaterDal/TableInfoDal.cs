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
    public partial class TableInfoDal
    {
        public List<TableInfo> GetList(Dictionary<string,string> dic)
        {
            string sqlText = "select tid,ttitle,thallid,hi.HTitle,tisfree from tableinfo as ti inner join hallinfo as hi on ti.THallId=hi.HId where ti.TIsDelete=0 and hi.HIsDelete=0";

            List<SQLiteParameter> listP = new List<SQLiteParameter>();
            if (dic.Count > 0)
            {
                foreach (var pair in dic)
                {
                    sqlText += " and " + pair.Key + " =" + pair.Value;
                    listP.Add(new SQLiteParameter("@"+ pair.Key, pair.Value));
                }
            }

            DataTable dt = SqliteHelper.ExecuteDataTable(sqlText);
            List<TableInfo> list = new List<TableInfo>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new TableInfo()
                {
                    TId = Convert.ToInt32(row["TId"]),
                    TTitle = row["TTitle"].ToString(),
                    HTitle = row["HTitle"].ToString(),
                    TIsFree = Convert.ToBoolean(row["TIsFree"]),
                    THallId = Convert.ToInt32(row["THallId"])
                });
            }
            return list;
        }

        public int Insert(TableInfo ti)
        {
            string sqlText = "insert into tableinfo(ttitle,thallid,tisfree) values(@title,@hallid,@isfree)";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@title",ti.TTitle),
                new SQLiteParameter("@hallid",ti.THallId),
                new SQLiteParameter("@isfree",ti.TIsFree)
            };
            return SqliteHelper.ExecuteNonQuery(sqlText, ps);
        }

        public int Update(TableInfo ti)
        {
            string sqlText = "update tableinfo set ttitle=@title,thallid=@hallid,tisfree=@isfree where tid=@id";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@title",ti.TTitle),
                new SQLiteParameter("@hallid",ti.THallId),
                new SQLiteParameter("@isfree",ti.TIsFree),
                new SQLiteParameter("@id",ti.TId)
            };
            return SqliteHelper.ExecuteNonQuery(sqlText,ps);
        }

        public int Delete(int id)
        {
            string sqlText = "update tableinfo set tisdelete=1 where tid=@id";
            SQLiteParameter p = new SQLiteParameter("@id", id);
            return SqliteHelper.ExecuteNonQuery(sqlText, p);
        }

        //public int SetState(int tableId,bool isFree)
        //{
        //    string sqlText = "update tableinfo ser tisfree=@isfree where tid=@tid";
        //    SQLiteParameter[] ps =
        //    {
        //        new SQLiteParameter("@isfree",isFree?1:0),
        //        new SQLiteParameter("@tid",tableId)
        //    };
        //    return SqliteHelper.ExecuteNonQuery(sqlText, ps);
        //}
    }
}
