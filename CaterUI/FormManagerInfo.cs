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
    public partial class FormManagerInfo : Form
    {
        //构造函数私有化
        private FormManagerInfo()
        {
            InitializeComponent();
        }

        //实现窗体的单例
        //静态私有字段
        private static FormManagerInfo _formManagerInfo;

        //静态公开的获取私有字段的方法
        public static FormManagerInfo Create()
        {
            if (_formManagerInfo == null)
            {
                _formManagerInfo = new FormManagerInfo();
            }
            return _formManagerInfo;
        }

        //创建业务逻辑层对象
        ManagerInfoBll miBll = new ManagerInfoBll();

        private void FormManagerInfo_Load(object sender, EventArgs e)
        {
            //加载数据
            LoadList();
        }

        private void LoadList()
        {
            //禁用列表自动生成
            dgvManagerList.AutoGenerateColumns = false;
            //调用方法获取数据，绑定到列表的数据源上
            dgvManagerList.DataSource = miBll.GetList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //接收用户输入
            ManagerInfo mi = new ManagerInfo()
            {
                MName = txtName.Text,
                MPwd = txtPwd.Text,
                MType = rbManger.Checked ? 1 : 0//经理值为1，店员值为0
            };
            if (txtId.Text.Equals("添加时无编号"))
            {
                #region 添加
                //调用bll的add方法
                if (miBll.Add(mi))
                {
                    //如果添加成功，则重新加载数据
                    LoadList();
                }
                else
                {
                    MessageBox.Show("添加失败，请稍后重试！");
                }
                #endregion
            }
            else
            {
                #region 修改
                mi.MId = Convert.ToInt32(txtId.Text);
                if (miBll.Edit(mi))
                {
                    LoadList();
                }
                else
                {
                    MessageBox.Show("修改失败，请稍后重试！");
                }
                #endregion
            }

            //清除文本框中的值
            Cancel();
        }

        private void dgvManagerList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //对类型列进行格式化处理
            if (e.ColumnIndex == 2)
            {
                //根据类型判断内容
                e.Value = Convert.ToInt32(e.Value) == 1 ? "经理" : "店员";
            }
        }

        private void dgvManagerList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //根据当前点击的单元格，找到行与列，进行赋值
            //根据索引找到行
            DataGridViewRow row = dgvManagerList.Rows[e.RowIndex];
            //找到对应列
            txtId.Text = row.Cells[0].Value.ToString();
            txtName.Text = row.Cells[1].Value.ToString();
            if (row.Cells[2].Value.ToString().Equals("1"))
            {
                rbManger.Checked = true;//值为1，则经理选中
            }
            else
            {
                rbEmployee.Checked = true;//值为0，则店员选中
            }
            //指定密码的值
            txtPwd.Text = "这是原来的密码吗？";
            btnSave.Text = "修改";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void Cancel()
        {
            txtName.Text = string.Empty;
            txtPwd.Text = string.Empty;
            rbEmployee.Checked = true;
            btnSave.Text = "添加";
            txtId.Text = "添加时无编号";
        }

        private void btnSelectDelete_Click(object sender, EventArgs e)
        {
            //获取选中的行
            var rows = dgvManagerList.SelectedRows;
            if (rows.Count > 0)
            {
                //删除前的确认提示
                DialogResult result = MessageBox.Show("确定要删除吗？", "提示", MessageBoxButtons.OKCancel);
                if (result == DialogResult.Cancel)
                {
                    //用户取消删除
                    return;
                }
                //获取选中行的编号
                int id = int.Parse(rows[0].Cells[0].Value.ToString());
                //调用删除的操作
                if (miBll.Remove(id))
                {
                    //删除成功，重新加载数据
                    LoadList();
                }
            }
            else
            {
                MessageBox.Show("请选择要删除的行");
            }
        }

        private void FormManagerInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            //与单例保持一致
            //原因：Form的close()会释放当前窗体对象
            _formManagerInfo = null;
        }
    }
}
