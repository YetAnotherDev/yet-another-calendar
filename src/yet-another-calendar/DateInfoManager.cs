using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace YetAnotherDeveloper.YetAnotherCalendar
{
    public static class DateInfoManager
    {
        internal static List<Date> _dates;

        public static void Initilize(string filePath) 
        {
            _dates = new List<Date>();
            XmlTextReader reader = new XmlTextReader(filePath);           
            int readerDepth = 0;
            string dateMonth = string.Empty;
            string dateDay = string.Empty;
            string dateType = string.Empty;
            string dateName = string.Empty;
            string groupName = string.Empty;
            string weekOfMonth = string.Empty;
            string dayOfWeek = string.Empty;

            while (reader.Read())
            {

                if (reader.Name.ToLower() == "date")
                {

                    readerDepth = reader.Depth;
                    reader.Read(); // go one mroe deep.

                    while (reader.Depth != readerDepth)
                    {
                        
                        switch (reader.Name.ToLower())
                        {
                            case "month":
                                dateMonth = reader.ReadElementContentAsString();
                                break;
                            case "day":
                                dateDay = reader.ReadElementContentAsString();
                                break;
                            case "name":
                                dateName = reader.ReadElementContentAsString();
                                break;
                            case "groupname":
                                groupName = reader.ReadElementContentAsString();
                                break;
                            case "type":
                                dateType = reader.ReadElementContentAsString();
                                break;
                            case "weekofmonth":
                                weekOfMonth = reader.ReadElementContentAsString();
                                break;
                            case "dayofweek":
                                dayOfWeek = reader.ReadElementContentAsString();
                                break;
                        }



                        reader.Read();
                    }
                    if (dateType.ToLower() == "fixed")
                    {
                        Date myDate = new Date((Month)Enum.Parse(typeof(Month), dateMonth), int.Parse(dateDay),
                                               dateName, groupName);
                        _dates.Add(myDate);
                    }
                    else
                    {
                        Date myDate = new Date((Week)Enum.Parse(typeof(Week), weekOfMonth),
                                               (DayOfWeek)Enum.Parse(typeof(DayOfWeek), dayOfWeek),
                                               (Month)Enum.Parse(typeof(Month), dateMonth),
                                               dateName, groupName);

                        _dates.Add(myDate);




                    }

                    groupName = string.Empty;

                }
            } 

        }

        public static void Initilize(List<Date> dates)
        {
            _dates = dates;
        }

        public static DateInfo GetDateInfo(DateTime date)
        {

            return new DateInfo(date);
        }

        internal static DayOfWeek DayOfWeek(DateTime date)
        {
            int a = (14 - date.Month) / 12;
            int y = date.Year - a;
            int m = date.Month + 12 * a - 2;
            int d = (date.Day + y + y / 4 - y / 100 + y / 400 + (31 * m) / 12);
            //  d = (day      + y + y/4 - y/100 + y/400 + (31*m)/12) % 7
            if (d < 0)
            {
                d = (7 + d) % 7;

            }
            else
            {
                d = d % 7;
            }

            return (DayOfWeek)d;
        }

        //http://www.smart.net/~mmontes/ushols.html#ALG
        internal static DateTime NthDayOfTheMonth(Week week, DayOfWeek weekDay, int year, Month month)
        {

            // 7*Q - 6 + (N - DoW(Year,Month,1))%7
            int x;

            switch (week)
            {
                case Week.Last:
                    //NL = ND - (DoW(Year,Month,ND) - N)%7
                    int nd = DateTime.DaysInMonth(year, (int)month);
                    int dow = (int)DayOfWeek(new DateTime(year, (int)month, nd));
                    int wd = (int)weekDay;
                    int dowwd = dow - wd;
                    int mod = dowwd % 7;
                    if (dowwd < 0)
                    {
                        mod = 7 + dowwd;
                    }

                    x = (nd) - (mod);
                    break;
                default:
                    int q = (int)week + 1;
                    //x = 7 * (int)week - 6 + (weekDay - DayOfWeek(new DateTime(year, (int)month, 1)));
                    x = (7 * q - 6) + (weekDay - DayOfWeek(new DateTime(year, (int)month, 1)));
                    break;
            }

            if (x > DateTime.DaysInMonth(year, (int)month))
            {
                throw new ArgumentOutOfRangeException(string.Format("There is no {0} {1} in {2}.", week, weekDay, month));
            }

            return new DateTime(year, (int)month, x);
        }

        internal static Week WeekOfMonth(DateTime date)
        {

            //Sunday is the first day of the week damnit.
            int firstSunday = 0;
            int secondSunday = 0;
            int thirdSunday = 0;
            int fourthSunday = 0;
            int fifthSunday = 0;
            Week result = Week.First;

            int dow = (int)DayOfWeek(new DateTime(date.Year, date.Month, 1));
            
            // NQ = 7*Q - 6 + (N - DoW(Year,Month,1))%7

            firstSunday = 7 * 2 - 6 + (0 - dow);
            secondSunday = 7 * 3 - 6 + (0 - dow);
            thirdSunday = 7 * 4 - 6 + (0 - dow);
            fourthSunday = 7 * 5 - 6 + (0 - dow);
            fifthSunday = 7 * 6 - 6 + (0 - dow);

            
            if(date.Day >= firstSunday && date.Day < secondSunday )
            {
                result = Week.First;
            }
            else if (date.Day >= secondSunday && date.Day < thirdSunday)
            {
                result = Week.Second;
            }
            else if(date.Day >= thirdSunday && date.Day < fourthSunday)
            {
                result = Week.Third;
            }
            else if (date.Day >= fourthSunday && date.Day < fifthSunday)
            {
                result = Week.Fourth;
            } 
            else if(date.Day >= fifthSunday)
            {
                result = Week.Fifth;
            }


            if (firstSunday > 1)
            {
                int alterResult = 1 + (int)result;
                result = (Week)alterResult;
            }

            return result;
        }

        internal static bool IsMatchingDate(DateTime date)
        {
            return IsMatchingDate(date, string.Empty);
        }

        internal static bool IsMatchingDate(DateTime date, string groupName)
        {
            bool isDate = false;

            foreach (Date dateItem in _dates)
            {
                DateTime result;
                if (dateItem.GroupName.ToLower() == groupName.ToLower())
                {
                    if (dateItem.Type == DateType.Variable)
                    {

                        result = NthDayOfTheMonth(dateItem.Week, dateItem.WeekDayOfWeek, date.Year, dateItem.Month);
                    }
                    else
                    {
                        result = new DateTime(date.Year, (int) dateItem.Month, dateItem.Day);
                    }

                    if (result.Date == date.Date)
                    {
                        isDate = true;
                        break;
                    }
                }
            }
            return isDate;
        }
    }
}
