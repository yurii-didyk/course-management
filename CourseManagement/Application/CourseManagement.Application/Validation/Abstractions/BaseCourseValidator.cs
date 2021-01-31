using CourseManagement.Application.Commands;
using FluentValidation;
using System;

namespace CourseManagement.Application.Validation.Abstractions
{
    public class BaseCourseValidator<T>: AbstractValidator<T> where T: ICourseCommand
    {
        public BaseCourseValidator()
        {
            RuleFor(x => x.StartTime.Hour).InclusiveBetween(9, 17);
            RuleFor(x => x.EndTime.Hour).InclusiveBetween(9, 17);
            RuleFor(x => (int)x.StartTime.DayOfWeek).InclusiveBetween((int)DayOfWeek.Monday, (int)DayOfWeek.Friday);
            RuleFor(x => (int)x.EndTime.DayOfWeek).InclusiveBetween((int)DayOfWeek.Monday, (int)DayOfWeek.Friday);
            RuleFor(x => x.StartTime).LessThan(x => x.EndTime);
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
