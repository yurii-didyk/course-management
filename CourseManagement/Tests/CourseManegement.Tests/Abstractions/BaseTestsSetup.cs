using CourseManagement.Domain.Entities;
using CourseManagement.Domain.Interfaces;
using CourseManagement.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using CourseManagement.Application.Extensions;
using System.Threading.Tasks;
using System.Linq;

namespace CourseManegament.Tests.Abstractions
{
    public abstract class BaseTestsSetup
    {
        protected async Task<ICoursesRepository> GetAndInitializeRepository()
        {
            var fakeRepository = new FakeRepository();
            var courses = new List<Course> {
                new Course
                {
                    Id = 1,
                    Name = "Data Structures",
                    Price = 5000,
                    StartTime = new DateTime(2021, 01, 26, 10, 30, 00),
                    EndTime = new DateTime(2021, 01, 28, 15, 00, 00)
                },
                 new Course
                {
                    Id = 2,
                    Name = "Math",
                    Price = 6000,
                    StartTime = new DateTime(2021, 01, 26, 10, 30, 00),
                    EndTime = new DateTime(2021, 01, 28, 15, 00, 00)
                },
            };

            var tasks = courses.Select(x => fakeRepository.CreateCourse(x));
            await Task.WhenAll(tasks);

            return fakeRepository;
        }
    }
}
