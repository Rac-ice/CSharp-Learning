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
    public partial class FormTableInfo : Form
    {
        private FormTableInfo()
        {
            InitializeComponent();
            tiBll = new TableInfoBll();
        }

        private static FormTableInfo _formTableInfo;

        public static FormTableInfo Create()
        {
            if (_formTableInfo == null)
            {
                _formTableInfo = new FormTableInfo();
            }
            return _formTableInfo;
        }

        private TableInfoBll tiBll;

        public event Action Refresh;

        private void FormTableInfo_Load(object sender, EventArgs e)
        {
            LoadSearchList();
            LoadList();
        }

        private void LoadSearchList()
        {
            HallInfoBll hiBll = new HallInfoBll();
            var list = hiBll.GetList();
            list.Insert(0, new HallInfo()
            {
                HId = 0,
                HTitle = "全部"
            });
            cbbHallListSearch.DataSource = list;
            cbbHallListSearch.ValueMember = "HId";
            cbbHallListSearch.DisplayMember = "HTitle";

            cbbHallListAdd.DataSource = hiBll.GetList();
            cbbHallListAdd.ValueMember = "HId";
            cbbHallListAdd.DisplayMember = "HTitle";

            List<CbbModel> listCbb = new List<CbbModel>()
            {
                new CbbModel("-1","全部"),
                new CbbModel("1","空闲"),
                new CbbModel("0","使用中")
            };
            cbbFreeSearch.DataSource = listCbb;
            cbbFreeSearch.ValueMember = "id";
            cbbFreeSearch.DisplayMember = "title";
        }

        private void LoadList()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            if (cbbHallListSearch.SelectedIndex > 0)
            {
                dic.Add("THallId", cbbHallListSearch.SelectedValue.ToString());
            }
            if (cbbFreeSearch.SelectedIndex > 0)
            {
                dic.Add("TIsFree", cbbFreeSearch.SelectedValue.ToString());
            }

            dgvTableList.AutoGenerateColumns = false;
            dgvTableList.DataSource = tiBll.GetList(dic);

            //if (dgvSelectedIndex > -1)
            //{
            //    dgvTableList.Rows[dgvSelectedIndex].Selected = true;
            //}
        }

        private void dgvTableList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //对类型列进行格式化处理
            if (e.ColumnIndex == 3)
            {
                //根据类型判断内容
                e.Value = Convert.ToBoolean(e.Value) ? "空闲" : "使用中";
            }
        }

        private void cbbHallListSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadList();
        }

        private void cbbFreeSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadList();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            cbbHallListSearch.SelectedIndex = 0;
            cbbFreeSearch.SelectedIndex = 0;
            LoadList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text == string.Empty)
            {
                MessageBox.Show("请输入餐桌名称");
                txtTitle.Focus();
                return;
            }
            TableInfo ti = new TableInfo()
            {
                TTitle = txtTitle.Text,
                THallId = Convert.ToInt32(cbbHallListAdd.SelectedValue),
                TIsFree = rbFree.Checked
            };
            if (txtId.Text == "添加时无编号")
            {
                #region 添加
                if (tiBll.Add(ti))
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
                ti.TId = Convert.ToInt32(txtId.Text);
                if (tiBll.Edit(ti))
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

            Refresh();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void Cancel()
        {
            txtId.Text = "添加时无编号";
            txtTitle.Text = string.Empty;
            cbbHallListAdd.SelectedIndex = 0;
            rbFree.Checked = true;
            btnSave.Text = "添加";
        }

        //private int dgvSelectedIndex = -1;

        private void dgvTableList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //dgvSelectedIndex = e.RowIndex;
            var row = dgvTableList.Rows[e.RowIndex];
            txtId.Text = row.Cells[0].Value.ToString();
            txtTitle.Text = row.Cells[1].Value.ToString();
            cbbHallListAdd.Text = row.Cells[2].Value.ToString();
            if (Convert.ToBoolean(row.Cells[3].Value))
            {
                rbFree.Checked = true;
            }
            else
            {
                rbNoFree.Checked = true;
            }
            btnSave.Text = "修改";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvTableList.SelectedRows[0].Cells[0].Value);
            DialogResult result = MessageBox.Show("确认要删除","提示",MessageBoxButtons.OKCancel);
            if (result == DialogResult.Cancel)
            {
                return;
            }
            if (tiBll.Remove(id))
            {
                LoadList();
            }
            else
            {
                MessageBox.Show("删除失败，请稍后重试！");
            }
            Refresh();
        }

        private void btnHallManager_Click(object sender, EventArgs e)
        {
            FormHallInfo form = new FormHallInfo();
            form.MyUpdateForm += LoadSearchList;
            form.MyUpdateForm += LoadList;
            form.ShowDialog();
            //DialogResult result = form.ShowDialog();
            //if (result == DialogResult.OK)
            //{
            //    LoadSearchList();
            //    LoadList();
            //}
        }

        private void FormTableInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            _formTableInfo = null;
        }
    }
}
