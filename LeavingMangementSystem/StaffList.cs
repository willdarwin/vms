using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
using System.IO;
using DataModel;
using BLL;

namespace LeavingManagementSystem
{
    public partial class StaffList : Form
    {
        DataManage dataManage = new DataManage();
        public static DataSet ds;
        public DataView dv = new DataView();
        public StaffList()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the Staff control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Staff_Load(object sender, EventArgs e)
        {
            DataManage.dataGridView = dgrdDisplayStaffInfo;
            showStaff(dgrdDisplayStaffInfo);
        }

        /// <summary>
        /// Shows the staff.
        /// </summary>
        /// <param name="dataGridView">The data grid view.</param>
        public void showStaff(DataGridView dataGridView)
        {
            dgrdDisplayStaffInfo.AutoGenerateColumns = false;
            this.dgrdDisplayStaffInfo.AllowUserToAddRows = false;

            DataGridViewCheckBoxColumn checkbox = new DataGridViewCheckBoxColumn();
            checkbox.HeaderText = "";
            checkbox.Width = 50;
            checkbox.FalseValue = 0;
            checkbox.TrueValue = 1;
            dgrdDisplayStaffInfo.Columns.Add(checkbox);

            DataGridViewTextBoxColumn staffId = new DataGridViewTextBoxColumn();
            staffId.Name = "StaffId";
            dgrdDisplayStaffInfo.Columns.Add(staffId);
            dgrdDisplayStaffInfo.Columns["staffId"].Visible = false;

            DataGridViewTextBoxColumn employeeId = new DataGridViewTextBoxColumn();
            employeeId.Name = "Login ID";
            dgrdDisplayStaffInfo.Columns.Add(employeeId);

            DataGridViewTextBoxColumn staffName = new DataGridViewTextBoxColumn();
            staffName.Name = "English Name";
            dgrdDisplayStaffInfo.Columns.Add(staffName);

            DataGridViewTextBoxColumn chineseName = new DataGridViewTextBoxColumn();
            chineseName.Name = "Chinese Name";
            dgrdDisplayStaffInfo.Columns.Add(chineseName);

            DataGridViewTextBoxColumn title = new DataGridViewTextBoxColumn();
            title.Name = "Position";
            dgrdDisplayStaffInfo.Columns.Add(title);

            DataGridViewTextBoxColumn onboardDate = new DataGridViewTextBoxColumn();
            onboardDate.Name = "Hire Date";
            dgrdDisplayStaffInfo.Columns.Add(onboardDate);

            DataGridViewTextBoxColumn email = new DataGridViewTextBoxColumn();
            email.Name = "Email address";
            email.Width = 150;
            dgrdDisplayStaffInfo.Columns.Add(email);

            DataGridViewTextBoxColumn phoneNumber = new DataGridViewTextBoxColumn();
            phoneNumber.Name = "Telephone";
            dgrdDisplayStaffInfo.Columns.Add(phoneNumber);

            DataGridViewTextBoxColumn gender = new DataGridViewTextBoxColumn();
            gender.Name = "Gender";
            dgrdDisplayStaffInfo.Columns.Add(gender);

            DataGridViewTextBoxColumn married = new DataGridViewTextBoxColumn();
            married.Name = "Married";
            dgrdDisplayStaffInfo.Columns.Add(married);

            DataGridViewTextBoxColumn statusName = new DataGridViewTextBoxColumn();
            statusName.Name = "StatusName";
            dgrdDisplayStaffInfo.Columns.Add(statusName);

            DataGridViewTextBoxColumn location = new DataGridViewTextBoxColumn();
            location.Name = "Location";
            dgrdDisplayStaffInfo.Columns.Add(location);

            DataGridViewTextBoxColumn departementName = new DataGridViewTextBoxColumn();
            departementName.Name = "DepartementName";
            dgrdDisplayStaffInfo.Columns.Add(departementName);

            DataGridViewTextBoxColumn employeeCategory = new DataGridViewTextBoxColumn();
            employeeCategory.Name = "Employee Category";
            dgrdDisplayStaffInfo.Columns.Add(employeeCategory);

            DataGridViewTextBoxColumn contractTerm = new DataGridViewTextBoxColumn();
            contractTerm.Name = "Contract Term";
            dgrdDisplayStaffInfo.Columns.Add(contractTerm);

            StaffService staffService = new StaffService();
            ds = staffService.GetAllStaffs();

            dgrdDisplayStaffInfo.DataSource = ds.Tables[0];

            dgrdDisplayStaffInfo.Columns["StaffId"].DataPropertyName = ds.Tables[0].Columns[0].ToString();
            dgrdDisplayStaffInfo.Columns["Login ID"].DataPropertyName = ds.Tables[0].Columns[1].ToString();
            dgrdDisplayStaffInfo.Columns["English Name"].DataPropertyName = ds.Tables[0].Columns[2].ToString();
            dgrdDisplayStaffInfo.Columns["Chinese Name"].DataPropertyName = ds.Tables[0].Columns[3].ToString();
            dgrdDisplayStaffInfo.Columns["Position"].DataPropertyName = ds.Tables[0].Columns[4].ToString();
            dgrdDisplayStaffInfo.Columns["Hire Date"].DataPropertyName = ds.Tables[0].Columns[5].ToString();
            dgrdDisplayStaffInfo.Columns["Email address"].DataPropertyName = ds.Tables[0].Columns[6].ToString();
            dgrdDisplayStaffInfo.Columns["Telephone"].DataPropertyName = ds.Tables[0].Columns[7].ToString();
            dgrdDisplayStaffInfo.Columns["Gender"].DataPropertyName = ds.Tables[0].Columns[8].ToString();
            dgrdDisplayStaffInfo.Columns["Married"].DataPropertyName = ds.Tables[0].Columns[9].ToString();
            dgrdDisplayStaffInfo.Columns["StatusName"].DataPropertyName = ds.Tables[0].Columns[10].ToString();
            dgrdDisplayStaffInfo.Columns["Location"].DataPropertyName = ds.Tables[0].Columns[11].ToString();
            dgrdDisplayStaffInfo.Columns["DepartementName"].DataPropertyName = ds.Tables[0].Columns[12].ToString();
            dgrdDisplayStaffInfo.Columns["Employee Category"].DataPropertyName = ds.Tables[0].Columns[13].ToString();
            dgrdDisplayStaffInfo.Columns["Contract Term"].DataPropertyName = ds.Tables[0].Columns[14].ToString();
            dgrdDisplayStaffInfo.CellFormatting += new DataGridViewCellFormattingEventHandler(dgrdDisplayStaffInfo_CellFormatting);

            int t = dgrdDisplayStaffInfo.Columns.Count;
            for (int j = 1; j < t; j++)
            {
                dgrdDisplayStaffInfo.Columns[j].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgrdDisplayStaffInfo.Columns[j].ReadOnly = true;
            }
        }

