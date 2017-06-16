using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DataModel;
using BLL;
using System.Reflection;

namespace LeavingManagementSystem
{
    public class GetStaffDetails
    {
        #region
        private static DateTime currentDate = DateTime.Now.Date;
        private static int yearNow = currentDate.Year;
        private static int MonthNow = currentDate.Month;

        private DateTime janOneLastYear = Convert.ToDateTime(yearNow - 1 + "-1-1");
        private DateTime janOneYear = Convert.ToDateTime(yearNow + "-1-1");
        private DateTime janOneYearAfter = Convert.ToDateTime(yearNow + 1 + "-1-1");
        private DateTime MarOneYear = Convert.ToDateTime(yearNow + "-4-1");

        Staff staff = new Staff();//store staff information
        List<LeaveDetails> allDetails = new List<LeaveDetails>();

        Single sickLeaveCounter = 0;
        Single lastyearUSL = 0;//last year used sick leave
        Single nopayLeaveCounter = 0;
        Single marriageLeaveCounter = 0;
        Single maternityCounter = 0;
        Single paternityCounter = 0;
        Single compassionateCounter = 0;
        Single othersCounter = 0;

        Single thisyearSickLeave = 0;

        Single sickLeaveRemainDay = 0;
        Single annualLeaveRemainDay = 0;

        Single thisyearAL = 0;//this year's total annual leave
        Single thisyearUAL = 0;
        Single thisyearUALF = 0;
        Single thisyearUALS = 0;
        Single lastyearAL = 0;

        int WorkYear = 0;//社会工龄
        int intervalYear = 0;//this year - join year
        int intervalMonth = 0;//this Month - join Month
        int intervalDay = 0;//this day - join day

        Single constantofSickLeave = 0;
        Single constantofAnnualLeave = 0;
        Single constantofFiveAnnualLeave = 0;
        #endregion

        /// <summary>
        /// Gets the staff detail.
        /// </summary>
        /// <param name="staffId">The staff id.</param>
        /// <returns></returns>
        public StaffDetails GetStaffDetail(Staff staffinfo)
        {
            StaffDetails staffDetails = new StaffDetails();
            staffDetails.StaffId = staffinfo.StaffId;

            staff = staffinfo;

            allDetails = GetVacationDetails(staff.StaffId);

            Single lastyearRemain = staff.LastyearRemains;

            CountThisYearLeave();

            if (MonthNow < 4)
            {
                thisyearUAL = thisyearUALF + thisyearUALS;
                staffDetails.usedAnnualLeave = thisyearUAL.ToString();
                if (lastyearRemain >= 0)
                {
                    staffDetails.totalAnnualLeave = thisyearAL.ToString() + "+" + lastyearRemain.ToString();
                }
                else
                {
                    staffDetails.totalAnnualLeave = thisyearAL.ToString() + lastyearRemain.ToString();
                }
                annualLeaveRemainDay = thisyearAL - thisyearUAL + lastyearRemain;
            }
            else
            {
                thisyearUALF = lastyearRemain - thisyearUALF;
                staffDetails.totalAnnualLeave = thisyearAL.ToString();
                if (thisyearUALF < 0)
                {
                    thisyearUAL = thisyearUALS - thisyearUALF;
                }
                else
                {
                    if (staff.OnboardDate <= Convert.ToDateTime(yearNow - 1 + "-1-15") && (lastyearAL - thisyearUALF) < 5)//last two year used 
                    {
                        WorkYear = currentDate.Year - staff.StartWork.Year;
                        if (WorkYear >= 20)//社会工龄20年及以上法定年假15天，可延至12月底
                        {
                            staffDetails.totalAnnualLeave = thisyearAL.ToString() + "+" + Convert.ToSingle(15 - lastyearAL + thisyearUALF);
                            thisyearAL = thisyearAL + 15 - lastyearAL + thisyearUALF;
                        }
                        else if (WorkYear >= 10)
                        {
                            staffDetails.totalAnnualLeave = thisyearAL.ToString() + "+" + Convert.ToSingle(10 - lastyearAL + thisyearUALF);
                            thisyearAL = thisyearAL + 10 - lastyearAL + thisyearUALF;
                        }
                        else
                        {
                            staffDetails.totalAnnualLeave = thisyearAL.ToString() + "+" + Convert.ToSingle(5 - lastyearAL + thisyearUALF);
                            thisyearAL = thisyearAL + 5 - lastyearAL + thisyearUALF;
                        }

                    }
                    else
                    {
                        staffDetails.totalAnnualLeave = thisyearAL.ToString();
                        thisyearUAL = thisyearUALS;
                    }
                }
                staffDetails.usedAnnualLeave = thisyearUAL.ToString();
                annualLeaveRemainDay = thisyearAL - thisyearUAL;

            }

            staffDetails.annualLeaveBalance = annualLeaveRemainDay.ToString();//annual leave balance

            staffDetails.totalSickLeave = thisyearSickLeave.ToString();//Total sick leave 1 year
            staffDetails.usedSickLeave = sickLeaveCounter.ToString();//Used sick leave 1 year
            staffDetails.lastyearUsedSickLeave = lastyearUSL.ToString();//last year Used sick leave 1 year
            sickLeaveRemainDay = thisyearSickLeave - sickLeaveCounter;//sick leave balance 1 year
            staffDetails.sickLeaveBalance = sickLeaveRemainDay.ToString();//sick leave balance 1 year
            staffDetails.usednopayLeave = nopayLeaveCounter.ToString();//Used nopay leave 1 year
            staffDetails.usedmarriageLeave = marriageLeaveCounter.ToString();//all
            staffDetails.usedmaternity = maternityCounter.ToString();//all
            staffDetails.usedpaternity = paternityCounter.ToString();//all
            staffDetails.usedcompassionate = compassionateCounter.ToString();//all
            staffDetails.usedothers = othersCounter.ToString();//all

            return staffDetails;
        }

