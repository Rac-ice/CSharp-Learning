namespace CaterUI
{
    partial class FormManagerInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbListInfo = new System.Windows.Forms.GroupBox();
            this.dgvManagerList = new System.Windows.Forms.DataGridView();
            this.Mid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mtype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbCRUD = new System.Windows.Forms.GroupBox();
            this.btnSelectDelete = new System.Windows.Forms.Button();
            this.tips2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.rbEmployee = new System.Windows.Forms.RadioButton();
            this.rbManger = new System.Windows.Forms.RadioButton();
            this.LMtype = new System.Windows.Forms.Label();
            this.tips1 = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.LMpwd = new System.Windows.Forms.Label();
            this.LMname = new System.Windows.Forms.Label();
            this.LMid = new System.Windows.Forms.Label();
            this.gbListInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManagerList)).BeginInit();
            this.gbCRUD.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbListInfo
            // 
            this.gbListInfo.Controls.Add(this.dgvManagerList);
            this.gbListInfo.Location = new System.Drawing.Point(12, 12);
            this.gbListInfo.Name = "gbListInfo";
            this.gbListInfo.Size = new System.Drawing.Size(349, 305);
            this.gbListInfo.TabIndex = 0;
            this.gbListInfo.TabStop = false;
            this.gbListInfo.Text = "列表";
            // 
            // dgvManagerList
            // 
            this.dgvManagerList.AllowUserToAddRows = false;
            this.dgvManagerList.AllowUserToDeleteRows = false;
            this.dgvManagerList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvManagerList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Mid,
            this.Mname,
            this.Mtype});
            this.dgvManagerList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvManagerList.Location = new System.Drawing.Point(3, 17);
            this.dgvManagerList.MultiSelect = false;
            this.dgvManagerList.Name = "dgvManagerList";
            this.dgvManagerList.ReadOnly = true;
            this.dgvManagerList.RowTemplate.Height = 23;
            this.dgvManagerList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvManagerList.Size = new System.Drawing.Size(343, 285);
            this.dgvManagerList.TabIndex = 0;
            this.dgvManagerList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvManagerList_CellDoubleClick);
            this.dgvManagerList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvManagerList_CellFormatting);
            // 
            // Mid
            // 
            this.Mid.DataPropertyName = "Mid";
            this.Mid.HeaderText = "编号";
            this.Mid.Name = "Mid";
            this.Mid.ReadOnly = true;
            // 
            // Mname
            // 
            this.Mname.DataPropertyName = "Mname";
            this.Mname.HeaderText = "用户名";
            this.Mname.Name = "Mname";
            this.Mname.ReadOnly = true;
            // 
            // Mtype
            // 
            this.Mtype.DataPropertyName = "Mtype";
            this.Mtype.HeaderText = "类型";
            this.Mtype.Name = "Mtype";
            this.Mtype.ReadOnly = true;
            // 
            // gbCRUD
            // 
            this.gbCRUD.Controls.Add(this.btnSelectDelete);
            this.gbCRUD.Controls.Add(this.tips2);
            this.gbCRUD.Controls.Add(this.btnCancel);
            this.gbCRUD.Controls.Add(this.btnSave);
            this.gbCRUD.Controls.Add(this.rbEmployee);
            this.gbCRUD.Controls.Add(this.rbManger);
            this.gbCRUD.Controls.Add(this.LMtype);
            this.gbCRUD.Controls.Add(this.tips1);
            this.gbCRUD.Controls.Add(this.txtPwd);
            this.gbCRUD.Controls.Add(this.txtName);
            this.gbCRUD.Controls.Add(this.txtId);
            this.gbCRUD.Controls.Add(this.LMpwd);
            this.gbCRUD.Controls.Add(this.LMname);
            this.gbCRUD.Controls.Add(this.LMid);
            this.gbCRUD.Location = new System.Drawing.Point(367, 12);
            this.gbCRUD.Name = "gbCRUD";
            this.gbCRUD.Size = new System.Drawing.Size(245, 305);
            this.gbCRUD.TabIndex = 1;
            this.gbCRUD.TabStop = false;
            this.gbCRUD.Text = "添加\\修改";
            // 
            // btnSelectDelete
            // 
            this.btnSelectDelete.Location = new System.Drawing.Point(41, 266);
            this.btnSelectDelete.Name = "btnSelectDelete";
            this.btnSelectDelete.Size = new System.Drawing.Size(167, 23);
            this.btnSelectDelete.TabIndex = 13;
            this.btnSelectDelete.Text = "删除选中的店员";
            this.btnSelectDelete.UseVisualStyleBackColor = true;
            this.btnSelectDelete.Click += new System.EventHandler(this.btnSelectDelete_Click);
            // 
            // tips2
            // 
            this.tips2.AutoSize = true;
            this.tips2.ForeColor = System.Drawing.Color.Red;
            this.tips2.Location = new System.Drawing.Point(14, 237);
            this.tips2.Name = "tips2";
            this.tips2.Size = new System.Drawing.Size(209, 12);
            this.tips2.TabIndex = 12;
            this.tips2.Text = "提示：双击表格项可以在此处进行修改";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(133, 201);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(39, 201);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "添加";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // rbEmployee
            // 
            this.rbEmployee.AutoSize = true;
            this.rbEmployee.Checked = true;
            this.rbEmployee.Location = new System.Drawing.Point(120, 167);
            this.rbEmployee.Name = "rbEmployee";
            this.rbEmployee.Size = new System.Drawing.Size(47, 16);
            this.rbEmployee.TabIndex = 9;
            this.rbEmployee.TabStop = true;
            this.rbEmployee.Text = "店员";
            this.rbEmployee.UseVisualStyleBackColor = true;
            // 
            // rbManger
            // 
            this.rbManger.AutoSize = true;
            this.rbManger.Location = new System.Drawing.Point(53, 167);
            this.rbManger.Name = "rbManger";
            this.rbManger.Size = new System.Drawing.Size(47, 16);
            this.rbManger.TabIndex = 8;
            this.rbManger.Text = "经理";
            this.rbManger.UseVisualStyleBackColor = true;
            // 
            // LMtype
            // 
            this.LMtype.AutoSize = true;
            this.LMtype.Location = new System.Drawing.Point(6, 171);
            this.LMtype.Name = "LMtype";
            this.LMtype.Size = new System.Drawing.Size(41, 12);
            this.LMtype.TabIndex = 7;
            this.LMtype.Text = "类型：";
            // 
            // tips1
            // 
            this.tips1.AutoSize = true;
            this.tips1.ForeColor = System.Drawing.Color.Gray;
            this.tips1.Location = new System.Drawing.Point(26, 141);
            this.tips1.Name = "tips1";
            this.tips1.Size = new System.Drawing.Size(197, 12);
            this.tips1.TabIndex = 6;
            this.tips1.Text = "这里只是提示，与实际密码位数无关";
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(53, 108);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(179, 21);
            this.txtPwd.TabIndex = 5;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(53, 71);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(179, 21);
            this.txtName.TabIndex = 4;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(53, 34);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(179, 21);
            this.txtId.TabIndex = 3;
            this.txtId.Text = "添加时无编号";
            // 
            // LMpwd
            // 
            this.LMpwd.AutoSize = true;
            this.LMpwd.Location = new System.Drawing.Point(6, 111);
            this.LMpwd.Name = "LMpwd";
            this.LMpwd.Size = new System.Drawing.Size(41, 12);
            this.LMpwd.TabIndex = 2;
            this.LMpwd.Text = "密码：";
            // 
            // LMname
            // 
            this.LMname.AutoSize = true;
            this.LMname.Location = new System.Drawing.Point(6, 74);
            this.LMname.Name = "LMname";
            this.LMname.Size = new System.Drawing.Size(53, 12);
            this.LMname.TabIndex = 1;
            this.LMname.Text = "用户名：";
            // 
            // LMid
            // 
            this.LMid.AutoSize = true;
            this.LMid.Location = new System.Drawing.Point(6, 37);
            this.LMid.Name = "LMid";
            this.LMid.Size = new System.Drawing.Size(41, 12);
            this.LMid.TabIndex = 0;
            this.LMid.Text = "编号：";
            // 
            // FormManagerInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 329);
            this.Controls.Add(this.gbCRUD);
            this.Controls.Add(this.gbListInfo);
            this.Name = "FormManagerInfo";
            this.Text = "店员管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormManagerInfo_FormClosing);
            this.Load += new System.EventHandler(this.FormManagerInfo_Load);
            this.gbListInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvManagerList)).EndInit();
            this.gbCRUD.ResumeLayout(false);
            this.gbCRUD.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbListInfo;
        private System.Windows.Forms.DataGridView dgvManagerList;
        private System.Windows.Forms.GroupBox gbCRUD;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label LMpwd;
        private System.Windows.Forms.Label LMname;
        private System.Windows.Forms.Label LMid;
        private System.Windows.Forms.Button btnSelectDelete;
        private System.Windows.Forms.Label tips2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.RadioButton rbEmployee;
        private System.Windows.Forms.RadioButton rbManger;
        private System.Windows.Forms.Label LMtype;
        private System.Windows.Forms.Label tips1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mtype;
    }
}