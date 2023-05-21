using CaterBll;
using CaterCommon;
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
    public partial class FormDishInfo : Form
    {
        private FormDishInfo()
        {
            InitializeComponent();
        }

        private static FormDishInfo _formDishInfo;

        public static FormDishInfo Create()
        {
            if (_formDishInfo == null)
            {
                _formDishInfo = new FormDishInfo();
            }
            return _formDishInfo;
        }

        DishInfoBll diBll = new DishInfoBll();

        private void FormDishInfo_Load(object sender, EventArgs e)
        {
            LoadTypeList();
            LoadList();
        }

        private void LoadTypeList()
        {
            DishTypeInfoBll dtiBll = new DishTypeInfoBll();

            #region 绑定查询的下拉列表
            List<DishTypeInfo> list = dtiBll.GetList();
            //向list中插入数据
            list.Insert(0, new DishTypeInfo()
            {
                DId = 0,
                DTitle = "全部"
            });
            cbbTypeList.DataSource = list;
            cbbTypeList.ValueMember = "DId";
            cbbTypeList.DisplayMember = "DTitle";
            #endregion


            #region 绑定添加的下拉列表
            cbbTypeAdd.DataSource = dtiBll.GetList();
            cbbTypeAdd.ValueMember = "DId";
            cbbTypeAdd.DisplayMember = "DTitle"; 
            #endregion
        }

        private void LoadList()
        {
            //拼接条件
            Dictionary<string,string> dic = new Dictionary<string,string>();
            if (txtSearchName.Text != string.Empty)
            {
                dic.Add("DTitle", txtSearchName.Text);
            }
            if (cbbTypeList.SelectedValue.ToString() != "0")
            {
                dic.Add("DTypeId", cbbTypeList.SelectedValue.ToString());
            }
            dgvDishList.AutoGenerateColumns = false;
            dgvDishList.DataSource = diBll.GetList(dic);
            //设置某行选中
            if (dgvSelectIndex > -1)
            {
                dgvDishList.Rows[dgvSelectIndex].Selected = true;
            }
        }

        private void txtSearchName_Leave(object sender, EventArgs e)
        {
            LoadList();
        }

        private void cbbTypeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadList();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            txtSearchName.Text = string.Empty;
            cbbTypeList.SelectedIndex = 0;
            LoadList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtNameAdd.Text == string.Empty)
            {
                MessageBox.Show("请输入菜品名称");
                txtNameAdd.Focus();
                return;
            }
            DishInfo di = new DishInfo()
            {
                DTitle = txtNameAdd.Text,
                DChar = txtCharAdd.Text,
                DTypeId = Convert.ToInt32(cbbTypeAdd.SelectedIndex)+1,
                DPrice = Convert.ToDecimal(txtPriceAdd.Text)
            };
            if (txtId.Text == "添加时无编号")
            {
                #region 添加
                if (diBll.Add(di))
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
                di.DId = Convert.ToInt32(txtId.Text);
                if (diBll.Edit(di))
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

        private int dgvSelectIndex = -1;

        private void dgvDishList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvSelectIndex = e.RowIndex;
            var row = dgvDishList.Rows[e.RowIndex];
            txtId.Text = row.Cells[0].Value.ToString();
            txtNameAdd.Text = row.Cells[1].Value.ToString();
            cbbTypeAdd.Text = row.Cells[2].Value.ToString();
            txtPriceAdd.Text = row.Cells[3].Value.ToString();
            txtCharAdd.Text = row.Cells[4].Value.ToString();
            btnSave.Text = "修改";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void Cancel()
        {
            txtNameAdd.Text = string.Empty;
            txtPriceAdd.Text = string.Empty;
            txtCharAdd.Text = string.Empty;
            txtId.Text = "添加时无编号";
            btnSave.Text = "添加";
            cbbTypeAdd.SelectedIndex = 0;
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            txtCharAdd.Text = PinyinHelper.GetPinyin(txtNameAdd.Text);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvDishList.SelectedRows[0].Cells[0].Value);
            DialogResult result = MessageBox.Show("确认要删除吗？","提示",MessageBoxButtons.OKCancel);
            if (result == DialogResult.Cancel)
            {
                return;
            }
            if (diBll.Remove(id))
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
            FormDishTypeInfo form = new FormDishTypeInfo();
            DialogResult result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                LoadTypeList();
                LoadList();
            }
        }

        private void FormDishInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            _formDishInfo = null;
        }
    }
}
