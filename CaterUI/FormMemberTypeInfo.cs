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
    public partial class FormMemberTypeInfo : Form
    {
        public FormMemberTypeInfo()
        {
            InitializeComponent();
        }

        //调用业务逻辑层对象
        MemberTypeInfoBll mtiBll = new MemberTypeInfoBll();

        private DialogResult result = DialogResult.Cancel;

        private void FormMemberTypeInfo_Load(object sender, EventArgs e)
        {
            LoadList();
        }

        private void LoadList()
        {
            dgvMemberTypeList.AutoGenerateColumns = false;
            dgvMemberTypeList.DataSource = mtiBll.GetList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //接收用户输入
            MemberTypeInfo mti = new MemberTypeInfo()
            {
                MTitle = txtTitle.Text,
                MDiscount = Convert.ToDecimal(txtDiscount.Text)
            };
            if (txtId.Text.Equals("添加时无编号"))
            {
                #region 添加
                //调用bll的add方法
                if (mtiBll.Add(mti))
                {
                    //如果添加成功，则重新加载数据
                    LoadList();
                    result = DialogResult.OK;
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
                mti.MId = Convert.ToInt32(txtId.Text);
                //调用修改的方法
                if (mtiBll.Edit(mti))
                {
                    //修改成功，重新加载数据
                    LoadList();
                    result = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("修改失败，请稍后重试！");
                } 
                #endregion
            }
            Cancel();
        }

        private void Cancel()
        {
            txtId.Text = "添加时无编号";
            txtTitle.Text = string.Empty;
            txtDiscount.Text = string.Empty;
            btnSave.Text = "添加";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void dgvMemberTypeList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //获取双击的行
            var row = dgvMemberTypeList.Rows[e.RowIndex];
            //将行中列的值赋给文本框
            txtId.Text = row.Cells[0].Value.ToString();
            txtTitle.Text = row.Cells[1].Value.ToString();
            txtDiscount.Text = row.Cells[2].Value.ToString();
            btnSave.Text = "修改";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //获取选中行的编号
            var row = dgvMemberTypeList.SelectedRows[0];
            int id = Convert.ToInt32(row.Cells[0].Value);
            //确认
            DialogResult result = MessageBox.Show("确定要删除吗？","提示",MessageBoxButtons.OKCancel);
            if (result == DialogResult.Cancel)
            {
                return;
            }
            //删除
            if (mtiBll.Delete(id))
            {
                LoadList();
                result = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("删除失败，请稍后重试！");
            }
        }

        private void FormMemberTypeInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = result;
        }
    }
}
