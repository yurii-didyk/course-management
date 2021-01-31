using CourseManagement.Application.Commands;
using CourseManagement.Application.Validation.Abstractions;

namespace CourseManagement.Application.Validation
{
    public class CreateCourseValidator: BaseCourseValidator<CreateCourseCommand>
    {
        public CreateCourseValidator(): base() { }
    }
}
