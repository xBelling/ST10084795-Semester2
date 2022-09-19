using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace POE_PartOne_ST10084795_ClassLibrary
{
    public class SemesterAndModule
    {
        //Semester Variables - getter and setter
        public string semWeeks { get; set; }
        public string semStart { get; set; }

        //Module Varibales - getter and setter
        public string modCode { get; set; }
        public string modName { get; set; }
        public string modCredits { get; set; }
        public string modWeekClassHrs { get; set; }
        public int hrsReqCurrentWeek { get; set; }
        public string hrsFinDate { get; set; }
        public string hrsFinCurrentWeek { get; set; }
        public int hrsRemCurrentWeek { get; set; }
        public int currentWeek { get; set; }

        public List<string> hrsRemList = new List<string>();

        public void WeeklySSHrsCalc(double modCredits, double semWeeks, double modWeekClassHrs)
        {
            hrsReqCurrentWeek = (int)Math.Round(((double)(modCredits) * 10 / semWeeks) - modWeekClassHrs, MidpointRounding.AwayFromZero);
        }

        public void RemainingSSHrsCalc(int hrsReqCurrentWeek, double hrsFinCurrentWeek)
        {
            hrsRemCurrentWeek = (int)Math.Round(hrsReqCurrentWeek - hrsFinCurrentWeek, MidpointRounding.AwayFromZero);
        }

        public void CurrentWeekCalc(DateTime semStart, DateTime hrsFinDate)
        {
            currentWeek = (int)Math.Ceiling(((hrsFinDate - semStart).TotalDays + 1) / 7);
        }
    }
}
