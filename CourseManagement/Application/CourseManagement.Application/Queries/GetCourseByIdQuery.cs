using CourseManagement.Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace CourseManagement.Application.Queries
{
    public class GetCourseByIdQuery: IRequest<CourseResponse>
    {
        public int Id { get; set; }

        public GetCourseByIdQuery(int id)
        {
            Id = id;
        }
    }
}
