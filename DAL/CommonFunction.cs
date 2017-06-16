using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModel;

namespace DAL
{
    public class CommonFunction
    {
        #region private field
        private static DateTime currentDate = DateTime.Now.Date;
        private static int yearNow = currentDate.Year;
        private static int MonthNow = currentDate.Month;

        private static DateTime janOneYearBefore = Convert.ToDateTime(yearNow - 1 + "-1-1");
        private static DateTime MarOneYearBefore = Convert.ToDateTime(yearNow - 1 + "-4-1");
        private static DateTime janOneYear = Convert.ToDateTime(yearNow + "-1-1");

        protected Single lastyearAL = 0;
        protected Single lastyearUALF = 0;
        protected Single lastyearUALS = 0;
        protected Single lastyearUAL = 0;
        protected Single lastyearALRemain = 0;
        protected Single lastTwoYearAL = 0;

        protected List<LeaveDetails> allDetails = new List<LeaveDetails>();

        protected string year = "";
        protected string lastyear = (Convert.ToInt32(currentDate.Year) - 1).ToString();
        protected string theyearBeforeLast = (Convert.ToInt32(currentDate.Year) - 2).ToString();

        int intervalYear = 0;//thisyear - join year
        int intervalMonth = 0;//thisMonth - join Month
        int intervalDay = 0;//thisday - join day

        Single constantofSickLeave = 0;
        Single constantofAnnualLeave = 0;
        Single constantofFiveAnnualLeave = 0;

        #endregion

        /// <summary>
        /// Changes the lastyear remain.
        /// </summary>
        /// <param name="staff">The staff.</param>
        /// <returns></returns>
        public Staff ChangeLastyearRemain(Staff staff)
        {
            Single sLastyearRemain = staff.LastyearRemains;
            Single lastyearRemain;

            if (sLastyearRemain.ToString().Length < 5)
            {
                sLastyearRemain = Convert.ToSingle(lastyear + "0");
                staff.LastyearRemains = sLastyearRemain;
                UpdateStaff(staff);
                lastyearRemain = 0;
            }
            else
            {
                if (sLastyearRemain < 0)
                {
                    if (sLastyearRemain.ToString().Length == 5)
                    {
                        sLastyearRemain = Convert.ToSingle(lastyear + "0");
                        staff.LastyearRemains = sLastyearRemain;
                        UpdateStaff(staff);
                        year = lastyear;
                        lastyearRemain = 0;
                    }
                    else
                    {
                        year = sLastyearRemain.ToString().Substring(1, 4);
                        lastyearRemain = Convert.ToSingle("-" + sLastyearRemain.ToString().Substring(5));
                    }
                }
                else
                {
                    year = sLastyearRemain.ToString().Substring(0, 4);
                    lastyearRemain = Convert.ToSingle(sLastyearRemain.ToString().Substring(4));
                }

                if (year == theyearBeforeLast)
                {
                    lastyearRemain = GetLastyearAnnualBalance(staff, lastyearRemain);
                }
                else if (year != lastyear)
                {
                    sLastyearRemain = Convert.ToSingle(lastyear + "0");
                    staff.LastyearRemains = sLastyearRemain;
                    UpdateStaff(staff);

                    lastyearRemain = 0;
                }
            }
            staff.LastyearRemains = lastyearRemain;
            return staff;
        }

