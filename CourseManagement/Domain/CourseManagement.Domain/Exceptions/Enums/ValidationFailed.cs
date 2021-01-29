using System;
using System.Collections.Generic;
using System.Text;

namespace CourseManagement.Domain.Exceptions.Enums
{
    public enum ValidationFailed
    {
        Time,
        DayOfWeek,
        FinishedEarlierThanStarted
    }
}
