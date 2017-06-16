using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAL;
using DataModel;
using BLL;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace LeavingManagementSystem
{
    public partial class VacationDetails : Form
    {
        #region
        protected int CurrentStaffId = 1;
        public VacationDetails(int staffId)
        {
            InitializeComponent();
            CurrentStaffId = staffId;
        }
        protected int CommonLeaveId;
        protected int OtherLeaveId;
        protected string OtherLeaveName;
        protected LeaveDetails CommonLeaving = new LeaveDetails();
        protected LeaveDetails OtherLeaving = new LeaveDetails();
        protected int pageSize = 5;     //row displayed in each page
        protected int nMax = 0;         //total number of record
        protected int pageCount = 0;    //the number of pages
        protected int pageCurrent = 0;   //current page number
        protected int nCurrent = 0;      //current row number of record
        List<LeaveDetails> allDetails = new List<LeaveDetails>();
        List<LeaveDetails> twoyearsDetails = new List<LeaveDetails>();
        List<LeaveDetails> OneYearDetails = new List<LeaveDetails>();
        BindingList<LeaveDetails> detailsBindingList = new BindingList<LeaveDetails>();
        private static DateTime currentDate = DateTime.Now.Date;
        private static int yearNow = currentDate.Year;
        private static int MonthNow = currentDate.Month;
        private DateTime janOneYear = Convert.ToDateTime(yearNow + "-1-1");
        private DateTime janOneYearAfter = Convert.ToDateTime(yearNow + 1 + "-1-1");
        private DateTime MarOneYear = Convert.ToDateTime(yearNow + "-4-1");
        Staff showStaffInfo = new Staff();//store staff information

        Single sickLeaveRemainDay = 0;
        Single annualLeaveRemainDay = 0;

        #endregion

        /// <summary>
        /// Handles the Load event of the Vacation control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Vacation_Load(object sender, EventArgs e)
        {
            PickerforStart.Value = currentDate;
            PickerforEnd.Value = currentDate;

            GetStaffInfo();
            AssignDatatoList();//"allDetails"padding data 
            AddLeavingsAttributetoList(allDetails);//add "Leavings"(attribute) to List "allDetails"
            BindVactionDetails();
            BindStaffInfo();//Bind data to staff information
            BindCommon();//Bind data to "common" 
            BindOther();//Bind data to "others"
            BuildInterfaceOfRequestHistory();//Build interface of DataGridView
            InitPagingList();//paging list-"detailsBindingList" initialization
            BindingDataToRequestHistory();//DataGridView binding
            BindStartTime();//dropdownlist
            BindEndTime();//dropdownlist
        }

        /// <summary>
        /// Gets the staff info.
        /// </summary>
        private void GetStaffInfo()
        {
            try
            {
                GetStaffDetails getStaffDetails = new GetStaffDetails();
                showStaffInfo = getStaffDetails.Getstaff(CurrentStaffId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error" + ex);
            }
        }

        /// <summary>
        /// assign data to List "allDetails"
        /// </summary>
        private void AssignDatatoList()
        {
            GetStaffDetails getStaffDetails = new GetStaffDetails();
            allDetails = getStaffDetails.GetVacationDetails(CurrentStaffId);

            nMax = allDetails.Count();
            if (nMax % pageSize == 0)
            {
                pageCount = nMax / pageSize;
            }
            else
            {
                pageCount = nMax / pageSize + 1;
            }
        }

        /// <summary>
        /// add attribute to data 
        /// </summary>
        private void AddLeavingsAttributetoList(List<LeaveDetails> list)
        {
            VacationTypeService typeService = new VacationTypeService();
            List<LeaveType> allTypes = new List<LeaveType>();
            allTypes = typeService.ObtainAllTypes();
            for (int i = 0; i < list.Count; i++)//add Leave name to "allDetails"
            {
                int leaveTypeId = list.ElementAt(i).LeaveTypeId;
                string name = allTypes.ElementAt(leaveTypeId - 1).LeaveTypeName.ToString();
                list.ElementAt(i).Leavings = new LeaveType
                {
                    LeaveTypeId = leaveTypeId,
                    LeaveTypeName = name
                };
            }
        }

        /// <summary>
        /// show vacation details
        /// </summary>
        private void BindVactionDetails()
        {
            GetStaffDetails getStaffDetails = new GetStaffDetails();
            StaffDetails staffDetails = new StaffDetails();
            staffDetails = getStaffDetails.GetStaffDetail(showStaffInfo);

            lblTA.Text = staffDetails.totalAnnualLeave;//total annual leave
            lblUA.Text = staffDetails.usedAnnualLeave;//used annual leave
            lblAB.Text = staffDetails.annualLeaveBalance;//annual leave balance

            lblTS.Text = staffDetails.totalSickLeave;//Total sick leave
            lblUS.Text = staffDetails.usedSickLeave;//Used sick leave
            lblSB.Text = staffDetails.sickLeaveBalance;//sick leave balance
            lblLYUSL.Text = staffDetails.lastyearUsedSickLeave;//last year used sick leave

            lblUNP.Text = staffDetails.usednopayLeave;//Used NoPay leave
            lblUML.Text = staffDetails.usedmarriageLeave;//Used Marriage leave
            lblUCL.Text = staffDetails.usedcompassionate;//Used Compassionate leave

            if (Convert.ToInt32(showStaffInfo.Gender) > 0)
            {
                lblUPL.Text = staffDetails.usedpaternity;//Used Paternity leave
            }
            else
            {
                lblUsedPaternityLeave.Text = "Used Maternity Leave";
                lblUPL.Text = staffDetails.usedmaternity;//Used Maternity leave
            }
            
            annualLeaveRemainDay = Convert.ToSingle(staffDetails.annualLeaveBalance);
            sickLeaveRemainDay = Convert.ToSingle(staffDetails.sickLeaveBalance);
            if (annualLeaveRemainDay <= 0)
            {
                lblAB.ForeColor = Color.Red;
            }
            if (sickLeaveRemainDay <= 0)
            {
                lblSB.ForeColor = Color.Red;
            }

        }

        /// <summary>
        /// staff information binding
        /// </summary>
        private void BindStaffInfo()
        {

            this.lblStaffName.Text = showStaffInfo.StaffName;
            this.lblStaffID.Text = showStaffInfo.EmployeeId;
            if (Convert.ToInt32(showStaffInfo.Gender) > 0)
            {
                this.lblUserGender.Text = "Male";
            }
            else
            {
                this.lblUserGender.Text = "Female";
            }
            this.lblUserOnBoardDate.Text = showStaffInfo.OnboardDate.Date.ToShortDateString();
        }

        /// <summary>
        /// "CommonCombo" binding
        /// </summary>
        private void BindCommon()
        {
            VacationTypeService leavings = new VacationTypeService();
            List<LeaveType> leaveTopSix = new List<LeaveType>();
            leaveTopSix = leavings.ObtainVacationTypes("common");
            this.CommonCombo.DataSource = leaveTopSix;
            LeaveType l = new LeaveType { LeaveTypeId = -1, LeaveTypeName = "Please Select", };
            leaveTopSix.Insert(0, l);
            if (Convert.ToInt32(showStaffInfo.Gender) > 0)
            {
                LeaveType paternityleave = new LeaveType { LeaveTypeId = 7, LeaveTypeName = "Paternity Leave", };
                leaveTopSix.Insert(3, paternityleave);
            }
            else
            {
                LeaveType maternityleave = new LeaveType { LeaveTypeId = 5, LeaveTypeName = "Maternity Leave", };
                leaveTopSix.Insert(3, maternityleave);
            }
            this.CommonCombo.DisplayMember = "LeaveTypeName";
            this.CommonCombo.ValueMember = "LeaveTypeId";
        }

        /// <summary>
        /// "OthersCombo" binding
        /// </summary>
        private void BindOther()
        {
            VacationTypeService leavings = new VacationTypeService();
            List<LeaveType> leaveRest = new List<LeaveType>();
            leaveRest = leavings.ObtainVacationTypes("rest");
            if (showStaffInfo.Gender > 0)
            {
                leaveRest.RemoveAt(1);
            }
            else
            {
                leaveRest.RemoveAt(2);
            }
            this.OthersCombo.DataSource = leaveRest;
            LeaveType l = new LeaveType { LeaveTypeId = -1, LeaveTypeName = "Please Select", };
            leaveRest.Insert(0, l);
            this.OthersCombo.DisplayMember = "LeaveTypeName";
            this.OthersCombo.ValueMember = "LeaveTypeId";
        }

        /// <summary>
        /// DataGridView"RequestHistory" initializing without databinding
        /// </summary>
        private void BuildInterfaceOfRequestHistory()
        {
            RequestHistory.AutoGenerateColumns = false;
            this.RequestHistory.AllowUserToAddRows = false;

            #region Column define

            DataGridViewCheckBoxColumn CheckBox = new DataGridViewCheckBoxColumn();//column0
            CheckBox.HeaderText = "";
            CheckBox.FalseValue = 0;
            CheckBox.TrueValue = 1;
            CheckBox.FillWeight = 5;
            RequestHistory.Columns.Add(CheckBox);

            DataGridViewTextBoxColumn DetailId = new DataGridViewTextBoxColumn();//column1
            DetailId.Name = "DetailId";
            RequestHistory.Columns.Add(DetailId);
            RequestHistory.Columns["DetailId"].Visible = false;
            RequestHistory.Columns["DetailId"].DataPropertyName = "LeaveDetailsId";

            DataGridViewTextBoxColumn VacationId = new DataGridViewTextBoxColumn();//column2
            VacationId.Name = "VacationId";
            RequestHistory.Columns.Add(VacationId);
            RequestHistory.Columns["VacationId"].Visible = false;
            RequestHistory.Columns["VacationId"].DataPropertyName = "LeaveTypeId";

            DataGridViewTextBoxColumn Employee = new DataGridViewTextBoxColumn();//column3
            Employee.Name = "Staff";
            RequestHistory.Columns.Add(Employee);
            RequestHistory.Columns["Staff"].Visible = false;
            RequestHistory.Columns["Staff"].DataPropertyName = "StaffId";

            DataGridViewTextBoxColumn VacationName = new DataGridViewTextBoxColumn();//column4
            VacationName.HeaderText = "Vacation Name";
            VacationName.Name = "Name";
            VacationName.FillWeight = 15;
            RequestHistory.Columns.Add(VacationName);
            RequestHistory.Columns["Name"].DataPropertyName = "Leavings/LeaveTypeName";

            DataGridViewTextBoxColumn StartDate = new DataGridViewTextBoxColumn();//column5
            StartDate.HeaderText = "Start Date";
            StartDate.Name = "Start";
            StartDate.FillWeight = 15;
            RequestHistory.Columns.Add(StartDate);
            RequestHistory.Columns["Start"].DataPropertyName = "StartDate";

            DataGridViewTextBoxColumn EndDate = new DataGridViewTextBoxColumn();//column6
            EndDate.HeaderText = "End Date";
            EndDate.Name = "End";
            EndDate.FillWeight = 15;
            RequestHistory.Columns.Add(EndDate);
            RequestHistory.Columns["End"].DataPropertyName = "EndDate";

            DataGridViewTextBoxColumn Duration = new DataGridViewTextBoxColumn();//column7
            Duration.HeaderText = "Duration";
            Duration.Name = "Duration";
            Duration.FillWeight = 10;
            RequestHistory.Columns.Add(Duration);
            RequestHistory.Columns["Duration"].DataPropertyName = "Duration";

            DataGridViewTextBoxColumn Remark = new DataGridViewTextBoxColumn();//column8
            Remark.HeaderText = "Remark";
            Remark.Name = "Remark";
            Remark.FillWeight = 30;
            RequestHistory.Columns.Add(Remark);
            RequestHistory.Columns["Remark"].DataPropertyName = "Remark";

            #endregion

            #region columns settings

            RequestHistory.Columns["Name"].ReadOnly = true;
            RequestHistory.Columns["Start"].ReadOnly = true;
            RequestHistory.Columns["End"].ReadOnly = true;
            RequestHistory.Columns["Duration"].ReadOnly = true;
            RequestHistory.Columns["Remark"].ReadOnly = true;

            #endregion

        }

        /// <summary>
        /// bind "detailsBindingList" to "RequestHistory"
        /// </summary>
        private void BindingDataToRequestHistory()
        {
            RequestHistory.DataSource = detailsBindingList;
            for (int i = 0; i < detailsBindingList.Count; i++)
            {
                RequestHistory.Rows[i].Cells["DetailId"].Value = detailsBindingList[i].LeaveDetailsId;
                RequestHistory.Rows[i].Cells["VacationId"].Value = detailsBindingList[i].LeaveTypeId;
                RequestHistory.Rows[i].Cells["Staff"].Value = detailsBindingList[i].StaffId;
                RequestHistory.Rows[i].Cells["Name"].Value = detailsBindingList[i].Leavings.LeaveTypeName;
                RequestHistory.Rows[i].Cells["Start"].Value = detailsBindingList[i].StartDate;
                RequestHistory.Rows[i].Cells["End"].Value = detailsBindingList[i].EndDate;
                RequestHistory.Rows[i].Cells["Duration"].Value = detailsBindingList[i].Duration;
                RequestHistory.Rows[i].Cells["Remark"].Value = detailsBindingList[i].Remark;
            }
        }

        /// <summary>
        /// delete item(s)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to delete the record?", "Dialog", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                LeaveDetailsService service = new LeaveDetailsService();
                for (int i = 0; i < RequestHistory.Rows.Count; )
                {
                    if (Convert.ToBoolean(RequestHistory.Rows[i].Cells[0].Value) == true)
                    {
                        LeaveDetails detail = new LeaveDetails();
                        detail = detailsBindingList.ElementAt(i);
                        detailsBindingList.RemoveAt(i);
                        service.RemoveDetails(detail);
                    }
                    else
                    {
                        i++;
                    }
                }
                RequestHistory.DataSource = null;
                allDetails.Clear();
                detailsBindingList.Clear();
                AssignDatatoList();
                AddLeavingsAttributetoList(allDetails);
                BindVactionDetails();
                nCurrent = 0;
                pageCurrent = 0;
                InitPagingList();
                MessageBox.Show("Submit Successfully !");
            }
        }

        /// <summary>
        /// "StartTimeCombo" binding
        /// </summary>
        private void BindStartTime()
        {
            this.StartTimeCombo.Items.Insert(0, "08:30:00");
            this.StartTimeCombo.Items.Insert(1, "13:00:00");
            this.StartTimeCombo.SelectedIndex = 0;
        }

        /// <summary>
        /// "EndTimeCombo" binding
        /// </summary>
        private void BindEndTime()
        {
            this.EndTimeCombo.Items.Insert(0, "11:30:00");
            this.EndTimeCombo.Items.Insert(1, "17:00:00");
            this.EndTimeCombo.DisplayMember = "Name";
            this.EndTimeCombo.ValueMember = "Time";
            this.EndTimeCombo.SelectedIndex = 0;
        }

        /// <summary>
        /// select all or invert
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectAllorInvert_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.RequestHistory.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value) == false)
                {
                    Convert.ToBoolean(row.Cells[0].Value = true);
                }
                else
                {
                    Convert.ToBoolean(row.Cells[0].Value = false);
                }
            }
        }

        /// <summary>
        /// paging
        /// </summary>
        private void InitPagingList()
        {
            int lastMember;
            if (nMax > nCurrent + pageSize)
            {
                lastMember = nCurrent + pageSize;
            }
            else
            {
                lastMember = nMax;
            }
            for (int i = nCurrent; i < lastMember; i++)
            {
                detailsBindingList.Add(allDetails[i]);
            }
            RequestHistory.DataSource = null;
            BindingDataToRequestHistory();
            if (pageCount == 0)
            {
                showpageLab.Text = "0/0";
            }
            else
            {
                showpageLab.Text = pageCurrent + 1 + "/" + pageCount;
            }
        }

        /// <summary>
        /// Handles the Click event of the Previous control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Previous_Click(object sender, EventArgs e)
        {
            if (pageCurrent - 1 >= 0)
            {
                pageCurrent -= 1;
                nCurrent = pageSize * pageCurrent;
                detailsBindingList.Clear();
                InitPagingList();
            }
        }

        /// <summary>
        /// Handles the Click event of the Next control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Next_Click(object sender, EventArgs e)
        {
            if (pageCurrent + 1 < pageCount)
            {
                pageCurrent += 1;
                nCurrent = pageSize * pageCurrent;
                detailsBindingList.Clear();
                InitPagingList();
            }
        }

        /// <summary>
        /// Handles the Click event of the GotoEnd control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void GotoEnd_Click(object sender, EventArgs e)
        {
            if (pageCount >= 1)
            {
                pageCurrent = pageCount - 1;
                nCurrent = pageSize * pageCurrent;
            }
            detailsBindingList.Clear();
            InitPagingList();
        }

        /// <summary>
        /// Handles the Click event of the GoTo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void GoTo_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(numericUpDownPage.Value);
            if (page <= 0)
            {
                pageCurrent = 0;
            }
            else if (page > pageCount)
            {
                if (pageCount >= 1)
                {
                    pageCurrent = pageCount - 1;
                }
            }
            else
            {
                pageCurrent = page - 1;
            }
            nCurrent = pageSize * pageCurrent;
            detailsBindingList.Clear();
            InitPagingList();
        }

        /// <summary>
        /// Handles the Click event of the GotoFirst control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void GotoFirst_Click(object sender, EventArgs e)
        {
            pageCurrent = 0;
            nCurrent = pageSize * pageCurrent;
            detailsBindingList.Clear();
            InitPagingList();
        }

        /// <summary>
        /// add new item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddOthers_Click(object sender, EventArgs e)
        {
            int vacationId = 0;
            string vacationName;
            int otherVacationId = Convert.ToInt32(this.OthersCombo.SelectedValue);
            int commonVactionId = Convert.ToInt32(this.CommonCombo.SelectedValue);
            if ((otherVacationId >= 0 && commonVactionId < 0) || (commonVactionId >= 0 && otherVacationId < 0))
            {
                if (otherVacationId >= 0)
                {
                    vacationId = Convert.ToInt32(this.OthersCombo.SelectedValue);
                    vacationName = this.OthersCombo.Text.ToString();
                }
                else
                {
                    vacationId = Convert.ToInt32(this.CommonCombo.SelectedValue);
                    vacationName = this.CommonCombo.Text.ToString();
                }

                double startCounter;
                double endCounter;
                string startDate = PickerforStart.Value.Date.ToShortDateString();
                string endDate = PickerforEnd.Value.Date.ToShortDateString();
                DateTime start = Convert.ToDateTime((startDate + " " + StartTimeCombo.Text).ToString());
                DateTime end = Convert.ToDateTime((endDate + " " + EndTimeCombo.Text).ToString());
                if (StartTimeCombo.SelectedIndex == 0)
                {
                    startCounter = 0;
                }
                else
                {
                    startCounter = -0.5;
                }

                if (EndTimeCombo.SelectedIndex == 0)
                {
                    endCounter = 0.5;
                }
                else
                {
                    endCounter = 1;
                }
                Single day = Convert.ToSingle(endCounter + startCounter);// LeaveDetails.Duration
                TimeSpan duration = end.Date.Subtract(start.Date);
                Single span = 0;
                Single totalday = day + Convert.ToSingle(duration.TotalDays);
                Single inputDuration = Convert.ToSingle(numericUpDownDuration.Value);
                Single testForAnnualLeaveRemainDay = annualLeaveRemainDay;
                Single testForSickLeaveRemainDay = sickLeaveRemainDay;
                if (totalday > 0 || inputDuration != 0)
                {
                    switch (vacationId)
                    {
                        case 1:
                            if (inputDuration == 0)
                            {
                                testForAnnualLeaveRemainDay = annualLeaveRemainDay - totalday;
                                span = totalday;
                            }
                            else
                            {
                                testForAnnualLeaveRemainDay = annualLeaveRemainDay - inputDuration;
                                span = inputDuration;
                            }
                            break;
                        case 2:
                            if (inputDuration == 0)
                            {
                                testForSickLeaveRemainDay = sickLeaveRemainDay - totalday;
                                span = totalday;
                            }
                            else
                            {
                                testForSickLeaveRemainDay = sickLeaveRemainDay - inputDuration;
                                span = inputDuration;
                            }
                            break;
                        case 3:
                            if (inputDuration == 0)
                            {
                                span = totalday;
                            }
                            else
                            {
                                span = inputDuration;
                            }
                            showStaffInfo.Married = true;
                            StaffService staffService = new StaffService();
                            staffService.UpdateStaffInfor(showStaffInfo);
                            break;
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                        default:
                            if (inputDuration == 0)
                            {
                                span = totalday;
                            }
                            else
                            {
                                span = inputDuration;
                            }
                            break;
                    }
                    if (testForAnnualLeaveRemainDay < -5 || testForSickLeaveRemainDay < 0)
                    {
                        MessageBox.Show("The vacation exceeds its limit", "Warning");
                    }
                    else
                    {
                        annualLeaveRemainDay = testForAnnualLeaveRemainDay;
                        sickLeaveRemainDay = testForSickLeaveRemainDay;
                        LeaveType vacation = new LeaveType { LeaveTypeId = vacationId, LeaveTypeName = vacationName };
                        LeaveDetails newDetail = new LeaveDetails
                        {
                            StaffId = showStaffInfo.StaffId,
                            LeaveTypeId = vacationId,
                            StartDate = start,
                            EndDate = end,
                            Duration = span,
                            Remark = textBoxRemark.Text.ToString(),
                            Leavings = vacation,
                        };
                        LeaveDetailsService detailService = new LeaveDetailsService();
                        detailService.AddNewDetails(newDetail);
                        RequestHistory.DataSource = null;
                        allDetails.Clear();
                        detailsBindingList.Clear();

                        AssignDatatoList();
                        AddLeavingsAttributetoList(allDetails);
                        BindVactionDetails();
                        nCurrent = 0;
                        pageCurrent = 0;
                        InitPagingList();
                    }
                }
                else
                {
                    MessageBox.Show("Please adjust the interval to fit with the requirement", "Error");
                }
            }
            else
            {
                MessageBox.Show("Please select a vacation type", "Warning");
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the tabVacation control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void tabVacation_SelectedIndexChanged(object sender, EventArgs e)
        {
            CommonCombo.SelectedIndex = 0;
            OthersCombo.SelectedIndex = 0;
        }

        /// <summary>
        /// link to staff information setting function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SendEmail_Click(object sender, EventArgs e)
        {
            try
            {
                Outlook.Application oApp = new Outlook.Application();

                Outlook.MailItem oMsg = (Outlook.MailItem)oApp.CreateItem(Outlook.OlItemType.olMailItem);

                Outlook.Recipient oRecip = (Outlook.Recipient)oMsg.Recipients.Add(showStaffInfo.Email);
                oRecip.Resolve();

                oMsg.Subject = "annual leave remind";
                oMsg.HTMLBody = "Dear " + showStaffInfo.StaffName + ",<br/><br/>" +
                " We kindly remind you that Your last year’s  Annual Leave still have " + showStaffInfo.LastyearRemains + " days left. It will be cleared  on  April 1st . <br/><br/>" +
                "Best Regards<br/><br/>" +
                "_____________________________________________<br/>" +
                "Allen Wang<br/><br/>" +
                "VOLVO Information Technology (TianJian)Co.,Ltd<br/>" +
                "Telephone: +86-22-84808128<br/>" +
                "Telefax:    +86-22-84808480<br/>" +
                "E-mail: allen.wang@consultant.volvo.com<br/>";

                oMsg.Display(true);

                oRecip = null;
                oMsg = null;
                oApp = null;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error!" + ex);
            }
        }

        /// <summary>
        /// Handles the Click event of the btnExport control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            printAll();

        }

        /// <summary>
        /// Prints all.
        /// </summary>
        /// <param name="dt">The dt.</param>
        public void printAll()
        {
            if (showStaffInfo.StaffId != 0)
            {
                try
                {
                    string saveFileName = "";
                    SaveFileDialog saveDialog = new SaveFileDialog();
                    saveDialog.DefaultExt = "xlsx";
                    saveDialog.FileName = showStaffInfo.EmployeeId + "(" + showStaffInfo.StaffName + ")" + " Vacation Details" + DateTime.Today.ToString("yyyy-MM-dd");
                    saveDialog.ShowDialog();
                    saveFileName = saveDialog.FileName;
                    if (saveFileName.IndexOf(":") < 0)
                    {
                        return;
                    }

                    LeaveDetailsService leaveDetailsService = new LeaveDetailsService();

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
                    mySheet.Name = "Vacation Details";

                    for (int i = 1; i <= 5; i++)
                    {
                        mySheet.Columns[i].ColumnWidth = 20;
                        mySheet.Columns[i].HorizontalAlignment = Excel.Constants.xlCenter;
                        mySheet.Columns[i].VerticalAlignment = Excel.Constants.xlCenter;
                    }

                    mySheet.Range[mySheet.Cells[1, 1], mySheet.Cells[2, 5]].MergeCells = true;
                    mySheet.Range[mySheet.Cells[3, 4], mySheet.Cells[3, 5]].MergeCells = true;
                    mySheet.Range[mySheet.Cells[4, 4], mySheet.Cells[4, 5]].MergeCells = true;
                    mySheet.Cells[1, 1] = showStaffInfo.StaffName + "'s Vacation Details";
                    mySheet.Cells[1, 1].Font.Size = 18;

                    mySheet.Cells[3, 1] = "EmployeeID:";
                    mySheet.Cells[3, 2] = showStaffInfo.EmployeeId;
                    mySheet.Cells[3, 3] = "Staff Name:";
                    mySheet.Cells[3, 4] = showStaffInfo.StaffName + "(" + showStaffInfo.ChineseName + ")";

                    mySheet.Cells[4, 1] = "Onboard Date:";
                    mySheet.Cells[4, 2] = showStaffInfo.OnboardDate;
                    mySheet.Cells[4, 3] = "Title:";
                    mySheet.Cells[4, 4] = showStaffInfo.Title;

                    int row = 5;
                    for (int i = yearNow; i >= showStaffInfo.OnboardDate.Year; i--)
                    {
                        Excel.Range range = mySheet.Range[mySheet.Cells[row, 1], mySheet.Cells[row + 1, 5]];
                        range.MergeCells = true;
                        mySheet.Cells[row, 1] = "Detailed records in " + i;
                        mySheet.Cells[row, 1].Font.Size = 16;


                        row = row + 2;

                        mySheet.Cells[row, 1] = "Leaving Type";
                        mySheet.Cells[row, 2] = "Start Date";
                        mySheet.Cells[row, 3] = "End Date";
                        mySheet.Cells[row, 4] = "Days Taken";
                        mySheet.Cells[row, 5] = "Remark";

                        DateTime startDate = Convert.ToDateTime(i + "-1-1");
                        DateTime endDate = Convert.ToDateTime(i + 1 + "-1-1");
                        LeaveDetails ld = new LeaveDetails
                        {
                            StaffId = CurrentStaffId,
                            StartDate = startDate,
                            EndDate = endDate
                        };

                        OneYearDetails = leaveDetailsService.ObtainLeaveDetailsByStaffId(ld);
                        AddLeavingsAttributetoList(OneYearDetails);

                        for (int j = 0; j < OneYearDetails.Count; j++)
                        {
                            int ID = OneYearDetails.ElementAt(j).LeaveTypeId;
                            Single dur = OneYearDetails.ElementAt(j).Duration;
                            DateTime startdate = OneYearDetails.ElementAt(j).StartDate;
                            DateTime enddate = OneYearDetails.ElementAt(j).EndDate;
                            string remarks = OneYearDetails.ElementAt(j).Remark;
                            string name = OneYearDetails.ElementAt(j).Leavings.LeaveTypeName;

                            row += 1;
                            mySheet.Cells[row, 1] = name;
                            mySheet.Cells[row, 2] = startdate;
                            mySheet.Cells[row, 3] = enddate;
                            mySheet.Cells[row, 4] = dur;
                            mySheet.Cells[row, 5] = remarks;
                        }
                        row += 1;

                    }

                    myBook.SaveCopyAs(saveFileName);
                    myBook.Close(false, Type.Missing, Type.Missing);

                    myExcel.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(myBook);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(myExcel);
                    mySheet = null;
                    myBook = null;
                    myExcel = null;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error" + ex);
                }
                finally
                {
                    GC.Collect();
                }
            }
            else
            {
                MessageBox.Show("StaffId error!");
            }

        }

        /// <summary>
        /// Handles the ValueChanged event of the PickerforStart control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void PickerforStart_ValueChanged(object sender, EventArgs e)
        {
            PickerforEnd.Value = PickerforStart.Value;
        }

        /// <summary>
        /// Handles the ValueChanged event of the NUPRows control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void NUPRows_ValueChanged(object sender, EventArgs e)
        {
            pageSize = Convert.ToInt32(NUPRows.Value);
            AssignDatatoList();
            AddLeavingsAttributetoList(allDetails);
            BindVactionDetails();
            nCurrent = 0;
            pageCurrent = 0;
            detailsBindingList.Clear();
            InitPagingList();
        }

        /// <summary>
        /// Handles the Leave event of the NUPRows control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void NUPRows_Leave(object sender, EventArgs e)
        {
            pageSize = Convert.ToInt32(NUPRows.Value);
            AssignDatatoList();
            AddLeavingsAttributetoList(allDetails);
            BindVactionDetails();
            nCurrent = 0;
            pageCurrent = 0;
            detailsBindingList.Clear();
            InitPagingList();
        }

        /// <summary>
        /// Handles the Click event of the btnCopy control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("1");
            Clipboard.Clear();
            Clipboard.SetText("Staff ID:" + showStaffInfo.EmployeeId + "   Staff Name:" + showStaffInfo.StaffName + "   Onboard Date:" + showStaffInfo.OnboardDate + "\r\n \r\n" +
                "Total Annual Leave:" + lblTA.Text.ToString() + "   Used Annual Leave:" + lblUA.Text.ToString() + "   Annual Leave Balance:" + lblAB.Text.ToString() + "\r\n \r\n" +
                "Total Sick Leave:" + lblTS.Text.ToString() + "   Used Sick Leave:" + lblUS.Text.ToString() + "   Sick Leave Balance:" + lblSB.Text.ToString() + "\r\n ");
        }

    }
}
