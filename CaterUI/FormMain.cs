using CaterBll;
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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        OrderInfoBll oiBll = new OrderInfoBll();

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void menuQuit_Click(object sender, EventArgs e)
        {
            //当前应用程序退出，而不仅是关闭当前窗体
            Application.Exit();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //判断登陆进来的员工的级别，以确定是否显示menuManager图标
            int type = Convert.ToInt32(this.Tag);
            if (type==1)
            {
                //经理
            }
            else
            {
                //店员,管理员菜单不需要显示
                menuManagerInfo.Visible = false;
            }
            //架子啊所有的厅包信息
            LoadHallInfo();
        }

        private void LoadHallInfo()
        {
            //获取所有的厅包对象
            HallInfoBll hiBll = new HallInfoBll();
            var list = hiBll.GetList();
            tcHallInfo.TabPages.Clear();
            TableInfoBll tiBll = new TableInfoBll();
            //遍历集合，向标签页中添加信息
            foreach (var hi in list )
            {
                //根据厅包对象创建标签页对象
                TabPage tp = new TabPage(hi.HTitle);
                //获取当前厅包对象的多有餐桌
                Dictionary<string,string> dic = new Dictionary<string,string>();
                dic.Add("THallId", hi.HId.ToString());
                var listTabInfo = tiBll.GetList(dic);
                //动态创建列表添加到标签页上
                ListView lvTableInfo = new ListView();
                //添加双击事件
                lvTableInfo.DoubleClick += LvTableInfo_DoubleClick;
                //让列表使用图片
                lvTableInfo.LargeImageList = imageList1;
                lvTableInfo.Dock = DockStyle.Fill;
                tp.Controls.Add(lvTableInfo);
                //向列表中添加餐桌信息
                foreach (var ti in listTabInfo)
                {
                    var lvi = new ListViewItem(ti.TTitle, ti.TIsFree ? 0 : 1);
                    //后续操作需要用到餐桌编号，所以在这里存一下
                    lvi.Tag = ti.TId;
                    lvTableInfo.Items.Add(lvi);
                }
                //将标签页加入标签容器
                tcHallInfo.TabPages.Add(tp);
            }
        }

        private int orderId;

        private void LvTableInfo_DoubleClick(object sender, EventArgs e)
        {
            //获取被点的餐桌项
            var lv1 = sender as ListView;
            var lvi = lv1.SelectedItems[0];
            //获取餐桌编号
            int tableId = Convert.ToInt32(lvi.Tag);
            if (lvi.ImageIndex == 0)
            {
                //当前餐桌为空闲则开单
                //1、开单，向orderinfo表插入数据
                //2、修改餐桌状态为使用
                orderId = oiBll.OpenOrder(tableId);
                //3、更新项的图标为占用
                lv1.SelectedItems[0].ImageIndex = 1;
            }
            else
            {
                //当前餐桌已经占用，则进行点菜操作
                orderId = oiBll.GetOrderIdByTableId(tableId);
            }
            //4、打开点菜窗体
            FormOrderDish formOrderDish = FormOrderDish.Create();
            formOrderDish.Tag = orderId;
            formOrderDish.Show();
        }

        private void menuManagerInfo_Click(object sender, EventArgs e)
        {
            FormManagerInfo formManagerInfo = FormManagerInfo.Create();
            formManagerInfo.Show();
            formManagerInfo.Focus();//将当前窗体获得焦点
        }

        private void menuMemberInfo_Click(object sender, EventArgs e)
        {
            FormMemberInfo formMemberInfo = FormMemberInfo.Create();
            formMemberInfo.Show();
            formMemberInfo.Focus();
        }

        private void menuTableInfo_Click(object sender, EventArgs e)
        {
            FormTableInfo formTableInfo = FormTableInfo.Create();
            formTableInfo.Refresh += LoadHallInfo;
            formTableInfo.Show();
            formTableInfo.Focus();
        }

        private void menuDishInfo_Click(object sender, EventArgs e)
        {
            FormDishInfo formDishInfo = FormDishInfo.Create();
            formDishInfo.Show();
            formDishInfo.Focus();
        }

        private void menuOrder_Click(object sender, EventArgs e)
        {
            //先找到选中的标签页，再找到listview，再找到选中的项，项中存储了餐桌编号，由餐桌编号查到订单编号
            var listView = tcHallInfo.SelectedTab.Controls[0] as ListView;
            var lvTable = listView.SelectedItems[0];
            if (lvTable.ImageIndex == 0)
            {
                MessageBox.Show("餐桌未使用，无法结账");
                return;
            }
            int tableId = Convert.ToInt32(listView.SelectedItems[0].Tag);
            int orderId = oiBll.GetOrderIdByTableId(tableId);
            //打开付款窗体
            FormOrderPay formOrderPay = FormOrderPay.Create();
            formOrderPay.Tag = orderId;
            formOrderPay.Refresh += LoadHallInfo;
            formOrderPay.Show();
            formOrderPay.Focus();
        }
    }
}
