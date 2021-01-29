using CourseManagement.Domain.Exceptions.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseManagement.Domain.Exceptions
{
    public class CourseValidationException : Exception
    {
        public CourseValidationException() { }
        public CourseValidationException(string message) : base(message) { }
        public CourseValidationException(string message, Exception innerException) : base(message, innerException)
        { }

        public CourseValidationException(ValidationFailed reason)
            : base($"Validation failed. Reason: {GetExceptionMessageByType(reason)}")
        {
        }

        private static string GetExceptionMessageByType(ValidationFailed reason)
        {
            return reason switch
            {
                ValidationFailed.Time => "Time is incorrect. Must be between 9:00 and 17:00",
                ValidationFailed.DayOfWeek => "Day of week is incorrect. Must be between Monday and Friday",
                ValidationFailed.FinishedEarlierThanStarted => "Course cannot be finished before it's started",
                _ => "Unknown"
            };
        }
    }
}
