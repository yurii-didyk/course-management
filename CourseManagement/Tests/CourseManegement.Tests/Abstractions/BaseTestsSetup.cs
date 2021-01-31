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
                new Course(
                    "Data Structures",
                    5000,
                    new DateTime(2021, 01, 26, 10, 30, 00),
                    new DateTime(2021, 01, 28, 15, 00, 00)
                ),

                new Course(
                    "Math",
                    6000,
                    new DateTime(2021, 01, 26, 10, 30, 00),
                     new DateTime(2021, 01, 28, 15, 00, 00)
                )
            };
            courses.ForEachWithIndex((x, index) => x.Id = index + 1);
            var tasks = courses.Select(x => fakeRepository.CreateCourse(x));
            await Task.WhenAll(tasks);

            return fakeRepository;
        }
    }
}
