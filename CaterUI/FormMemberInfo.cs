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
    public partial class FormMemberInfo : Form
    {
        private FormMemberInfo()
        {
            InitializeComponent();
        }

        private static FormMemberInfo _formMemberInfo;

        public static FormMemberInfo Create()
        {
            if (_formMemberInfo == null)
            {
                _formMemberInfo = new FormMemberInfo();
            }
            return _formMemberInfo;
        }

        MemberInfoBll miBll = new MemberInfoBll();

        private void FormMemberInfo_Load(object sender, EventArgs e)
        {
            LoadList();
            LoadTypeList();
        }

        private void LoadTypeList()
        {
            MemberTypeInfoBll mtiBll = new MemberTypeInfoBll();
            List<MemberTypeInfo> list = mtiBll.GetList();
            cbbType.DataSource = list;
            //设置显示值
            cbbType.DisplayMember = "mtitle";
            //设置value值
            cbbType.ValueMember = "mid";
        }

        private void LoadList()
        {
            //使用键值对存储条件
            Dictionary<string, string> dic = new Dictionary<string, string>();
            //收集用户名信息
            if (txtSerachName.Text != string.Empty)
            {
                //根据名称搜索
                dic.Add("mname", txtSerachName.Text); 
            }
            //收集电话信息
            if (txtSearchPhone.Text != string.Empty)
            {
                dic.Add("mphone", txtSearchPhone.Text);
            }
            //根据条件查询
            dgvMemberList.AutoGenerateColumns = false;
            dgvMemberList.DataSource = miBll.GetList(dic);

            //设置某行选中
            if (dgvSelectedIndex>-1)
            {
                dgvMemberList.Rows[dgvSelectedIndex].Selected = true;
            }
        }

        private void txtSerachName_TextChanged(object sender, EventArgs e)
        {
            //内容改变事件
            LoadList();
        }

        private void txtSearchPhone_Leave(object sender, EventArgs e)
        {
            //失去焦点事件
            LoadList();
        }

        private void btnSearchAll_Click(object sender, EventArgs e)
        {
            txtSerachName.Text = string.Empty;
            txtSearchPhone.Text = string.Empty;
            LoadList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //值得有效判断
            if (txtName.Text == string.Empty)
            {
                MessageBox.Show("请输入会员姓名");
                txtName.Focus();
                return;
            }
            //接收用户输入
            MemberInfo mi = new MemberInfo()
            {
                MName = txtName.Text,
                MPhone = txtPhone.Text,
                MMoney = Convert.ToDecimal(txtMoney.Text),
                MTypeId = Convert.ToInt32(cbbType.SelectedValue)
            };
            if (txtId.Text.Equals("添加时无编号"))
            {
                #region 添加
                if (miBll.Add(mi))
                {
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
            Cancel();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void Cancel()
        {
            txtName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtMoney.Text = string.Empty;
            txtId.Text = "添加时无编号";
            cbbType.SelectedIndex = 0;
            btnSave.Text = "添加";
        }

        private int dgvSelectedIndex = -1;

        private void dgvMemberList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvSelectedIndex = e.RowIndex;
            //选中双击的行
            var row = dgvMemberList.Rows[e.RowIndex];
            //将行中列的值赋给文本框
            txtId.Text = row.Cells[0].Value.ToString();
            txtName.Text = row.Cells[1].Value.ToString();
            cbbType.Text = row.Cells[2].Value.ToString();
            txtPhone.Text = row.Cells[3].Value.ToString();
            txtMoney.Text = row.Cells[4].Value.ToString();
            btnSave.Text = "修改";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //选中行编号
            var row = dgvMemberList.SelectedRows[0];
            int id = Convert.ToInt32(row.Cells[0].Value);
            //确认
            DialogResult result = MessageBox.Show("确定要删除吗？", "提示", MessageBoxButtons.OKCancel);
            if (result == DialogResult.Cancel)
            {
                return;
            }
            if (miBll.Remove(id))
            {
                LoadList();
            }
            else
            {
                MessageBox.Show("删除失败，请稍后重试！");
            }
        }

        private void btnTypeManager_Click(object sender, EventArgs e)
        {
            FormMemberTypeInfo form = new FormMemberTypeInfo();
            //以模态窗口打开分类管理
            DialogResult result = form.ShowDialog();
            //根据返回的值，判断是否要更新下拉列表
            if (result == DialogResult.OK)
            {
                LoadTypeList();
                LoadList();
            }
        }

        private void FormMemberInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            _formMemberInfo = null;
        }
    }
}
