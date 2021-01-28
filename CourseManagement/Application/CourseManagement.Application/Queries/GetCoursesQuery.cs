using CourseManagement.Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace CourseManagement.Application.Queries
{
    public class GetCoursesQuery: IRequest<IEnumerable<CourseResponse>>
    {
    }
}
