namespace LeavingManagementSystem
{
    partial class ModifyStaff
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbxAddStaff = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbtnLH = new System.Windows.Forms.RadioButton();
            this.rbtnFLH = new System.Windows.Forms.RadioButton();
            this.cbxGender = new System.Windows.Forms.ComboBox();
            this.txtLYB = new System.Windows.Forms.TextBox();
            this.lblLastyearBalance = new System.Windows.Forms.Label();
            this.lblEI = new System.Windows.Forms.Label();
            this.txtContractTerm = new System.Windows.Forms.TextBox();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.lblContractTerm = new System.Windows.Forms.Label();
            this.lblEmployeeCategory = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtChineseName = new System.Windows.Forms.TextBox();
            this.lblChineseName = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbtnYes = new System.Windows.Forms.RadioButton();
            this.rbtnNo = new System.Windows.Forms.RadioButton();
            this.lblOnBoardDate = new System.Windows.Forms.Label();
            this.dtpOnBoardDate = new System.Windows.Forms.DateTimePicker();
            this.cbxDepartmentName = new System.Windows.Forms.ComboBox();
            this.lblDepartmentName = new System.Windows.Forms.Label();
            this.lblMarried = new System.Windows.Forms.Label();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.lblFender = new System.Windows.Forms.Label();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtStaffName = new System.Windows.Forms.TextBox();
            this.lblStaffName = new System.Windows.Forms.Label();
            this.lblEmployeeId = new System.Windows.Forms.Label();
            this.lblStartWokDate = new System.Windows.Forms.Label();
            this.dtpStartWorkDate = new System.Windows.Forms.DateTimePicker();
            this.gbxAddStaff.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(432, 258);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(220, 258);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gbxAddStaff
            // 
            this.gbxAddStaff.Controls.Add(this.dtpStartWorkDate);
            this.gbxAddStaff.Controls.Add(this.lblStartWokDate);
            this.gbxAddStaff.Controls.Add(this.panel1);
            this.gbxAddStaff.Controls.Add(this.cbxGender);
            this.gbxAddStaff.Controls.Add(this.txtLYB);
            this.gbxAddStaff.Controls.Add(this.lblLastyearBalance);
            this.gbxAddStaff.Controls.Add(this.lblEI);
            this.gbxAddStaff.Controls.Add(this.txtContractTerm);
            this.gbxAddStaff.Controls.Add(this.txtLocation);
            this.gbxAddStaff.Controls.Add(this.lblContractTerm);
            this.gbxAddStaff.Controls.Add(this.lblEmployeeCategory);
            this.gbxAddStaff.Controls.Add(this.lblLocation);
            this.gbxAddStaff.Controls.Add(this.txtTitle);
            this.gbxAddStaff.Controls.Add(this.lblTitle);
            this.gbxAddStaff.Controls.Add(this.txtChineseName);
            this.gbxAddStaff.Controls.Add(this.lblChineseName);
            this.gbxAddStaff.Controls.Add(this.panel2);
            this.gbxAddStaff.Controls.Add(this.lblOnBoardDate);
            this.gbxAddStaff.Controls.Add(this.dtpOnBoardDate);
            this.gbxAddStaff.Controls.Add(this.cbxDepartmentName);
            this.gbxAddStaff.Controls.Add(this.lblDepartmentName);
            this.gbxAddStaff.Controls.Add(this.lblMarried);
            this.gbxAddStaff.Controls.Add(this.txtPhoneNumber);
            this.gbxAddStaff.Controls.Add(this.lblFender);
            this.gbxAddStaff.Controls.Add(this.lblPhoneNumber);
            this.gbxAddStaff.Controls.Add(this.txtEmail);
            this.gbxAddStaff.Controls.Add(this.lblEmail);
            this.gbxAddStaff.Controls.Add(this.txtStaffName);
            this.gbxAddStaff.Controls.Add(this.lblStaffName);
            this.gbxAddStaff.Controls.Add(this.lblEmployeeId);
            this.gbxAddStaff.Location = new System.Drawing.Point(11, 30);
            this.gbxAddStaff.Name = "gbxAddStaff";
            this.gbxAddStaff.Size = new System.Drawing.Size(692, 209);
            this.gbxAddStaff.TabIndex = 9;
            this.gbxAddStaff.TabStop = false;
            this.gbxAddStaff.Text = "ModifyStaff";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbtnLH);
            this.panel1.Controls.Add(this.rbtnFLH);
            this.panel1.Location = new System.Drawing.Point(576, 124);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(113, 28);
            this.panel1.TabIndex = 38;
            // 
            // rbtnLH
            // 
            this.rbtnLH.AutoSize = true;
            this.rbtnLH.Checked = true;
            this.rbtnLH.Location = new System.Drawing.Point(5, 6);
            this.rbtnLH.Name = "rbtnLH";
            this.rbtnLH.Size = new System.Drawing.Size(39, 17);
            this.rbtnLH.TabIndex = 11;
            this.rbtnLH.TabStop = true;
            this.rbtnLH.Text = "LH";
            this.rbtnLH.UseVisualStyleBackColor = true;
            // 
            // rbtnFLH
            // 
            this.rbtnFLH.AutoSize = true;
            this.rbtnFLH.Location = new System.Drawing.Point(61, 6);
            this.rbtnFLH.Name = "rbtnFLH";
            this.rbtnFLH.Size = new System.Drawing.Size(45, 17);
            this.rbtnFLH.TabIndex = 12;
            this.rbtnFLH.Text = "FLH";
            this.rbtnFLH.UseVisualStyleBackColor = true;
            // 
            // cbxGender
            // 
            this.cbxGender.FormattingEnabled = true;
            this.cbxGender.Items.AddRange(new object[] {
            "Please Select",
            "Female",
            "Male"});
            this.cbxGender.Location = new System.Drawing.Point(112, 61);
            this.cbxGender.Name = "cbxGender";
            this.cbxGender.Size = new System.Drawing.Size(100, 21);
            this.cbxGender.TabIndex = 37;
            // 
            // txtLYB
            // 
            this.txtLYB.Location = new System.Drawing.Point(350, 175);
            this.txtLYB.Name = "txtLYB";
            this.txtLYB.Size = new System.Drawing.Size(100, 20);
            this.txtLYB.TabIndex = 36;
            // 
            // lblLastyearBalance
            // 
            this.lblLastyearBalance.AutoSize = true;
            this.lblLastyearBalance.Location = new System.Drawing.Point(248, 175);
            this.lblLastyearBalance.Name = "lblLastyearBalance";
            this.lblLastyearBalance.Size = new System.Drawing.Size(95, 13);
            this.lblLastyearBalance.TabIndex = 35;
            this.lblLastyearBalance.Text = "Last year Balance:";
            // 
            // lblEI
            // 
            this.lblEI.AutoSize = true;
            this.lblEI.Location = new System.Drawing.Point(129, 29);
            this.lblEI.Name = "lblEI";
            this.lblEI.Size = new System.Drawing.Size(62, 13);
            this.lblEI.TabIndex = 33;
            this.lblEI.Text = "EmployeeId";
            // 
            // txtContractTerm
            // 
            this.txtContractTerm.Location = new System.Drawing.Point(112, 167);
            this.txtContractTerm.Name = "txtContractTerm";
            this.txtContractTerm.Size = new System.Drawing.Size(100, 20);
            this.txtContractTerm.TabIndex = 31;
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(576, 91);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(100, 20);
            this.txtLocation.TabIndex = 30;
            // 
            // lblContractTerm
            // 
            this.lblContractTerm.AutoSize = true;
            this.lblContractTerm.Location = new System.Drawing.Point(25, 167);
            this.lblContractTerm.Name = "lblContractTerm";
            this.lblContractTerm.Size = new System.Drawing.Size(74, 13);
            this.lblContractTerm.TabIndex = 29;
            this.lblContractTerm.Text = "ContractTerm:";
            // 
            // lblEmployeeCategory
            // 
            this.lblEmployeeCategory.AutoSize = true;
            this.lblEmployeeCategory.Location = new System.Drawing.Point(481, 131);
            this.lblEmployeeCategory.Name = "lblEmployeeCategory";
            this.lblEmployeeCategory.Size = new System.Drawing.Size(98, 13);
            this.lblEmployeeCategory.TabIndex = 28;
            this.lblEmployeeCategory.Text = "EmployeeCategory:";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(481, 99);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(51, 13);
            this.lblLocation.TabIndex = 27;
            this.lblLocation.Text = "Location:";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(576, 65);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(100, 20);
            this.txtTitle.TabIndex = 26;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(481, 69);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(30, 13);
            this.lblTitle.TabIndex = 25;
            this.lblTitle.Text = "Title:";
            // 
            // txtChineseName
            // 
            this.txtChineseName.Location = new System.Drawing.Point(576, 29);
            this.txtChineseName.Name = "txtChineseName";
            this.txtChineseName.Size = new System.Drawing.Size(100, 20);
            this.txtChineseName.TabIndex = 24;
            // 
            // lblChineseName
            // 
            this.lblChineseName.AutoSize = true;
            this.lblChineseName.Location = new System.Drawing.Point(481, 35);
            this.lblChineseName.Name = "lblChineseName";
            this.lblChineseName.Size = new System.Drawing.Size(76, 13);
            this.lblChineseName.TabIndex = 23;
            this.lblChineseName.Text = "ChineseName:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbtnYes);
            this.panel2.Controls.Add(this.rbtnNo);
            this.panel2.Location = new System.Drawing.Point(109, 91);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(121, 28);
            this.panel2.TabIndex = 20;
            // 
            // rbtnYes
            // 
            this.rbtnYes.AutoSize = true;
            this.rbtnYes.Location = new System.Drawing.Point(6, 5);
            this.rbtnYes.Name = "rbtnYes";
            this.rbtnYes.Size = new System.Drawing.Size(43, 17);
            this.rbtnYes.TabIndex = 11;
            this.rbtnYes.Text = "Yes";
            this.rbtnYes.UseVisualStyleBackColor = true;
            // 
            // rbtnNo
            // 
            this.rbtnNo.AutoSize = true;
            this.rbtnNo.Location = new System.Drawing.Point(64, 6);
            this.rbtnNo.Name = "rbtnNo";
            this.rbtnNo.Size = new System.Drawing.Size(39, 17);
            this.rbtnNo.TabIndex = 12;
            this.rbtnNo.Text = "No";
            this.rbtnNo.UseVisualStyleBackColor = true;
            // 
            // lblOnBoardDate
            // 
            this.lblOnBoardDate.AutoSize = true;
            this.lblOnBoardDate.Location = new System.Drawing.Point(248, 130);
            this.lblOnBoardDate.Name = "lblOnBoardDate";
            this.lblOnBoardDate.Size = new System.Drawing.Size(75, 13);
            this.lblOnBoardDate.TabIndex = 18;
            this.lblOnBoardDate.Text = "OnBoardDate:";
            // 
            // dtpOnBoardDate
            // 
            this.dtpOnBoardDate.Checked = false;
            this.dtpOnBoardDate.Location = new System.Drawing.Point(350, 127);
            this.dtpOnBoardDate.Name = "dtpOnBoardDate";
            this.dtpOnBoardDate.Size = new System.Drawing.Size(100, 20);
            this.dtpOnBoardDate.TabIndex = 17;
            // 
            // cbxDepartmentName
            // 
            this.cbxDepartmentName.FormattingEnabled = true;
            this.cbxDepartmentName.Location = new System.Drawing.Point(350, 91);
            this.cbxDepartmentName.Name = "cbxDepartmentName";
            this.cbxDepartmentName.Size = new System.Drawing.Size(100, 21);
            this.cbxDepartmentName.TabIndex = 16;
            // 
            // lblDepartmentName
            // 
            this.lblDepartmentName.AutoSize = true;
            this.lblDepartmentName.Location = new System.Drawing.Point(248, 94);
            this.lblDepartmentName.Name = "lblDepartmentName";
            this.lblDepartmentName.Size = new System.Drawing.Size(93, 13);
            this.lblDepartmentName.TabIndex = 15;
            this.lblDepartmentName.Text = "DepartmentName:";
            // 
            // lblMarried
            // 
            this.lblMarried.AutoSize = true;
            this.lblMarried.Location = new System.Drawing.Point(25, 97);
            this.lblMarried.Name = "lblMarried";
            this.lblMarried.Size = new System.Drawing.Size(53, 13);
            this.lblMarried.TabIndex = 10;
            this.lblMarried.Text = "IsMarried:";
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(350, 62);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(100, 20);
            this.txtPhoneNumber.TabIndex = 9;
            // 
            // lblFender
            // 
            this.lblFender.AutoSize = true;
            this.lblFender.Location = new System.Drawing.Point(25, 65);
            this.lblFender.Name = "lblFender";
            this.lblFender.Size = new System.Drawing.Size(45, 13);
            this.lblFender.TabIndex = 7;
            this.lblFender.Text = "Gender:";
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Location = new System.Drawing.Point(248, 65);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(81, 13);
            this.lblPhoneNumber.TabIndex = 6;
            this.lblPhoneNumber.Text = "Phone Number:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(112, 125);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(100, 20);
            this.txtEmail.TabIndex = 5;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(25, 125);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "Email:";
            // 
            // txtStaffName
            // 
            this.txtStaffName.Location = new System.Drawing.Point(350, 29);
            this.txtStaffName.Name = "txtStaffName";
            this.txtStaffName.Size = new System.Drawing.Size(100, 20);
            this.txtStaffName.TabIndex = 3;
            // 
            // lblStaffName
            // 
            this.lblStaffName.AutoSize = true;
            this.lblStaffName.Location = new System.Drawing.Point(248, 29);
            this.lblStaffName.Name = "lblStaffName";
            this.lblStaffName.Size = new System.Drawing.Size(60, 13);
            this.lblStaffName.TabIndex = 2;
            this.lblStaffName.Text = "StaffName:";
            // 
            // lblEmployeeId
            // 
            this.lblEmployeeId.AutoSize = true;
            this.lblEmployeeId.Location = new System.Drawing.Point(22, 29);
            this.lblEmployeeId.Name = "lblEmployeeId";
            this.lblEmployeeId.Size = new System.Drawing.Size(65, 13);
            this.lblEmployeeId.TabIndex = 0;
            this.lblEmployeeId.Text = "EmployeeId:";
            // 
            // lblStartWokDate
            // 
            this.lblStartWokDate.AutoSize = true;
            this.lblStartWokDate.Location = new System.Drawing.Point(482, 178);
            this.lblStartWokDate.Name = "lblStartWokDate";
            this.lblStartWokDate.Size = new System.Drawing.Size(81, 13);
            this.lblStartWokDate.TabIndex = 39;
            this.lblStartWokDate.Text = "StartWorkDate:";
            // 
            // dtpStartWorkDate
            // 
            this.dtpStartWorkDate.Checked = false;
            this.dtpStartWorkDate.Location = new System.Drawing.Point(576, 175);
            this.dtpStartWorkDate.Name = "dtpStartWorkDate";
            this.dtpStartWorkDate.Size = new System.Drawing.Size(100, 20);
            this.dtpStartWorkDate.TabIndex = 40;
            // 
            // ModifyStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 310);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbxAddStaff);
            this.MaximizeBox = false;
            this.Name = "ModifyStaff";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ModifyStaff";
            this.Load += new System.EventHandler(this.ModifyStaff_Load);
            this.gbxAddStaff.ResumeLayout(false);
            this.gbxAddStaff.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox gbxAddStaff;
        private System.Windows.Forms.TextBox txtContractTerm;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label lblContractTerm;
        private System.Windows.Forms.Label lblEmployeeCategory;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtChineseName;
        private System.Windows.Forms.Label lblChineseName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbtnYes;
        private System.Windows.Forms.RadioButton rbtnNo;
        private System.Windows.Forms.Label lblOnBoardDate;
        private System.Windows.Forms.DateTimePicker dtpOnBoardDate;
        private System.Windows.Forms.ComboBox cbxDepartmentName;
        private System.Windows.Forms.Label lblDepartmentName;
        private System.Windows.Forms.Label lblMarried;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Label lblFender;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtStaffName;
        private System.Windows.Forms.Label lblStaffName;
        private System.Windows.Forms.Label lblEmployeeId;
        private System.Windows.Forms.Label lblEI;
        private System.Windows.Forms.TextBox txtLYB;
        private System.Windows.Forms.Label lblLastyearBalance;
        private System.Windows.Forms.ComboBox cbxGender;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbtnLH;
        private System.Windows.Forms.RadioButton rbtnFLH;
        private System.Windows.Forms.Label lblStartWokDate;
        private System.Windows.Forms.DateTimePicker dtpStartWorkDate;




    }
}