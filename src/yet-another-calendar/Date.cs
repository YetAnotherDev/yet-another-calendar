namespace YetAnotherDeveloper.YetAnotherCalendar
{
    public class Date
    {
        public Date(Month month, int day) : this(month, day, string.Empty)
        {
        }

        public Date(Month month, int day, string name) : this(month, day, name, string.Empty)
        {
        }

        public Date(Month month, int day, string name, string groupName)
        {
            Month = month;
            Day = day;
            Name = name;
            Type = DateType.Fixed;
            GroupName = groupName;
        }

        public Date(Week week, DayOfWeek weekDay, Month month) : this(week, weekDay, month, string.Empty)
        {
        }

        public Date(Week week, DayOfWeek weekDay, Month month, string name) : this(week, weekDay, month, name,
            string.Empty)
        {
        }

        public Date(Week week, DayOfWeek weekDay, Month month, string name, string groupName)
        {
            Week = week;
            WeekDayOfWeek = weekDay;
            Month = month;
            Name = name;
            Type = DateType.Variable;
            GroupName = groupName;
        }


        public string Name { get; set; }
        public string GroupName { get; set; }
        public Week Week { get; set; }
        public int Day { get; set; }

        public DayOfWeek WeekDayOfWeek { get; set; }
        public Month Month { get; set; }
        internal DateType Type { get; set; }
    }
}