        /// <summary>
        /// Gets the lastyear annual balance.
        /// </summary>
        /// <param name="staff">The staff.</param>
        /// <param name="lastyearRemain">The lastyear remain.</param>
        /// <returns></returns>
        public Single GetLastyearAnnualBalance(Staff staff, Single lastyearRemain)
        {
            DateTime startDate = Convert.ToDateTime(yearNow - 1 + "-1-1");
            DateTime endDate = Convert.ToDateTime(yearNow + 1 + "-1-1");

            Single sLastyearRemain = staff.LastyearRemains;

            LeaveDetails ld = new LeaveDetails
            {
                StaffId = staff.StaffId,
                StartDate = startDate,
                EndDate = endDate
            };

            LeaveDetailsRepository leaveDetailsRepository = new LeaveDetailsRepository();
            allDetails = leaveDetailsRepository.GetLeaveDetailsByStaffId(ld);

            for (int i = 0; i < allDetails.Count; i++)
            {
                int ID = allDetails.ElementAt(i).LeaveTypeId;
                Single dur = allDetails.ElementAt(i).Duration;
                DateTime startdate = allDetails.ElementAt(i).StartDate;
                if (ID == 1)
                {
                    if (startdate >= janOneYearBefore && startdate < MarOneYearBefore)
                    {
                        lastyearUALF += dur;
                    }
                    else if (startdate >= MarOneYearBefore && startdate < janOneYear)
                    {
                        lastyearUALS += dur;
                    }
                }
            }

            GetConstantValue();
            GetLastyearAnnual(staff);

            lastyearUALF = lastyearRemain - lastyearUALF;//last two year balance minus last year 1st section used
            if (lastyearUALF < 0)
            {
                lastyearUAL = lastyearUALS - lastyearUALF;
            }
            else
            {
                lastyearUAL = lastyearUALS;
                if (staff.OnboardDate <= Convert.ToDateTime(yearNow - 2 + "-1-15") && (lastTwoYearAL - lastyearUALF) < 5)//last two year used 
                {
                    lastyearUAL = lastyearUALS - 5 + lastTwoYearAL - lastyearUALF;
                }
            }

            if (lastyearUAL <= 0)
            {
                lastyearALRemain = lastyearAL;
            }
            else
            {
                lastyearALRemain = lastyearAL - lastyearUAL;
            }

            if (lastyearALRemain < 0)
            {
                sLastyearRemain = Convert.ToSingle("-" + lastyear + System.Math.Abs(lastyearALRemain));
            }
            else
            {
                sLastyearRemain = Convert.ToSingle(lastyear.ToString() + System.Math.Abs(lastyearALRemain).ToString());
            }

            staff.LastyearRemains = sLastyearRemain;
            UpdateStaff(staff);

            return lastyearALRemain;
        }

        /// <summary>
        /// Updates the staff.
        /// </summary>
        /// <param name="staff">The staff.</param>
        /// <returns></returns>
        public Response UpdateStaff(Staff staff)
        {
            StaffRepository staffRepository = new StaffRepository();
            Response response = staffRepository.UpdateStaff(staff);
            return response;
        }

        /// <summary>
        /// Gets the lastyear annual.
        /// </summary>
        /// <param name="staff">The staff.</param>
        /// <returns></returns>
        public void GetLastyearAnnual(Staff staff)
        {

            intervalYear = currentDate.Year - staff.OnboardDate.Year;
            intervalMonth = currentDate.Month - staff.OnboardDate.Month;
            intervalDay = currentDate.Day - staff.OnboardDate.Day;

            int joinMonth = 0;

            if (staff.OnboardDate.Day <= 15)//join day before 15 has one month annual leave
            {
                joinMonth = 1;
            }

            if (intervalYear == 1)
            {
                lastyearAL = (12 - staff.OnboardDate.Month + joinMonth) * constantofAnnualLeave / 12;

            }
            else if (intervalYear > 1 && intervalYear <= 5)
            {
                lastyearAL = constantofAnnualLeave;
            }
            else if (intervalYear == 6)
            {
                lastyearAL = constantofAnnualLeave + (12 - staff.OnboardDate.Month + joinMonth) * (constantofFiveAnnualLeave - constantofAnnualLeave) / 12;
            }
            else if (intervalYear > 6)
            {
                lastyearAL = constantofFiveAnnualLeave;
            }

            //last twoyear total annual leave
            if (intervalYear == 2)
            {
                lastTwoYearAL = (12 - staff.OnboardDate.Month + joinMonth) * constantofAnnualLeave / 12;

            }
            else if (intervalYear > 2 && intervalYear <= 6)
            {
                lastTwoYearAL = constantofAnnualLeave;
            }
            else if (intervalYear == 7)
            {
                lastTwoYearAL = constantofAnnualLeave + (12 - staff.OnboardDate.Month + joinMonth) * (constantofFiveAnnualLeave - constantofAnnualLeave) / 12;
            }
            else if (intervalYear > 7)
            {
                lastTwoYearAL = constantofFiveAnnualLeave;
            }
        }

        /// <summary>
        /// Gets the constant value.
        /// </summary>
        /// <param name="staff">The staff.</param>
        public void GetConstantValue()
        {
            List<DataModel.SystemConstant> constantList = new List<DataModel.SystemConstant>();
            SystemConstantRepository systemConstantRepository = new SystemConstantRepository();
            constantList = systemConstantRepository.GetAllSystemConstants();

            constantofAnnualLeave = Convert.ToSingle(constantList.ElementAt(0).ConstantValue);
            constantofFiveAnnualLeave = Convert.ToSingle(constantList.ElementAt(1).ConstantValue);
        }

    }
}
