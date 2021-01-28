using CourseManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseManagement.Application.Queries
{
    public class GetCoursesQuery: IRequest<IEnumerable<ProductResponse>>
    {
    }
}