        /// <summary>
        /// Handles the CellFormatting event of the dgrdDisplayStaffInfo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.DataGridViewCellFormattingEventArgs"/> instance containing the event data.</param>
        private void dgrdDisplayStaffInfo_CellFormatting(object sender, System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
        {
            if (e == null || e.Value == null || !(sender is DataGridView))
            {
                return;
            }
            DataGridView view1 = (DataGridView)sender;
            object originalValue1 = e.Value;
            if (view1.Columns[e.ColumnIndex].DataPropertyName == "Married")
            {
                if (originalValue1.ToString() == "No" || originalValue1.ToString() == "False")
                {
                    e.Value = "No";
                }
                else
                {
                    e.Value = "Yes";
                }

                if (e == null || e.Value == null || !(sender is DataGridView))
                {
                    return;
                }
            }

            DataGridView view = (DataGridView)sender;
            object originalValue = e.Value;
            if (view.Columns[e.ColumnIndex].DataPropertyName == "Gender")
            {
                if (originalValue.ToString() == "0" || originalValue.ToString() == "Female")
                {
                    e.Value = "Female";
                }
                else if (originalValue.ToString() == "1" || originalValue.ToString() == "Male")
                { e.Value = "Male"; }
                else
                {
                    e.Value = string.Empty;
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the departmentMangagementToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void departmentMangagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DepartmentManagement departmentManagement = new DepartmentManagement();
            departmentManagement.Show();
        }

        /// <summary>
        /// Handles the Click event of the userManagementToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void userManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserManagement userManagement = new UserManagement();
            userManagement.Show();
        }

        /// <summary>
        /// Handles the Click event of the systemConstantManagementToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void systemConstantManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemConstant systemConstant = new SystemConstant();
            systemConstant.Show();
        }

        /// <summary>
        /// Handles the Click event of the btnSearch control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            StaffService staffService = new StaffService();
            ds = staffService.GetAllStaffs();

            string name = txtStaffName.Text.ToString().Trim();
            string id = txtStaffId.Text.ToString().Trim();
            string cname = txtChineseName.Text.ToString().Trim();
            DateTime sOnboard = dtpOnboardStart.Value;
            DateTime eOnboard = dtpOnboardEnd.Value;

            dv.Table = ds.Tables[0];
            dv.RowFilter = "ChineseName like '%" + cname + "%' And StaffName like '%" + name + "%' And EmployeeId like '%" + id + "%' And OnboardDate >= '" + sOnboard + "' And OnboardDate <= '" + eOnboard + "' ";
            dgrdDisplayStaffInfo.DataSource = dv;

            //dgrdDisplayStaffInfo.DataSource = ds.Tables[0];

            dgrdDisplayStaffInfo.Columns["StaffId"].DataPropertyName = ds.Tables[0].Columns[0].ToString();
            dgrdDisplayStaffInfo.Columns["Login Id"].DataPropertyName = ds.Tables[0].Columns[1].ToString();
            dgrdDisplayStaffInfo.Columns["English Name"].DataPropertyName = ds.Tables[0].Columns[2].ToString();
            dgrdDisplayStaffInfo.Columns["Chinese Name"].DataPropertyName = ds.Tables[0].Columns[3].ToString();
            dgrdDisplayStaffInfo.Columns["Position"].DataPropertyName = ds.Tables[0].Columns[4].ToString();
            dgrdDisplayStaffInfo.Columns["Hire Date"].DataPropertyName = ds.Tables[0].Columns[5].ToString();
            dgrdDisplayStaffInfo.Columns["Email address"].DataPropertyName = ds.Tables[0].Columns[6].ToString();
            dgrdDisplayStaffInfo.Columns["Telephone"].DataPropertyName = ds.Tables[0].Columns[7].ToString();
            dgrdDisplayStaffInfo.Columns["Gender"].DataPropertyName = ds.Tables[0].Columns[8].ToString();
            dgrdDisplayStaffInfo.Columns["Married"].DataPropertyName = ds.Tables[0].Columns[9].ToString();
            dgrdDisplayStaffInfo.Columns["StatusName"].DataPropertyName = ds.Tables[0].Columns[10].ToString();
            dgrdDisplayStaffInfo.Columns["Location"].DataPropertyName = ds.Tables[0].Columns[11].ToString();
            dgrdDisplayStaffInfo.Columns["DepartementName"].DataPropertyName = ds.Tables[0].Columns[12].ToString();
            dgrdDisplayStaffInfo.Columns["Employee Category"].DataPropertyName = ds.Tables[0].Columns[13].ToString();
            dgrdDisplayStaffInfo.Columns["Contract Term"].DataPropertyName = ds.Tables[0].Columns[14].ToString();
            dgrdDisplayStaffInfo.CellFormatting += new DataGridViewCellFormattingEventHandler(dgrdDisplayStaffInfo_CellFormatting);

        }

