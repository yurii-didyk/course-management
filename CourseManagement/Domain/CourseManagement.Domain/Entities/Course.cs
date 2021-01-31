using CourseManagement.Domain.Abstractions;
using System;
using System.ComponentModel.DataAnnotations;

namespace CourseManagement.Domain.Entities
{
    public class Course: BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
