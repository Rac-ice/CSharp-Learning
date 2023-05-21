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
    public partial class FormHallInfo : Form
    {
        public FormHallInfo()
        {
            InitializeComponent();
            hiBll = new HallInfoBll();
        }

        private HallInfoBll hiBll;

        //private DialogResult result1 = DialogResult.Cancel;

        public event Action MyUpdateForm;

        private void FormHallInfo_Load(object sender, EventArgs e)
        {
            LoadList();
        }

        private void LoadList()
        {
            dgvHallList.AutoGenerateColumns = false;
            dgvHallList.DataSource = hiBll.GetList();
            if (dgvSelectedIndex > -1)
            {
                dgvHallList.Rows[dgvSelectedIndex].Selected = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void Cancel()
        {
            txtId.Text = "添加时无编号";
            txtTitle.Text = string.Empty;
            btnSave.Text = "添加";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text == string.Empty)
            {
                MessageBox.Show("请输入厅包名称");
                txtTitle.Focus();
                return;
            }
            HallInfo hi = new HallInfo()
            {
                HTitle = txtTitle.Text
            };
            if (txtId.Text == "添加时无编号")
            {
                #region 添加
                if (hiBll.Add(hi))
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
                hi.HId = Convert.ToInt32(txtId.Text);
                if (hiBll.Edit(hi))
                {
                    LoadList();
                }
                else
                {
                    MessageBox.Show("修改失败，请稍后重试！");
                }
                #endregion
            }
            //result1 = DialogResult.OK;
            Cancel();
            MyUpdateForm();
        }

        private int dgvSelectedIndex = -1;

        private void dgvHallList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvSelectedIndex = e.RowIndex;
            var row = dgvHallList.Rows[e.RowIndex];
            txtId.Text = row.Cells[0].Value.ToString();
            txtTitle.Text = row.Cells[1].Value.ToString();
            btnSave.Text = "修改";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvHallList.SelectedRows[0].Cells[0].Value);
            DialogResult result = MessageBox.Show("确认要删除？","提示",MessageBoxButtons.OKCancel);
            if (result == DialogResult.Cancel)
            {
                return;
            }
            if (hiBll.Remove(id))
            {
                LoadList();
            }
            else
            {
                MessageBox.Show("删除失败，请稍后重试！");
            }
            //result1 = DialogResult.OK;
            MyUpdateForm();
        }

        private void FormHallInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.DialogResult = result1;
        }
    }
}
