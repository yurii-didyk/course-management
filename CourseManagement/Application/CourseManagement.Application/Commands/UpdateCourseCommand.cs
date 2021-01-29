using MediatR;
using System;

namespace CourseManagement.Application.Commands
{
    public class UpdateCourseCommand: IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
