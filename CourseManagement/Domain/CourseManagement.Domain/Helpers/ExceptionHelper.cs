using CourseManagement.Domain.Exceptions;
using CourseManagement.Domain.Exceptions.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseManagement.Domain.Helpers
{
    public static class ExceptionHelper
    {
        public static Exception GetException(bool isWeekDayCorrect, bool isTimeCorrect)
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
