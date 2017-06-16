namespace LeavingManagementSystem
{
    partial class StaffList
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
            this.gbxStaffInfo = new System.Windows.Forms.GroupBox();
            this.dgrdDisplayStaffInfo = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.departmentMangagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemConstantManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtStaffName = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblStaffName = new System.Windows.Forms.Label();
            this.lblStaffId = new System.Windows.Forms.Label();
            this.txtStaffId = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnDetails = new System.Windows.Forms.Button();
            this.dtpOnboardStart = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpOnboardEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.txtChineseName = new System.Windows.Forms.TextBox();
            this.lblChineseName = new System.Windows.Forms.Label();
            this.gbxStaffInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdDisplayStaffInfo)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxStaffInfo
            // 
            this.gbxStaffInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxStaffInfo.BackColor = System.Drawing.Color.White;
            this.gbxStaffInfo.Controls.Add(this.dgrdDisplayStaffInfo);
            this.gbxStaffInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxStaffInfo.Location = new System.Drawing.Point(22, 101);
            this.gbxStaffInfo.Name = "gbxStaffInfo";
            this.gbxStaffInfo.Size = new System.Drawing.Size(1055, 470);
            this.gbxStaffInfo.TabIndex = 1;
            this.gbxStaffInfo.TabStop = false;
            this.gbxStaffInfo.Text = "Staff Information";
            // 
            // dgrdDisplayStaffInfo
            // 
            this.dgrdDisplayStaffInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrdDisplayStaffInfo.BackgroundColor = System.Drawing.Color.White;
            this.dgrdDisplayStaffInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdDisplayStaffInfo.Location = new System.Drawing.Point(9, 34);
            this.dgrdDisplayStaffInfo.Name = "dgrdDisplayStaffInfo";
            this.dgrdDisplayStaffInfo.RowHeadersVisible = false;
            this.dgrdDisplayStaffInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrdDisplayStaffInfo.Size = new System.Drawing.Size(1040, 425);
            this.dgrdDisplayStaffInfo.TabIndex = 0;
            this.dgrdDisplayStaffInfo.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrdDisplayStaffInfo_CellContentDoubleClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.departmentMangagementToolStripMenuItem,
            this.userManagementToolStripMenuItem,
            this.systemConstantManagementToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1092, 26);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // departmentMangagementToolStripMenuItem
            // 
            this.departmentMangagementToolStripMenuItem.Name = "departmentMangagementToolStripMenuItem";
            this.departmentMangagementToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.departmentMangagementToolStripMenuItem.Text = "Department Mangagement";
            this.departmentMangagementToolStripMenuItem.Click += new System.EventHandler(this.departmentMangagementToolStripMenuItem_Click);
            // 
            // userManagementToolStripMenuItem
            // 
            this.userManagementToolStripMenuItem.Name = "userManagementToolStripMenuItem";
            this.userManagementToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.userManagementToolStripMenuItem.Text = "User Management";
            this.userManagementToolStripMenuItem.Click += new System.EventHandler(this.userManagementToolStripMenuItem_Click);
            // 
            // systemConstantManagementToolStripMenuItem
            // 
            this.systemConstantManagementToolStripMenuItem.Name = "systemConstantManagementToolStripMenuItem";
            this.systemConstantManagementToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.systemConstantManagementToolStripMenuItem.Text = "System Constant Management";
            this.systemConstantManagementToolStripMenuItem.Click += new System.EventHandler(this.systemConstantManagementToolStripMenuItem_Click);
            // 
            // txtStaffName
            // 
            this.txtStaffName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStaffName.Location = new System.Drawing.Point(439, 35);
            this.txtStaffName.Name = "txtStaffName";
            this.txtStaffName.Size = new System.Drawing.Size(130, 26);
            this.txtStaffName.TabIndex = 3;
            this.txtStaffName.TextChanged += new System.EventHandler(this.txtStaffName_TextChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.SystemColors.Control;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.Blue;
            this.btnSearch.Location = new System.Drawing.Point(936, 41);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 40);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblStaffName
            // 
            this.lblStaffName.AutoSize = true;
            this.lblStaffName.BackColor = System.Drawing.Color.White;
            this.lblStaffName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaffName.Location = new System.Drawing.Point(313, 36);
            this.lblStaffName.Name = "lblStaffName";
            this.lblStaffName.Size = new System.Drawing.Size(105, 20);
            this.lblStaffName.TabIndex = 5;
            this.lblStaffName.Text = "Staff Name:";
            // 
            // lblStaffId
            // 
            this.lblStaffId.AutoSize = true;
            this.lblStaffId.BackColor = System.Drawing.Color.White;
            this.lblStaffId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaffId.Location = new System.Drawing.Point(48, 35);
            this.lblStaffId.Name = "lblStaffId";
            this.lblStaffId.Size = new System.Drawing.Size(75, 20);
            this.lblStaffId.TabIndex = 6;
            this.lblStaffId.Text = "Staff Id:";
            // 
            // txtStaffId
            // 
            this.txtStaffId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStaffId.Location = new System.Drawing.Point(158, 33);
            this.txtStaffId.Name = "txtStaffId";
            this.txtStaffId.Size = new System.Drawing.Size(130, 26);
            this.txtStaffId.TabIndex = 7;
            this.txtStaffId.TextChanged += new System.EventHandler(this.txtStaffId_TextChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.BackColor = System.Drawing.SystemColors.Control;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.Blue;
            this.btnAdd.Location = new System.Drawing.Point(52, 598);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(110, 40);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.Blue;
            this.btnEdit.Location = new System.Drawing.Point(202, 598);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(110, 40);
            this.btnEdit.TabIndex = 9;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.Blue;
            this.btnDelete.Location = new System.Drawing.Point(352, 598);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(110, 40);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.ForeColor = System.Drawing.Color.Blue;
            this.btnImport.Location = new System.Drawing.Point(502, 598);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(110, 40);
            this.btnImport.TabIndex = 11;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnDetails
            // 
            this.btnDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetails.ForeColor = System.Drawing.Color.Blue;
            this.btnDetails.Location = new System.Drawing.Point(787, 598);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(110, 40);
            this.btnDetails.TabIndex = 12;
            this.btnDetails.Text = "Details";
            this.btnDetails.UseVisualStyleBackColor = true;
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            // 
            // dtpOnboardStart
            // 
            this.dtpOnboardStart.Location = new System.Drawing.Point(181, 72);
            this.dtpOnboardStart.Name = "dtpOnboardStart";
            this.dtpOnboardStart.Size = new System.Drawing.Size(130, 20);
            this.dtpOnboardStart.TabIndex = 13;
            this.dtpOnboardStart.Value = new System.DateTime(1990, 1, 1, 0, 0, 0, 0);
            this.dtpOnboardStart.ValueChanged += new System.EventHandler(this.dtpOnboardStart_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(48, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "Onboard Date:";
            // 
            // dtpOnboardEnd
            // 
            this.dtpOnboardEnd.Location = new System.Drawing.Point(393, 75);
            this.dtpOnboardEnd.Name = "dtpOnboardEnd";
            this.dtpOnboardEnd.Size = new System.Drawing.Size(121, 20);
            this.dtpOnboardEnd.TabIndex = 15;
            this.dtpOnboardEnd.ValueChanged += new System.EventHandler(this.dtpOnboardEnd_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(333, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "To:";
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.Blue;
            this.btnExport.Location = new System.Drawing.Point(645, 598);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(110, 40);
            this.btnExport.TabIndex = 17;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // txtChineseName
            // 
            this.txtChineseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChineseName.Location = new System.Drawing.Point(752, 35);
            this.txtChineseName.Name = "txtChineseName";
            this.txtChineseName.Size = new System.Drawing.Size(130, 26);
            this.txtChineseName.TabIndex = 19;
            this.txtChineseName.TextChanged += new System.EventHandler(this.txtChinese_TextChanged);
            // 
            // lblChineseName
            // 
            this.lblChineseName.AutoSize = true;
            this.lblChineseName.BackColor = System.Drawing.Color.White;
            this.lblChineseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChineseName.Location = new System.Drawing.Point(607, 37);
            this.lblChineseName.Name = "lblChineseName";
            this.lblChineseName.Size = new System.Drawing.Size(130, 20);
            this.lblChineseName.TabIndex = 18;
            this.lblChineseName.Text = "Chinese Name:";
            // 
            // StaffList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 666);
            this.Controls.Add(this.txtChineseName);
            this.Controls.Add(this.lblChineseName);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpOnboardEnd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpOnboardStart);
            this.Controls.Add(this.btnDetails);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtStaffId);
            this.Controls.Add(this.lblStaffId);
            this.Controls.Add(this.lblStaffName);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtStaffName);
            this.Controls.Add(this.gbxStaffInfo);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "StaffList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Staff";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StaffList_FormClosing);
            this.Load += new System.EventHandler(this.Staff_Load);
            this.gbxStaffInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdDisplayStaffInfo)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxStaffInfo;
        private System.Windows.Forms.DataGridView dgrdDisplayStaffInfo;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem departmentMangagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem systemConstantManagementToolStripMenuItem;
        private System.Windows.Forms.TextBox txtStaffName;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblStaffName;
        private System.Windows.Forms.Label lblStaffId;
        private System.Windows.Forms.TextBox txtStaffId;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnDetails;
        private System.Windows.Forms.DateTimePicker dtpOnboardStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpOnboardEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TextBox txtChineseName;
        private System.Windows.Forms.Label lblChineseName;
    }
}
