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
    public partial class AddStaff : Form
    {
        DataManage datamanage = new DataManage();

        /// <summary>
        /// Initializes a new instance of the <see cref="AddStaff"/> class.
        /// </summary>
        public AddStaff()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the AddStaff control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void AddStaff_Load(object sender, EventArgs e)
        {
            //Bind DepartmentName
            DataSet ds = datamanage.GetDataSet("select * from [Department]", "department");
            DataRow row = ds.Tables[0].NewRow();
            row[0] = 0;
            row[1] = "Please Select";
            ds.Tables[0].Rows.InsertAt(row, 0);
            cbxDepartmentName.DataSource = ds.Tables[0];
            cbxDepartmentName.SelectedIndex = 0;
            cbxDepartmentName.ValueMember = "DepartmentId";
            cbxDepartmentName.DisplayMember = "DepartmentName";

            //Bind Status
            DataSet ds1 = datamanage.GetDataSet("select * from [Status]", "status");
            DataRow row1 = ds1.Tables[0].NewRow();
            row1[0] = 0;
            row1[1] = "Please Select";
            ds1.Tables[0].Rows.InsertAt(row1, 0);

            //Bind Gender
            cbxGender.DisplayMember = "Please Select";
            cbxGender.SelectedIndex = 0;

        }

        /// <summary>
        /// Handles the Click event of the btnSave control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnSave_Click(object sender, EventArgs e)
        {

            string employeeId = txtEmployeeId.Text.ToString().Trim();
            if (string.IsNullOrEmpty(txtEmployeeId.Text.Trim()))
            {
                txtEmployeeId.Focus();
                errorProvider.SetError(txtEmployeeId, "Please input EmployeeId!");
                return;
            }
            if (string.IsNullOrEmpty(txtLYB.Text.Trim()))
            {
                txtLYB.Focus();
                errorProvider.SetError(txtEmployeeId, "Please input LastyearBalance!");
                return;
            }
            StaffService staffService = new StaffService();
            Staff staff = new Staff();
            staff.EmployeeId = employeeId;
            Staff restaff = staffService.GetStaffByEmployeeId(staff);
            if (restaff.StaffId != 0)
            {
                txtEmployeeId.Focus();
                errorProvider.SetError(txtEmployeeId, " EmployeeId have Existed!");
                return;
            }
            string staffName = txtStaffName.Text.ToString().Trim();
            string chineseName = txtChineseName.Text.ToString().Trim();
            string title = txtTitle.Text.ToString().Trim();
            DateTime onBoardDate = Convert.ToDateTime(dtpOnBoardDate.Text);
            DateTime startWorkDate = Convert.ToDateTime(dtpStartWorkDate.Text);
            string email = txtEmail.Text.ToString().Trim();
            string phoneNumber = txtPhoneNumber.Text.ToString().Trim();
            string gender = cbxGender.Text.ToString();
            if (gender.Trim().ToLower() == "Female")
            {
                gender = Convert.ToString(0);
            }
            else
                if (gender.Trim().ToLower() == "Male")
                {
                    gender = Convert.ToString(1);
                }
                else
                {
                    gender = Convert.ToString(2);
                }
            string isMarried = (rbtnYes.Checked == true) ? "1" : "0";
            string statusId = "1";
            string location = txtLocation.Text.ToString().Trim();
            string departmentId = cbxDepartmentName.SelectedValue.ToString();
            string employeeCategory = (rbtnLH.Checked == true) ? "LH" : "FLH";
            //string employeeCategory = cbxEmployeeCategory.Text.ToString();
            if (employeeCategory == "Please Select")
            {
                employeeCategory = string.Empty;
            }
            string contractTerm = txtContractTerm.Text.ToString();
            Single lastyearBalance = Convert.ToInt32(txtLYB.Text.ToString());
            if (lastyearBalance < 0 && lastyearBalance > -20)
            {
                lastyearBalance = Convert.ToInt32("-" + (DateTime.Now.Year - 1).ToString() + (-lastyearBalance).ToString());
            }
            else if (lastyearBalance >= 0 && lastyearBalance < 30)
            {
                lastyearBalance = Convert.ToInt32((DateTime.Now.Year - 1).ToString() + (lastyearBalance).ToString());
            }
            else
            {
                lastyearBalance = Convert.ToInt32((DateTime.Now.Year - 1).ToString() + "0");
            }
            OleDbDataReader dr = datamanage.GetCom("select * from [Staff]");
            if (dr.Read())
            {
                txtEmployeeId.Text = dr[1].ToString();
            }
            bool flag = datamanage.GetOleDbCom("insert into [Staff](EmployeeId,StaffName,ChineseName,Title,OnBoardDate,Email,PhoneNumber,Gender,Married,StatusId,Location,DepartmentId,EmployeeCategory,ContractTerm,LastyearRemains,StartWork) values('" + employeeId + "','" + staffName + "','" + chineseName + "','" + title + "','" + onBoardDate + "','" + email + "','" + phoneNumber + "','" + gender + "','" + isMarried + "','" + statusId + "','" + location + "','" + departmentId + "','" + employeeCategory + "','" + contractTerm + "','" + lastyearBalance + "','" + startWorkDate + "')");
            if (flag)
            {
                MessageBox.Show("Add Staff success!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        /// <summary>
        /// Handles the KeyPress event of the txtLYB control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyPressEventArgs"/> instance containing the event data.</param>
        private void txtLYB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsPunctuation(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (Char.IsPunctuation(e.KeyChar))
            {
                if (e.KeyChar != '.' || this.txtLYB.Text.Length == 0)
                {
                    e.Handled = true;
                }
                if (txtLYB.Text.LastIndexOf('.') != -1)
                {
                    e.Handled = true;
                }
            }
        }

    }
}