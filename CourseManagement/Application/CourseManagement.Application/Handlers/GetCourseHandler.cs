using AutoMapper;
using CourseManagement.Application.Queries;
using CourseManagement.Application.Responses;
using CourseManagement.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CourseManagement.Application.Handlers
{
    public class GetCourseHandler: IRequestHandler<GetCourseByIdQuery, CourseResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICoursesRepository _repository;

        public GetCourseHandler(IMapper mapper, ICoursesRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<CourseResponse> Handle(GetCourseByIdQuery query, CancellationToken token)
        {
            var course = await _repository.GetCourse(query.Id);
            return _mapper.Map<CourseResponse>(course);
        }
    }
}
