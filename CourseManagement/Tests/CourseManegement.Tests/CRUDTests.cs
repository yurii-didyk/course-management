using AutoMapper;
using CourseManagement.Application.Commands;
using CourseManagement.Application.Handlers;
using CourseManagement.Application.Mapping;
using CourseManagement.Application.Queries;
using CourseManagement.Domain.Entities;
using CourseManagement.Domain.Exceptions;
using CourseManagement.Domain.Interfaces;
using CourseManagement.Infrastructure.Repositories;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Threading;

namespace CourseManegement.Tests
{
    public class CRUDTests
    {
        private ICoursesRepository _fakeRepository;
        private IMapper _mapper;

        [SetUp]
        public async Task Setup()
        {
            _fakeRepository = await GetRepository();
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CourseProfile());
            }).CreateMapper();
        }

        [Test]
        public async Task GetCoursesTest_Should_Return_List()
        {
            //Arrange
            var request = new GetCoursesQuery();
            var handler = new GetCoursesHandler(_mapper, _fakeRepository);

            //Act
            var courses = await handler.Handle(request, new CancellationToken());

            //Assert
            var course = courses.FirstOrDefault(x => x.Id == 1);
            Assert.AreEqual(courses.Count(), 2);
            Assert.AreEqual(course.Id, 1);
            Assert.AreEqual(course.Price, 5000);
        }

        [Test]
        public async Task GetCourseTest_Should_Return_Object()
        {
            //Arrange
            var request = new GetCourseByIdQuery(1);
            var handler = new GetCourseHandler(_mapper, _fakeRepository);

            //Act
            var course = await handler.Handle(request, new CancellationToken());

            //Assert
            Assert.AreEqual(course.Id, 1);
            Assert.AreEqual(course.Price, 5000);
        }

        [Test]
        public void GetCourseTest_Should_Throw_NotFound_Exception()
        {
            //Arrange
            var request = new GetCourseByIdQuery(9999);
            var handler = new GetCourseHandler(_mapper, _fakeRepository);

            //Act && Assert
            Assert.ThrowsAsync<CourseNotFoundException>(() => handler.Handle(request, new CancellationToken()));
        }

        [Test]
        public async Task CreateCourseTest_Should_Return_Id()
        {
            //Arrange
            var request = new CreateCourseCommand
            {
                Name = "Math",
                Price = 5000,
                StartTime = new DateTime(2021, 02, 02, 10, 00, 00),
                EndTime = new DateTime(2021, 02, 04, 12, 00, 00),
            };

            var handler = new CreateCourseHandler(_mapper, _fakeRepository);

            //Act
            var course = await handler.Handle(request, new CancellationToken());

            //Assert
            Assert.AreEqual(course, 3);
        }


        [Test]
        public void CreateCourseTest_Should_Throw_Validation_Exception()
        {
            //Arrange
            var request = new CreateCourseCommand
            {
                Name = "Math",
                Price = 5000,
                StartTime = new DateTime(2021, 01, 30, 10, 00, 00),
                EndTime = new DateTime(2021, 02, 04, 12, 00, 00),
            };

            var handler = new CreateCourseHandler(_mapper, _fakeRepository);


            //Act && Assert
            Assert.ThrowsAsync<CourseValidationException>(() => handler.Handle(request, new CancellationToken()));
        }

        [Test]
        public async Task UpdateCourseTest_Should_Return_Id()
        {
            //Arrange
            var request = new UpdateCourseCommand
            {
                Id = 1,
                Name = "Math",
                Price = 5000,
                StartTime = new DateTime(2021, 02, 02, 10, 00, 00),
                EndTime = new DateTime(2021, 02, 04, 12, 00, 00),
            };

            var handler = new UpdateCourseHandler(_mapper, _fakeRepository);

            //Act 
            var id = await handler.Handle(request, new CancellationToken());

            //Assert
            Assert.AreEqual(id, 1);
        }

        [Test]
        public async Task DeleteCourseTest_And_Check_Collection_Should_Return_Id()
        {
            //Arrange
            var request = new DeleteCourseCommand(1);
            var handler = new DeleteCourseHandler(_fakeRepository);

            var getRequest = new GetCoursesQuery();
            var getHandler = new GetCoursesHandler(_mapper, _fakeRepository);

            //Act 
            var id = await handler.Handle(request, new CancellationToken());
            var courses = await getHandler.Handle(getRequest, new CancellationToken());


            //Assert
            Assert.AreEqual(id, 1);
            Assert.AreEqual(courses.Count(), 1);
        }

        private async Task<ICoursesRepository> GetRepository()
        {
            var fakeRepository = new FakeRepository();
            var courses = new List<Course> {
                new Course
                {
                    Id = 1,
                    Price = 5000,
                    Name = "Data Structures"
                },
                new Course
                {
                    Id = 2,
                    Price = 6000,
                    Name = "Philosophy"
                },
            };
            courses.ForEach(x => x.SetTime(new DateTime(2021, 01, 26, 10, 30, 00), new DateTime(2021, 01, 28, 15, 00, 00)));
            var tasks = courses.Select(x => fakeRepository.CreateCourse(x));
            await Task.WhenAll(tasks);

            return fakeRepository;
        }
    }
}