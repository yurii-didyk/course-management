using System;
using System.Collections.Generic;
using System.Text;

namespace CourseManagement.Domain.Helpers
{
    public static class DateHelper
    {
        public static List<DayOfWeek> AllowedDaysOfWeek = new List<DayOfWeek>()
        {   DayOfWeek.Monday,
            DayOfWeek.Tuesday,
            DayOfWeek.Wednesday,
            DayOfWeek.Thursday,
            DayOfWeek.Friday
        };

        public static bool IsWorkTime(DateTime dt) => dt.Hour >= 9 && dt.Hour <= 17;
    }
}
