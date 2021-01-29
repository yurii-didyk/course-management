using CourseManagement.Domain.Abstractions;
using CourseManagement.Domain.Exceptions;
using CourseManagement.Domain.Exceptions.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CourseManagement.Domain.Entities
{
    public class Course: BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }

        public void SetTime(DateTime startTime, DateTime endTime)
        {
            var isStartTimeBeforeEndTime = startTime <= endTime;
            var isWeekDayCorrect = AllowedDaysOfWeek.Contains(startTime.DayOfWeek) && AllowedDaysOfWeek.Contains(endTime.DayOfWeek);
            var isTimeCorrect = IsWorkTime(startTime) && IsWorkTime(endTime);

            if (isStartTimeBeforeEndTime && isWeekDayCorrect && isTimeCorrect)
            {
                StartTime = startTime;
                EndTime = endTime;

                return;
            }

            throw GetException(isWeekDayCorrect, isTimeCorrect);
        }

        [NotMapped]
        private static List<DayOfWeek> AllowedDaysOfWeek = new List<DayOfWeek>() 
        {   DayOfWeek.Monday,
            DayOfWeek.Tuesday,
            DayOfWeek.Wednesday,
            DayOfWeek.Thursday,
            DayOfWeek.Friday 
        };

        private static bool IsWorkTime(DateTime dt) => dt.Hour >= 9 && dt.Hour <= 17; 

        private static Exception GetException(bool isWeekDayCorrect, bool isTimeCorrect)
        {
            var reason = ValidationFailed.FinishedEarlierThanStarted;

            if (!isWeekDayCorrect)
            {
                reason = ValidationFailed.DayOfWeek;
            }
            else if (!isTimeCorrect)
            {
                reason = ValidationFailed.Time;
            }

            return new CourseValidationException(reason);
        }
    }
}
