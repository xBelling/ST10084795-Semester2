namespace POE_ST10084795.Models
{
    public class SemesterAndModule
    {
        public int ID { get; set; }
        public DateTime SemesterStartDate { get; set; }
        public int SemesterWeeks { get; set; }
        public string ModuleCode { get; set; }
        public string ModuleName { get; set; }
        public int ModuleCredits { get; set; }
        public int ModuleClassHrs { get; set; }
        public int ReqSelfStudyHrs
        {
            get
            {
                return (int)Math.Round(((double)(ModuleCredits) * 10 / SemesterWeeks) - ModuleClassHrs, MidpointRounding.AwayFromZero); ;
            }
        }
        public DateTime SelfStudyDate { get; set; }
        public int SelfStudyHrs { get; set; }
        public int RemSelfStudyHrs
        {
            get
            {
                return (int)Math.Round((double)ReqSelfStudyHrs - SelfStudyHrs, MidpointRounding.AwayFromZero);
            }
        }
        public int WeekOfSemester
        {
            get
            {
                return (int)Math.Ceiling(((SelfStudyDate - SemesterStartDate).TotalDays + 1) / 7);
            }
        }
    }
}
