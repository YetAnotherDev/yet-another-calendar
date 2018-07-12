using System;

namespace YetAnotherDeveloper.YetAnotherCalendar
{
    public class DateInfo
    {

        private DateTime Date { get; set; }

        private DateInfo(){ }

        public DateInfo(DateTime date)
        {
            Date = date;
        }

        public DayOfWeek DayOfWeek
        {
            get
            {
                return DateInfoManager.DayOfWeek(Date);
            }
            private set { }
        }

        public int DayOfYear
        {
            get
            {
                return Date.DayOfYear;
            }
            private set { }
        }

        public Week WeekOfMonth
        {
            get
            {
                return DateInfoManager.WeekOfMonth(Date);                
            }
        }

        public bool IsWeekday
        {
            get { if(this.DayOfWeek == YetAnotherCalendar.DayOfWeek.Saturday ||
                     this.DayOfWeek == YetAnotherCalendar.DayOfWeek.Sunday)
            {
                return false; 
            }
                return true;
            }
        }

        public bool IsWeekend
        {
            get
            {
                return !IsWeekday;
            }
        }

        public bool IsMatchingDate()
        {
            return DateInfoManager.IsMatchingDate(this.Date);
        }

        public bool IsMatchingDate(string groupName)
        {
            return DateInfoManager.IsMatchingDate(this.Date, groupName);
        }
    }
}