using CourseManagement.Domain.Entities;
using CourseManagement.Domain.Exceptions;
using CourseManagement.Domain.Interfaces;
using CourseManagement.Infrastructure.Persistency.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Infrastructure.Repositories
{
    public class CoursesRepository: ICoursesRepository
    {
        private readonly CourseDbContext _context;

        public CoursesRepository(CourseDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Course>> GetCourses() => await _context.Courses.ToListAsync();
        public async Task<Course> GetCourse(int id) => await _context.Courses.FirstOrDefaultAsync(x => x.Id == id);
        public async Task<int> CreateCourse(Course course)
        {
            await _context.Courses.AddAsync(course);
            // In general prefer to create UoW, and save changes from there, but in case
            // if we have only 1 entity/table, i think it's ok to use it directly in repository
            await _context.SaveChangesAsync();

            return course.Id;
        }

        public async Task<int> DeleteCourse(int id)
        {
            var existingCourse = await _context.Courses.FirstOrDefaultAsync(x => x.Id == id);

            if (existingCourse is null)
            {
                throw new CourseNotFoundException(id);
            }

            _context.Courses.Remove(existingCourse);
            await _context.SaveChangesAsync();

            return existingCourse.Id;
        }

        public async Task<int> UpdateCourse(Course course)
        {
            var existingCourse = await _context.Courses.FirstOrDefaultAsync(x => x.Id == course.Id);

            if (existingCourse is null)
            {
                throw new CourseNotFoundException(course.Id);
            }

            _context.Entry(existingCourse).CurrentValues.SetValues(course);
            await _context.SaveChangesAsync();

            return existingCourse.Id;
        }
    }
}
