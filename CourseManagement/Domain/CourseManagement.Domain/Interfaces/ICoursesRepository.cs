using CourseManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Domain.Interfaces
{
    public interface ICoursesRepository
    {
        Task<int> CreateCourse(Course course);
        Task<int> UpdateCourse(Course course);
        Task<int> DeleteCourse(int id);
        Task<IEnumerable<Course>> GetCourses();
        Task<Course> GetCourse(int id);
    }
}