        /// <summary>
        /// Handles the Click event of the btnAdd control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddStaff addStaff = new AddStaff();
            addStaff.Show();
        }

        /// <summary>
        /// Handles the Click event of the btnEdit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            bool flag = true;
            string staffId = string.Empty;
            int i = 0;
            try
            {
                while (flag)
                {
                    if (Convert.ToBoolean(this.dgrdDisplayStaffInfo.Rows[i].Cells[0].EditedFormattedValue) == true)
                    {
                        staffId = dgrdDisplayStaffInfo.Rows[i].Cells["staffId"].Value.ToString().Trim();
                        flag = false;
                    }
                    else
                    {
                        i++;
                    }
                    if (i >= dgrdDisplayStaffInfo.Rows.Count)
                    {
                        flag = false;
                    }
                }
                int rows = this.dgrdDisplayStaffInfo.SelectedRows[0].Index;
                staffId = dgrdDisplayStaffInfo.Rows[rows].Cells["staffId"].Value.ToString();
                if (staffId != "")
                {
                    ModifyStaff modifyStaff = new ModifyStaff(staffId);
                    modifyStaff.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Please Select! ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dgrdDisplayStaffInfo.Refresh();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnDelete control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete these Staff?", "Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                for (int i = 0; i < dgrdDisplayStaffInfo.Rows.Count; )
                {
                    if (Convert.ToBoolean(this.dgrdDisplayStaffInfo.Rows[i].Cells[0].EditedFormattedValue) == true)
                    {
                        string staffId = dgrdDisplayStaffInfo.Rows[i].Cells["staffId"].Value.ToString().Trim();
                        this.dgrdDisplayStaffInfo.Rows.RemoveAt(i);
                        bool flag = dataManage.GetOleDbCom("update [Staff] set StatusId= -1 where StaffId=" + Convert.ToInt32(staffId) + "");
                    }
                    else
                    {
                        i++;
                    }
                }
                MessageBox.Show("Delete Staff success!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dgrdDisplayStaffInfo.Refresh();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnImport control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnImport_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            DataSet ds = new DataSet();
                            ds = ExcelToDS(openFileDialog1.FileName);

                            StaffService staffService = new StaffService();

                            int errorcount = 0;
                            int insertcount = 0;
                            int updatecount = 0;

                            for (int i = 0; i < ds.Tables[0].Rows.Count - 1; i++)
                            {
                                string employeeId = ds.Tables[0].Rows[i]["Login ID"].ToString();
                                string staffName = ds.Tables[0].Rows[i]["English Name"].ToString();
                                string chineseName = ds.Tables[0].Rows[i]["Chinese Name"].ToString();
                                string title = ds.Tables[0].Rows[i]["Position"].ToString();
                                string location = ds.Tables[0].Rows[i]["Location"].ToString();
                                location = location.Replace("'", "''");
                                string obd = ds.Tables[0].Rows[i]["Hire Date"].ToString();
                                obd = obd.Replace(".", "-");
                                DateTime onBoardDate = Convert.ToDateTime(obd);
                                string pn = ds.Tables[0].Rows[i]["Telephone"].ToString().Trim();
                                pn = pn.Replace(" ", "");
                                string phoneNumber = pn;
                                string gender = ds.Tables[0].Rows[i]["Gender"].ToString();
                                string employeeCategory = ds.Tables[0].Rows[i]["Employee Category"].ToString();
                                string contractTerm = ds.Tables[0].Rows[i]["Contract Term"].ToString();
                                string email = ds.Tables[0].Rows[i]["Email address"].ToString();
                                Single lastyearRemains = 20000;
                                if (gender.Trim() == "F")
                                {
                                    gender = "0";
                                }
                                else
                                {
                                    gender = "1";
                                }
                                int statusId = 1;
                                int departmentId = 1;
                                int isMarried = 0;

                                if (employeeId != "" && staffName != "" && onBoardDate != null)
                                {
                                    Staff staff = new Staff();
                                    staff.EmployeeId = employeeId;
                                    Staff restaff = staffService.GetStaffByEmployeeId(staff);
                                    if (restaff.StaffId != 0)
                                    {
                                        staff.StaffId = restaff.StaffId;
                                        staff.StaffName = staffName;
                                        staff.StatusId = statusId;
                                        staff.Title = title;
                                        staff.ChineseName = chineseName;
                                        staff.ContractTerm = contractTerm;
                                        staff.Email = email;
                                        staff.EmployeeCategory = employeeCategory;
                                        staff.Gender = Convert.ToInt32(gender);
                                        staff.Location = location;
                                        staff.OnboardDate = onBoardDate;
                                        staff.PhoneNumber = phoneNumber;
                                        staff.DepartmentId = restaff.DepartmentId;
                                        staff.LastyearRemains = restaff.LastyearRemains;
                                        staff.Married = restaff.Married;
                                        Response flag = staffService.UpdateStaff(staff);
                                        updatecount++;

                                    }
                                    else
                                    {
                                        bool flag = dataManage.GetOleDbCom("insert into [Staff](EmployeeId,StaffName,ChineseName,Title,Location,EmployeeCategory,ContractTerm,OnBoardDate,Email,PhoneNumber,Gender,Married,StatusId,DepartmentId,LastyearRemains) values('" + employeeId + "','" + staffName + "','" + chineseName + "','" + title + "','" + location + "','" + employeeCategory + "','" + contractTerm + "','" + onBoardDate + "','" + email + "','" + phoneNumber + "','" + gender + "','" + isMarried + "','" + statusId + "','" + departmentId + "','" + lastyearRemains + "')");
                                        insertcount++;
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("There are some information errors in row " + i + " !");
                                    errorcount++;
                                    ;
                                }
                            }
                            MessageBox.Show(insertcount + " import！ " + updatecount + " update！ " + errorcount + " null！", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.dgrdDisplayStaffInfo.Refresh();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.dgrdDisplayStaffInfo.Refresh();
                }
            }
        }

        /// <summary>
        /// Excels to DS.
        /// </summary>
        /// <param name="Path">The path.</param>
        /// <returns></returns>
        public DataSet ExcelToDS(string Path)
        {
            string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + Path + ";" + "Extended Properties='Excel 12.0;HDR=Yes;IMEX=1' ";
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            string strExcel = "";
            OleDbDataAdapter myCommand = null;
            DataSet ds = null;
            strExcel = "select * from [VITC$]";
            myCommand = new OleDbDataAdapter(strExcel, strConn);
            ds = new DataSet();
            myCommand.Fill(ds, "table1");
            return ds;
        }

        /// <summary>
        /// Handles the Click event of the btnDetails control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnDetails_Click(object sender, EventArgs e)
        {
            try
            {
                int rows = this.dgrdDisplayStaffInfo.SelectedRows[0].Index;
                int staffId = Convert.ToInt32(dgrdDisplayStaffInfo.Rows[rows].Cells["staffId"].Value);
                VacationDetails vacationDetails = new VacationDetails(staffId);
                vacationDetails.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please Select! ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dgrdDisplayStaffInfo.Refresh();
            }

        }

        /// <summary>
        /// Handles the FormClosing event of the StaffList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.FormClosingEventArgs"/> instance containing the event data.</param>
        private void StaffList_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to exit?", "System prompt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                e.Cancel = false;
                System.Windows.Forms.Application.ExitThread();
                this.Dispose();
                this.Close();
            }
            else
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Prints all.
        /// </summary>
        /// <param name="dt">The dt.</param>
        public void printAll(System.Data.DataTable dt)
        {
            try
            {
                if (dt.Rows.Count == 0)
                {
                    return;
                }

                string saveFileName = "";
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.DefaultExt = "xlsx";
                saveDialog.FileName = "VIT TJ Staff List " + DateTime.Today.ToString("yyyy-MM-dd");
                saveDialog.ShowDialog();
                saveFileName = saveDialog.FileName;
                if (saveFileName.IndexOf(":") < 0)
                {
                    return;
                }

                Excel.Application myExcel = new Excel.Application();
                if (myExcel == null)
                {
                    MessageBox.Show("Can not Create a Sheet! Make Sure your computer has installed the Excel!");
                    return;
                }

                myExcel.Application.Workbooks.Add(true);
                myExcel.Visible = false;

                Excel.Workbook myBook = myExcel.Workbooks[1];
                Excel.Worksheet mySheet = myBook.Worksheets[1];
                mySheet.Name = "VITC";
                mySheet.Columns.ColumnWidth = 15;
                mySheet.Rows[1].RowHeight = 50;
                mySheet.Rows[1].Interior.ColorIndex = 23;
                mySheet.Rows[1].Font.Size = 12;
                mySheet.Rows[1].HorizontalAlignment = Excel.Constants.xlCenter;
                mySheet.Rows[1].VerticalAlignment = Excel.Constants.xlCenter;
                mySheet.Range[mySheet.Cells[1, dt.Columns.Count + 1], mySheet.Cells[1, dt.Columns.Count + 8]].ColumnWidth = 20;


                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    mySheet.Cells[1, i + 1] = dgrdDisplayStaffInfo.Columns[i].HeaderText;
                }
                mySheet.Cells[1, dt.Columns.Count + 1] = "Last Year Annual Leave Balance";
                mySheet.Cells[1, dt.Columns.Count + 2] = "Total Annual Leave";
                mySheet.Cells[1, dt.Columns.Count + 3] = "Used Annual Leave";
                mySheet.Cells[1, dt.Columns.Count + 4] = "Annual Leave Balance";
                mySheet.Cells[1, dt.Columns.Count + 5] = "Total Sick Leave";
                mySheet.Cells[1, dt.Columns.Count + 6] = "Used Sick Leave";
                mySheet.Cells[1, dt.Columns.Count + 7] = "Sick Leave Balance";
                mySheet.Cells[1, dt.Columns.Count + 8] = "Last Year Used Sick Leave";

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            string str = dt.Rows[i][j].ToString();
                            if (j == dt.Columns.Count-1)
                            {
                                if (str.Length < 5)
                                {
                                    str = "0";
                                }
                                else if (Convert.ToSingle(str) < 0)
                                {
                                    if (str.Length == 5)
                                    {
                                        str = "0";
                                    }
                                    else
                                    {
                                        String lyb = str;
                                        lyb = lyb.Substring(5);
                                        str = Convert.ToSingle("-" + lyb).ToString();
                                    }
                                }
                                else
                                {
                                    str = Convert.ToSingle(str.Substring(4)).ToString();
                                }
                            }
                            if (j == 8) {
                                if (str == "1") { 
                                    str = "M";
                                }
                                else
                                {
                                    str = "F"; 
                                }
                            }
                            mySheet.Cells[i + 2, j + 2] = "'" + str;

                        }
                        GetStaffDetails getStaffDetails = new GetStaffDetails();
                        Staff staffinfo = new Staff();
                        staffinfo = getStaffDetails.Getstaff(Convert.ToInt32(dt.Rows[i][0].ToString()));
                        StaffDetails staffDetails = getStaffDetails.GetStaffDetail(staffinfo);
                        mySheet.Cells[i + 2, dt.Columns.Count + 2] = "'" + staffDetails.totalAnnualLeave;
                        mySheet.Cells[i + 2, dt.Columns.Count + 3] = "'" + staffDetails.usedAnnualLeave;
                        mySheet.Cells[i + 2, dt.Columns.Count + 4] = "'" + staffDetails.annualLeaveBalance;
                        mySheet.Cells[i + 2, dt.Columns.Count + 5] = "'" + staffDetails.totalSickLeave;
                        mySheet.Cells[i + 2, dt.Columns.Count + 6] = "'" + staffDetails.usedSickLeave;
                        mySheet.Cells[i + 2, dt.Columns.Count + 7] = "'" + staffDetails.sickLeaveBalance;
                        mySheet.Cells[i + 2, dt.Columns.Count + 8] = "'" + staffDetails.lastyearUsedSickLeave;
                    }
                }

                myBook.SaveCopyAs(saveFileName);
                myBook.Close(false, Type.Missing, Type.Missing);

                myExcel.Quit();
                myExcel = null;
                GC.Collect();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error" + ex);
            }
        }

        /// <summary>
        /// Handles the Click event of the btnExport control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            printAll(ds.Tables[0]);
        }

        /// <summary>
        /// Handles the TextChanged event of the txtChinese control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void txtChinese_TextChanged(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
        }

        /// <summary>
        /// Handles the TextChanged event of the txtStaffId control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void txtStaffId_TextChanged(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
        }

        /// <summary>
        /// Handles the TextChanged event of the txtStaffName control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void txtStaffName_TextChanged(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
        }

        /// <summary>
        /// Handles the ValueChanged event of the dtpOnboardStart control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void dtpOnboardStart_ValueChanged(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
        }

        /// <summary>
        /// Handles the ValueChanged event of the dtpOnboardEnd control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void dtpOnboardEnd_ValueChanged(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
        }

        /// <summary>
        /// Handles the CellContentDoubleClick event of the dgrdDisplayStaffInfo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.DataGridViewCellEventArgs"/> instance containing the event data.</param>
        private void dgrdDisplayStaffInfo_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnDetails_Click(sender, e);
        }

    }
}
