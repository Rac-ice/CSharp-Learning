namespace CaterUI
{
    partial class FormTableInfo
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvTableList = new System.Windows.Forms.DataGridView();
            this.TId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIsFree = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.cbbFreeSearch = new System.Windows.Forms.ComboBox();
            this.cbbHallListSearch = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.rbNoFree = new System.Windows.Forms.RadioButton();
            this.rbFree = new System.Windows.Forms.RadioButton();
            this.btnHallManager = new System.Windows.Forms.Button();
            this.cbbHallListAdd = new System.Windows.Forms.ComboBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableList)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvTableList);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(449, 436);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "列表";
            // 
            // dgvTableList
            // 
            this.dgvTableList.AllowUserToAddRows = false;
            this.dgvTableList.AllowUserToDeleteRows = false;
            this.dgvTableList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTableList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TId,
            this.TTitle,
            this.HTitle,
            this.TIsFree});
            this.dgvTableList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTableList.Location = new System.Drawing.Point(3, 17);
            this.dgvTableList.MultiSelect = false;
            this.dgvTableList.Name = "dgvTableList";
            this.dgvTableList.ReadOnly = true;
            this.dgvTableList.RowTemplate.Height = 23;
            this.dgvTableList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTableList.Size = new System.Drawing.Size(443, 416);
            this.dgvTableList.TabIndex = 0;
            this.dgvTableList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTableList_CellDoubleClick);
            this.dgvTableList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvTableList_CellFormatting);
            // 
            // TId
            // 
            this.TId.DataPropertyName = "TId";
            this.TId.HeaderText = "编号";
            this.TId.Name = "TId";
            this.TId.ReadOnly = true;
            // 
            // TTitle
            // 
            this.TTitle.DataPropertyName = "TTitle";
            this.TTitle.HeaderText = "名称";
            this.TTitle.Name = "TTitle";
            this.TTitle.ReadOnly = true;
            // 
            // HTitle
            // 
            this.HTitle.DataPropertyName = "HTitle";
            this.HTitle.HeaderText = "厅包";
            this.HTitle.Name = "HTitle";
            this.HTitle.ReadOnly = true;
            // 
            // TIsFree
            // 
            this.TIsFree.DataPropertyName = "TIsFree";
            this.TIsFree.HeaderText = "是否空闲";
            this.TIsFree.Name = "TIsFree";
            this.TIsFree.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSelectAll);
            this.groupBox2.Controls.Add(this.cbbFreeSearch);
            this.groupBox2.Controls.Add(this.cbbHallListSearch);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(467, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 117);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "搜索";
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(12, 82);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(178, 23);
            this.btnSelectAll.TabIndex = 4;
            this.btnSelectAll.Text = "显示全部";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // cbbFreeSearch
            // 
            this.cbbFreeSearch.FormattingEnabled = true;
            this.cbbFreeSearch.Location = new System.Drawing.Point(69, 50);
            this.cbbFreeSearch.Name = "cbbFreeSearch";
            this.cbbFreeSearch.Size = new System.Drawing.Size(121, 20);
            this.cbbFreeSearch.TabIndex = 3;
            this.cbbFreeSearch.SelectedIndexChanged += new System.EventHandler(this.cbbFreeSearch_SelectedIndexChanged);
            // 
            // cbbHallListSearch
            // 
            this.cbbHallListSearch.FormattingEnabled = true;
            this.cbbHallListSearch.Location = new System.Drawing.Point(69, 20);
            this.cbbHallListSearch.Name = "cbbHallListSearch";
            this.cbbHallListSearch.Size = new System.Drawing.Size(121, 20);
            this.cbbHallListSearch.TabIndex = 2;
            this.cbbHallListSearch.SelectedIndexChanged += new System.EventHandler(this.cbbHallListSearch_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "空  闲：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "厅  包：";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnCancel);
            this.groupBox3.Controls.Add(this.btnSave);
            this.groupBox3.Controls.Add(this.btnDelete);
            this.groupBox3.Controls.Add(this.rbNoFree);
            this.groupBox3.Controls.Add(this.rbFree);
            this.groupBox3.Controls.Add(this.btnHallManager);
            this.groupBox3.Controls.Add(this.cbbHallListAdd);
            this.groupBox3.Controls.Add(this.txtTitle);
            this.groupBox3.Controls.Add(this.txtId);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(467, 135);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 313);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "添加\\修改";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(115, 215);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 215);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "添加";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(12, 275);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(178, 23);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "删除选中的行数据";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // rbNoFree
            // 
            this.rbNoFree.AutoSize = true;
            this.rbNoFree.Location = new System.Drawing.Point(131, 185);
            this.rbNoFree.Name = "rbNoFree";
            this.rbNoFree.Size = new System.Drawing.Size(59, 16);
            this.rbNoFree.TabIndex = 12;
            this.rbNoFree.Text = "使用中";
            this.rbNoFree.UseVisualStyleBackColor = true;
            // 
            // rbFree
            // 
            this.rbFree.AutoSize = true;
            this.rbFree.Checked = true;
            this.rbFree.Location = new System.Drawing.Point(70, 185);
            this.rbFree.Name = "rbFree";
            this.rbFree.Size = new System.Drawing.Size(47, 16);
            this.rbFree.TabIndex = 11;
            this.rbFree.TabStop = true;
            this.rbFree.Text = "空闲";
            this.rbFree.UseVisualStyleBackColor = true;
            // 
            // btnHallManager
            // 
            this.btnHallManager.Location = new System.Drawing.Point(67, 150);
            this.btnHallManager.Name = "btnHallManager";
            this.btnHallManager.Size = new System.Drawing.Size(123, 23);
            this.btnHallManager.TabIndex = 10;
            this.btnHallManager.Text = "厅包管理";
            this.btnHallManager.UseVisualStyleBackColor = true;
            this.btnHallManager.Click += new System.EventHandler(this.btnHallManager_Click);
            // 
            // cbbHallListAdd
            // 
            this.cbbHallListAdd.FormattingEnabled = true;
            this.cbbHallListAdd.Location = new System.Drawing.Point(67, 120);
            this.cbbHallListAdd.Name = "cbbHallListAdd";
            this.cbbHallListAdd.Size = new System.Drawing.Size(123, 20);
            this.cbbHallListAdd.TabIndex = 9;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(69, 55);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(121, 21);
            this.txtTitle.TabIndex = 8;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(69, 20);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(121, 21);
            this.txtId.TabIndex = 7;
            this.txtId.Text = "添加时无编号";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Location = new System.Drawing.Point(65, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 24);
            this.label8.TabIndex = 6;
            this.label8.Text = "如果是包间则填写名称\r\n如果是厅堂则填写号码\r\n";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(10, 250);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(149, 12);
            this.label7.TabIndex = 5;
            this.label7.Text = "提示：双击表格项进行修改";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "空  闲：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "厅  包：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "名  称：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "编  号：";
            // 
            // FormTableInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 460);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormTableInfo";
            this.Text = "餐桌管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormTableInfo_FormClosing);
            this.Load += new System.EventHandler(this.FormTableInfo_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableList)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvTableList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.ComboBox cbbFreeSearch;
        private System.Windows.Forms.ComboBox cbbHallListSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.RadioButton rbNoFree;
        private System.Windows.Forms.RadioButton rbFree;
        private System.Windows.Forms.Button btnHallManager;
        private System.Windows.Forms.ComboBox cbbHallListAdd;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn TId;
        private System.Windows.Forms.DataGridViewTextBoxColumn TTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn HTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIsFree;
    }
}