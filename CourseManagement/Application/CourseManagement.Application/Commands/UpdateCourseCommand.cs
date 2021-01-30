using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace CourseManagement.Application.Commands
{
    public class UpdateCourseCommand: IRequest<int>
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
