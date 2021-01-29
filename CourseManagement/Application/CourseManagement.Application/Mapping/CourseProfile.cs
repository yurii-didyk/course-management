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
            CreateMap<CreateCourseCommand, Course>()
                .ForMember(x => x.StartTime, opt => opt.Ignore())
                .ForMember(x => x.EndTime, opt => opt.Ignore());
            CreateMap<UpdateCourseCommand, Course>()
                .ForMember(x => x.StartTime, opt => opt.Ignore())
                .ForMember(x => x.EndTime, opt => opt.Ignore());
        }
    }
}
