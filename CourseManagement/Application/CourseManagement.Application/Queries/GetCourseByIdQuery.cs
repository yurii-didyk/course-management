using CourseManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseManagement.Application.Queries
{
    public class GetCourseByIdQuery: IRequest<IEnumerable<ProductResponse>>
    {
        public int Id { get; set; }
        public GetCourseByIdQuery(int id)
        {
            Id = id;
        }
    }
}
