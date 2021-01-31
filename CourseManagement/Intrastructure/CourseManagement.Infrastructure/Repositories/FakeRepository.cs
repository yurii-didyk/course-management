using CourseManagement.Domain.Entities;
using CourseManagement.Domain.Exceptions;
using CourseManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Infrastructure.Repositories
{
    public class FakeRepository: ICoursesRepository
    {
        private readonly List<Course> _courses = new List<Course>();

        public Task<IEnumerable<Course>> GetCourses() => Task.FromResult(_courses.AsEnumerable());

        public Task<Course> GetCourse(int id)
        {
            var course = _courses.FirstOrDefault(x => x.Id == id);

            if (course is null)
            {
                throw new CourseNotFoundException(id);
            }

            return Task.FromResult(course);
        }

        public Task<int> CreateCourse(Course course)
        {
            //Fake id setter
            if (course.Id == 0)
            {
                course.Id = _courses.Max(x => x.Id) + 1;
            }

            _courses.Add(course);

            return Task.FromResult(course.Id);
        }

        public Task<int> DeleteCourse(int id)
        {
            var existingCourse = _courses.FirstOrDefault(x => x.Id == id);

            if (existingCourse is null)
            {
                throw new CourseNotFoundException(id);
            }

            _courses.Remove(existingCourse);

            return Task.FromResult(existingCourse.Id);
        }

        public Task<int> UpdateCourse(Course course)
        {
            var existingCourse = _courses.FirstOrDefault(x => x.Id == course.Id);

            if (existingCourse is null)
            {
                throw new CourseNotFoundException(course.Id);
            }

            existingCourse = new Course(course.Name, course.Price, course.StartTime, course.EndTime)
            {
                Id = course.Id
            };

            return Task.FromResult(existingCourse.Id);
        }
    }
}
