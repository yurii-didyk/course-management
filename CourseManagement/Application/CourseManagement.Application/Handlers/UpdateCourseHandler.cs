using AutoMapper;
using CourseManagement.Application.Commands;
using CourseManagement.Domain.Entities;
using CourseManagement.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CourseManagement.Application.Handlers
{
    public class UpdateCourseHandler : IRequestHandler<UpdateCourseCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ICoursesRepository _repository;

        public UpdateCourseHandler(IMapper mapper, ICoursesRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<int> Handle(UpdateCourseCommand command, CancellationToken token)
        {
            var course = _mapper.Map<UpdateCourseCommand, Course>(command, opt =>
                opt.AfterMap((src, dest) => dest.SetTime(src.StartTime, src.EndTime)));

            return await _repository.UpdateCourse(course);
        }
    }
}
