using CourseManagement.Domain.Abstractions;
using CourseManagement.Domain.Exceptions;
using CourseManagement.Domain.Exceptions.Enums;
using CourseManagement.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CourseManagement.Domain.Entities
{
    public class Course: BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public decimal Price { get; set; }
        [Required]
        public DateTime StartTime { get; private set; }
        [Required]
        public DateTime EndTime { get; private set; }

        public Course(string name, decimal price, DateTime startTime, DateTime endTime)
        {
            Name = name;
            Price = price;

            var isStartTimeBeforeEndTime = startTime <= endTime;
            var isWeekDayCorrect = DateHelper.AllowedDaysOfWeek.Contains(startTime.DayOfWeek) &&
                DateHelper.AllowedDaysOfWeek.Contains(endTime.DayOfWeek);
            var isTimeCorrect = DateHelper.IsWorkTime(startTime) && DateHelper.IsWorkTime(endTime);

            if (isStartTimeBeforeEndTime && isWeekDayCorrect && isTimeCorrect)
            {
                StartTime = startTime;
                EndTime = endTime;

                return;
            }

            throw ExceptionMessageHelper.GetExceptionAndPopulateMessage(isWeekDayCorrect, isTimeCorrect);
        }
    }
}
