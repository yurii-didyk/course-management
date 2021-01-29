using AutoMapper;
using CourseManagement.Application.Commands;
using CourseManagement.Domain.Entities;
using CourseManagement.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CourseManagement.Application.Handlers
{
    public class CreateCourseHandler : IRequestHandler<CreateCourseCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ICoursesRepository _repository;

        public CreateCourseHandler(IMapper mapper, ICoursesRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<int> Handle(CreateCourseCommand command, CancellationToken token)
        {
            var course = _mapper.Map<Course>(command);
            return await _repository.CreateCourse(course);
        }
    }
}