        /// <summary>
        /// Counts the this year leave.
        /// </summary>
        private void CountThisYearLeave()
        {
            SystemConstantService constantService = new SystemConstantService();
            List<DataModel.SystemConstant> constantList = new List<DataModel.SystemConstant>();
            constantList = constantService.GetSystemConstant();

            intervalYear = currentDate.Year - staff.OnboardDate.Year;
            intervalMonth = currentDate.Month - staff.OnboardDate.Month;
            intervalDay = currentDate.Day - staff.OnboardDate.Day;

            constantofSickLeave = Convert.ToSingle(constantList.ElementAt(2).ConstantValue);
            constantofAnnualLeave = Convert.ToSingle(constantList.ElementAt(0).ConstantValue);
            constantofFiveAnnualLeave = Convert.ToSingle(constantList.ElementAt(1).ConstantValue);

            thisyearSickLeave = constantofSickLeave;

            int joinMonth = 0;

            if (staff.OnboardDate.Day <= 15)
            {
                joinMonth = 1;
            }
            if (intervalYear == 0)
            {
                thisyearAL = (intervalMonth + joinMonth) * constantofAnnualLeave / 12;
                thisyearSickLeave = (intervalMonth + joinMonth) * constantofSickLeave / 12;
            }
            else if (intervalYear == 1)
            {
                if (intervalMonth >= 0)
                {
                    thisyearAL = constantofAnnualLeave;
                }
                else
                {
                    thisyearAL = currentDate.Month * constantofAnnualLeave / 12;
                }
                lastyearAL = (12 - staff.OnboardDate.Month + joinMonth) * constantofAnnualLeave / 12;
            }
            else if (intervalYear > 1 && intervalYear < 5)
            {
                thisyearAL = constantofAnnualLeave;
                lastyearAL = constantofAnnualLeave;
            }
            else if (intervalYear == 5)
            {
                lastyearAL = constantofAnnualLeave;
                if ((intervalMonth - joinMonth) >= 0)
                {
                    thisyearAL = constantofAnnualLeave + (12 - staff.OnboardDate.Month + joinMonth) * (constantofFiveAnnualLeave - constantofAnnualLeave) / 12;
                }
                else
                {
                    thisyearAL = constantofAnnualLeave;
                }
            }
            else if (intervalYear == 6)
            {
                thisyearAL = constantofFiveAnnualLeave;
                lastyearAL = constantofAnnualLeave + (12 - staff.OnboardDate.Month + joinMonth) * (constantofFiveAnnualLeave - constantofAnnualLeave) / 12;
            }
            else if (intervalYear > 6)
            {
                thisyearAL = constantofFiveAnnualLeave;
                lastyearAL = constantofFiveAnnualLeave;
            }
        }

        /// <summary>
        /// Gets the vocatin details.
        /// </summary>
        /// <param name="staffId">The staff id.</param>
        public List<LeaveDetails> GetVacationDetails(int staffId)
        {
            int yearNow = currentDate.Year;
            DateTime startDate = Convert.ToDateTime("1990-1-1");
            DateTime endDate = Convert.ToDateTime(yearNow + 1 + "-12-31");
            LeaveDetailsService detailService = new LeaveDetailsService();
            LeaveDetails ld = new LeaveDetails
            {
                StaffId = staffId,
                StartDate = startDate,
                EndDate = endDate
            };

            allDetails = detailService.ObtainLeaveDetailsByStaffId(ld);

            thisyearUALF = 0;
            thisyearUALS = 0;
            sickLeaveCounter = 0;
            nopayLeaveCounter = 0;
            marriageLeaveCounter = 0;
            maternityCounter = 0;
            compassionateCounter = 0;
            paternityCounter = 0;
            othersCounter = 0;

            for (int i = 0; i < allDetails.Count; i++)
            {
                int ID = allDetails.ElementAt(i).LeaveTypeId;
                Single dur = allDetails.ElementAt(i).Duration;
                DateTime startdate = allDetails.ElementAt(i).StartDate;
                switch (ID)
                {
                    case 1:
                        if (startdate >= janOneYear && startdate < MarOneYear)
                        {
                            thisyearUALF += dur;
                        }
                        else if (startdate >= MarOneYear && startdate < janOneYearAfter)
                        {
                            thisyearUALS += dur;
                        }
                        break;
                    case 2:
                        if (startdate >= janOneYear && startdate < janOneYearAfter)
                        {
                            sickLeaveCounter += dur;
                        }
                        else if (startdate >= janOneLastYear && startdate < janOneYear)
                        {
                            lastyearUSL += dur;
                        }
                        break;
                    case 3:
                        if (startdate >= janOneYear && startdate < janOneYearAfter)
                        {
                            nopayLeaveCounter += dur;
                        }
                        break;
                    case 4:
                        marriageLeaveCounter += dur;
                        break;
                    case 5:
                        maternityCounter += dur;
                        break;
                    case 6:
                        compassionateCounter += dur;
                        break;
                    case 7:
                        paternityCounter += dur;
                        break;
                    case 8:
                        othersCounter += dur;
                        break;
                    default:
                        break;
                }
            }
            return allDetails;
        }

        /// <summary>
        /// Getstaffs the specified staff id.
        /// </summary>
        /// <param name="staffId">The staff id.</param>
        public Staff Getstaff(int staffId)
        {
            StaffRepository staffRep = new StaffRepository();
            Staff staffInfo = new Staff { StaffId = staffId };
            staff = staffRep.GetStaffByStaffId(staffInfo);
            return staff;
        }
    }
}
