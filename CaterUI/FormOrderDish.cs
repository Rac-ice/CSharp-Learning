using CaterBll;
using CaterModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaterUI
{
    public partial class FormOrderDish : Form
    {
        private FormOrderDish()
        {
            InitializeComponent();
        }

        OrderInfoBll oiBll = new OrderInfoBll();

        private static FormOrderDish _formOrderDish;

        public static FormOrderDish Create()
        {
            if (_formOrderDish == null)
            {
                _formOrderDish = new FormOrderDish();   
            }
            return _formOrderDish;
        }

        private void FormOrderDish_Load(object sender, EventArgs e)
        {
            LoadDishType(); 
            LoadDIshInfo();
            
            orderId = Convert.ToInt32(this.Tag);
            LoadDetailList();
        }

        private void LoadDishType()
        {
            DishTypeInfoBll dtiBll = new DishTypeInfoBll();
            var list = dtiBll.GetList();
            list.Insert(0, new DishTypeInfo()
            {
                DId = 0,
                DTitle = "全部"
            });
            cbbType.ValueMember = "DId";
            cbbType.DisplayMember = "DTitle";
            cbbType.DataSource = list;
        }

        private void LoadDIshInfo()
        {
            //拼接查询条件
            Dictionary<string, string> dic = new Dictionary<string, string>();
            if (txtChar.Text != string.Empty)
            {
                dic.Add("DChar", txtChar.Text);
            }
            if (cbbType.SelectedValue.ToString() != "0")
            {
                dic.Add("DTypeId", cbbType.SelectedValue.ToString());
            }
            //查询菜品，显示带表格中
            DishInfoBll diBll = new DishInfoBll();
            dgvDishList.AutoGenerateColumns = false;
            dgvDishList.DataSource = diBll.GetList(dic);
        }

        //订单编号
        private int orderId;

        private void LoadDetailList()
        {
            dgvOrderList.AutoGenerateColumns = false;
            dgvOrderList.DataSource = oiBll.GetDetailList(orderId);

            GetTotalMoneyByOrderId();
        }

        private void GetTotalMoneyByOrderId()
        {
            if (dgvOrderList.Rows.Count > 0)
            {
                lblCount.Text = oiBll.GetTotalMoneyByOrderId(orderId).ToString();
            }
            else
            {
                lblCount.Text = "0";
            }
        }

        private void FormOrderDish_FormClosing(object sender, FormClosingEventArgs e)
        {
            _formOrderDish = null;
        }

        private void txtChar_TextChanged(object sender, EventArgs e)
        {
            LoadDIshInfo();
        }

        private void cbbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDIshInfo();
        }

        private void dgvDishList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //点菜
            
            //菜单编号
            int dishId = Convert.ToInt32(dgvDishList.Rows[e.RowIndex].Cells[0].Value);
            //执行点菜操作
            
            if (oiBll.OrderDish(orderId,dishId))
            {
                //点菜成功
                LoadDetailList();
            }
        }

        private void dgvOrderList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                //从数量列离开
                //修改的行
                var row = dgvOrderList.Rows[e.RowIndex];
                //获取oid
                int oid = Convert.ToInt32(row.Cells[0].Value);
                //获取数量
                int count = Convert.ToInt32(row.Cells[2].Value);
                oiBll.UpdateCountByOId(oid, count);

                //重新计算总价
                GetTotalMoneyByOrderId();
            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            //获取订单编号
            int orderId = Convert.ToInt32(this.Tag);
            //获取总金额
            decimal money = Convert.ToDecimal(lblCount.Text);
            //更新订单
            if (oiBll.SetOrderMoney(orderId, money))
            {
                MessageBox.Show("下单成功");
            }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确定要删除吗？","提示",MessageBoxButtons.OKCancel);
            if (result == DialogResult.Cancel)
            {
                return;
            }
            //获取编号
            int oid = Convert.ToInt32(dgvOrderList.SelectedRows[0].Cells[0].Value);
            //执行删除
            if (oiBll.DeleteDetailById(oid))
            {
                LoadDetailList();
            }
        }
    }
}
