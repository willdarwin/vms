using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using BLL;
using DataModel;

namespace LeavingManagementSystem
{
    public partial class ModifyStaff : Form
    {
        DataManage datamanage = new DataManage();
        string staffId;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModifyStaff"/> class.
        /// </summary>
        /// <param name="staffId">The staff id.</param>
        public ModifyStaff(string staffId)
        {
            InitializeComponent();
            this.staffId = staffId;
        }

        /// <summary>
        /// Handles the Load event of the ModifyStaff control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ModifyStaff_Load(object sender, EventArgs e)
        {
            //Bind DepartmentName
            DataSet ds = datamanage.GetDataSet("select * from [Department]", "Department");
            DataRow row = ds.Tables[0].NewRow();
            row[0] = 0;
            row[1] = "Please Select";
            ds.Tables[0].Rows.InsertAt(row, 0);
            cbxDepartmentName.DataSource = ds.Tables[0];
            cbxDepartmentName.SelectedIndex = 0;
            cbxDepartmentName.ValueMember = "DepartmentId";
            cbxDepartmentName.DisplayMember = "DepartmentName";

            //Bind Gender
            cbxGender.DisplayMember = "Please Select";
            cbxGender.SelectedIndex = 0;

            //Bind database
            StaffService staffService =new StaffService();
            Staff staff = new Staff();
            staff.StaffId = Convert.ToInt32(staffId);
            staff =  staffService.GetStaffByStaffId(staff);
            if (staff.StaffId>0)
            {
                lblEI.Text = staff.EmployeeId.ToString();
                txtStaffName.Text = staff.StaffName.ToString();
                txtChineseName.Text = staff.ChineseName.ToString();
                txtTitle.Text = staff.Title.ToString();
                dtpOnBoardDate.Text = staff.OnboardDate.ToString();
                dtpStartWorkDate.Text = staff.StartWork.ToString();
                txtEmail.Text = staff.Email.ToString();
                txtPhoneNumber.Text = staff.PhoneNumber.ToString();
                if (Convert.ToInt32(staff.Gender) == 1)
                {
                    cbxGender.Text = "Male";
                }
                else if (Convert.ToInt32(staff.Gender) == 0)
                {
                    cbxGender.Text = "Female";
                }
                else
                {
                    cbxGender.Text = "Please select";
                }


                if (Convert.ToInt32(staff.Married) == 1)
                {
                    rbtnYes.Checked = true;
                }
                else
                {
                    rbtnNo.Checked = true;
                }

                txtLocation.Text = staff.Location.ToString();
                cbxDepartmentName.SelectedValue = staff.DepartmentId.ToString();

                if (staff.EmployeeCategory.ToString() == "LH")
                {
                    rbtnLH.Checked = true;
                }
                else
                {
                    rbtnFLH.Checked = true;
                }

                txtContractTerm.Text = staff.ContractTerm.ToString();
                txtLYB.Text = staff.LastyearRemains.ToString();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnSave control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            string staffName = txtStaffName.Text.ToString().Trim();
            string chineseName = txtChineseName.Text.ToString().Trim();
            string title = txtTitle.Text.ToString().Trim();
            DateTime onBoardDate = Convert.ToDateTime(dtpOnBoardDate.Text);
            DateTime startWorkDate = Convert.ToDateTime(dtpStartWorkDate.Text);
            string email = txtEmail.Text.ToString().Trim();
            string phoneNumber = txtPhoneNumber.Text.ToString().Trim();
            string gender = cbxGender.Text.ToString();
            if (gender.Trim() == "Female")
            {
                gender = Convert.ToString(0);
            }
            else
            {
                gender = Convert.ToString(1);
            }

            string isMarried = (rbtnYes.Checked == true) ? "1" : "0";
            string statusId = "1";
            string location = txtLocation.Text.ToString().Trim();
            string departmentId = cbxDepartmentName.SelectedValue.ToString();
            string employeeCategory = (rbtnLH.Checked == true) ? "LH" : "FLH";
            Single lastyearBalance = Convert.ToSingle(txtLYB.Text.ToString());
            if (lastyearBalance < 0 && lastyearBalance > -20)
            {
                lastyearBalance = Convert.ToSingle("-" + (DateTime.Now.Year - 1).ToString() + (-lastyearBalance).ToString());
            }
            else if (lastyearBalance >= 0 && lastyearBalance < 30)
            {
                lastyearBalance = Convert.ToSingle((DateTime.Now.Year - 1).ToString() + (lastyearBalance).ToString());
            }
            else
            {
                lastyearBalance = Convert.ToSingle((DateTime.Now.Year - 1).ToString() + "0");
            }
            if (employeeCategory == "Please Select")
            {
                employeeCategory = string.Empty;
            }
            string contractTerm = txtContractTerm.Text.ToString();

            string sql = "update [Staff] set StaffName='" + staffName + "',ChineseName='" + chineseName + "',Title='" + title + "',PhoneNumber='" + phoneNumber + "',DepartmentId='" + Convert.ToInt32(departmentId) + "',Email='" + email + "',StatusId='" + Convert.ToInt32(statusId) + "',OnBoardDate='" + onBoardDate + "',Gender='" + gender + "',Married='" + isMarried + "',Location='" + location + "',EmployeeCategory='" + employeeCategory + "',ContractTerm='" + contractTerm + "',LastyearRemains ='" + lastyearBalance + "',StartWork='" + startWorkDate + "' where StaffId=" + Convert.ToInt32(staffId) + "";

            bool flag = datamanage.GetOleDbCom(sql);
            if (flag)
            {
                MessageBox.Show("Modify staff success!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
