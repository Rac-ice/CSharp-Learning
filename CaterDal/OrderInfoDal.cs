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
    public partial class OrderInfoDal
    {
        public int OpenOrder(int tableId)
        {
            //下订单
            //更新餐桌状态
            //获取最新的订单编号
            string sqlText = "insert into orderinfo(odate,ispay,tableid) values(datetime('now', 'localtime'),0,@tid);update tableinfo set tisfree=0 where tid=@tid;select oid from orderinfo  order by oid desc limit 0,1";
            SQLiteParameter p = new SQLiteParameter("@tid", tableId);
            return Convert.ToInt32(SqliteHelper.ExecuteScalar(sqlText, p));
        }

        public int GetOrderIdByTableId(int tableId)
        {
            string sqlText = "select oid from orderinfo where tableId=@tableid and ispay=0";
            SQLiteParameter p = new SQLiteParameter("@tableid", tableId);
            return Convert.ToInt32(SqliteHelper.ExecuteScalar(sqlText, p));
        }

        public int OrderDish(int orderId,int dishId)
        {
            string sqlText = "select count(*) from orderDetailInfo where orderId=@oid and dishId=@did";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@oid",orderId),
                new SQLiteParameter("@did",dishId)
            };
            int count = Convert.ToInt32(SqliteHelper.ExecuteScalar(sqlText,ps));
            if (count > 0)
            {
                //数量加1
                sqlText = "update orderDetailInfo set count=count+1 where orderId=@oid and dishId=@did";
            }
            else
            {
                //新加
                sqlText = "insert into orderdetailinfo(orderid,dishid,count) values(@oid,@did,1)";
            }
            
            
            return SqliteHelper.ExecuteNonQuery(sqlText, ps);
        }

        public int UpdateCountByOId(int oid,int count)
        {
            string sqlText = "update orderDetailInfo set count=@count where oid=@oid";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@count",count),
                new SQLiteParameter("@oid",oid)
            };
            return SqliteHelper.ExecuteNonQuery(sqlText, ps);
        }

        public List<OrderDetailInfo> GetDetailList(int orderId)
        {
            string sqlText = "select odi.oid,di.dTitle,di.dPrice,odi.count from dishinfo as di inner join orderDetailInfo as odi on di.did=odi.dishid where odi.orderId=@orderid";
            SQLiteParameter p = new SQLiteParameter("@orderid",orderId);
            DataTable dt = SqliteHelper.ExecuteDataTable(sqlText, p);
            List<OrderDetailInfo> list = new List<OrderDetailInfo>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new OrderDetailInfo()
                {
                    OId = Convert.ToInt32(row["OId"]),
                    DTitle = row["DTitle"].ToString(),
                    DPrice = Convert.ToDecimal(row["DPrice"]),
                    Count = Convert.ToInt32(row["Count"]),
                });
            }
            return list;
        }

        public decimal GetTotalMoneyByOrderId(int orderid)
        {
            string sqlText = "select sum(oti.count*di.dprice) from orderdetailinfo as oti inner join dishinfo as di on oti.dishid=di.did where oti.orderid=@orderid";
            SQLiteParameter p = new SQLiteParameter("@orderid", orderid);
            return Convert.ToInt32(SqliteHelper.ExecuteScalar(sqlText, p));
        }

        public int SetOrderMoney(int orderid,decimal money)
        {
            string sqlText = "update orderinfo set omoney=@money where oid=@oid";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@money",money),
                new SQLiteParameter("@oid",orderid)
            };
            return SqliteHelper.ExecuteNonQuery(sqlText, ps);
        }

        public int DeleteDetailById(int oid)
        {
            string sqlText = "delete from orderDetailInfo where oid=@oid";
            SQLiteParameter p = new SQLiteParameter("@oid", oid);
            return SqliteHelper.ExecuteNonQuery(sqlText,p);
        }

        public int Pay(bool isUseMoney,int memberId,decimal payMoney,int orderId,decimal discount)
        {
            //创建数据库的链接对象
            using (SQLiteConnection conn = new SQLiteConnection(SqliteHelper.GetConnectionString()))
            {
                int result = 0;
                conn.Open();
                //由数据库链接对象创建事务
                SQLiteTransaction tran = conn.BeginTransaction();
                //创建command对象
                SQLiteCommand cmd = new SQLiteCommand();
                //将命令对象启用事务
                cmd.Transaction = tran;
                //执行命令
                string sqlText = string.Empty;
                SQLiteParameter[] ps;
                try
                {
                    //1、根据是否用余额决定扣款方式
                    if (isUseMoney)
                    {
                        //使用余额
                        sqlText = "update memberinfo set mMoney=mMoney-@payMoney where mid=@mid";
                        ps = new SQLiteParameter[]
                        {
                        new SQLiteParameter("@payMoney",payMoney),
                        new SQLiteParameter("@mid",memberId)
                        };
                        cmd.CommandText = sqlText;
                        cmd.Parameters.AddRange(ps);
                        result += cmd.ExecuteNonQuery();
                    }
                    //2、将订单状态为IsPage=1
                    sqlText = "update orderInfo set isPay=1,memberId=@mid,discount=@discount where oid=@oid";
                    ps = new SQLiteParameter[]
                    {
                    new SQLiteParameter("@mid",memberId),
                    new SQLiteParameter("@discount",discount),
                    new SQLiteParameter("@oid",orderId)
                    };
                    cmd.CommandText = sqlText;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddRange(ps);
                    result += cmd.ExecuteNonQuery();
                    //3、将餐桌状态IsFree=1
                    sqlText = "update tableInfo set tIsFree=1 where tid=(select tableId from orderinfo where oid=@oid)";
                    SQLiteParameter p = new SQLiteParameter("@oid", orderId);
                    cmd.CommandText = sqlText;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(p);
                    result += cmd.ExecuteNonQuery();
                    tran.Commit();
                }
                catch
                {
                    result = 0;
                    tran.Rollback();
                }
                return result;
            }

        }
    }
}
