using AutoMapper;
using CourseManagement.Application.Commands;
using CourseManagement.Application.Responses;
using CourseManagement.Domain.Entities;

namespace CourseManagement.Application.Mapping
{
    public class CourseProfile: Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseResponse>();
            CreateMap<CreateCourseCommand, Course>();
            CreateMap<UpdateCourseCommand, Course>();
        }
    }
}
