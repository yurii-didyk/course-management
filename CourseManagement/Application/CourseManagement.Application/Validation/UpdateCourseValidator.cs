using CourseManagement.Application.Commands;
using CourseManagement.Application.Validation.Abstractions;

namespace CourseManagement.Application.Validation
{
    public class UpdateCourseValidator : BaseCourseValidator<UpdateCourseCommand>
    {
        public UpdateCourseValidator() : base() { }
    }
}
