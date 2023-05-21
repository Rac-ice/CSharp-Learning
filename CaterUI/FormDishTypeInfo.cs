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
    public partial class FormDishTypeInfo : Form
    {
        public FormDishTypeInfo()
        {
            InitializeComponent();
        }

        private DialogResult result = DialogResult.Cancel;

        DishTypeInfoBll dtiBll = new DishTypeInfoBll();

        private void FormDishTypeInfo_Load(object sender, EventArgs e)
        {
            LoadList();
        }

        private void LoadList()
        {
            dgvDishTypeList.AutoGenerateColumns = false;
            dgvDishTypeList.DataSource = dtiBll.GetList();
            if (dgvSelectedIndex>-1)
            {
                dgvDishTypeList.Rows[dgvSelectedIndex].Selected = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DishTypeInfo dti = new DishTypeInfo()
            {
                DTitle = txtTitle.Text
            };
            if (txtId.Text== "添加时无编号")
            {
                #region 添加
                if (dtiBll.Add(dti))
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
                dti.DId = Convert.ToInt32(txtId.Text);
                if (dtiBll.Edit(dti))
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
            this.result = DialogResult.OK;
        }

        private int dgvSelectedIndex = -1;

        private void dgvDishTypeList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvSelectedIndex = e.RowIndex;
            var row = dgvDishTypeList.Rows[e.RowIndex];
            txtId.Text = row.Cells[0].Value.ToString();
            txtTitle.Text = row.Cells[1].Value.ToString();
            btnSave.Text = "修改";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void Cancel()
        {
            txtTitle.Text = string.Empty;
            txtId.Text = "添加时无编号";
            btnSave.Text = "添加";
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvDishTypeList.SelectedRows[0].Cells[0].Value);
            DialogResult result = MessageBox.Show("确认要删除","提示",MessageBoxButtons.OKCancel);
            if (result == DialogResult.Cancel)
            {
                return;
            }
            if (dtiBll.Remove(id))
            {
                LoadList();
            }
            else
            {
                MessageBox.Show("删除失败，请稍后重试！");
            }
            this.result = DialogResult.OK;
        }

        private void FormDishTypeInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = this.result;
        }
    }
}
