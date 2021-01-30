using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace CourseManagement.Application.Commands
{
    public class CreateCourseCommand: IRequest<int>
    {
        [Required]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
