using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseManagement.Application.Commands
{
    public class UpdateCourceCommand: IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
