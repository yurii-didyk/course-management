using CourseManagement.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseManagement.Domain.Entities
{
    public class Course: BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
