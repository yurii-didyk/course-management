using AutoMapper;
using CourseManagement.Application.Queries;
using CourseManagement.Application.Responses;
using CourseManagement.Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CourseManagement.Application.Handlers
{
    public class GetCoursesHandler : IRequestHandler<GetCoursesQuery, IEnumerable<CourseResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICoursesRepository _repository;

        public GetCoursesHandler(IMapper mapper, ICoursesRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IEnumerable<CourseResponse>> Handle(GetCoursesQuery query, CancellationToken token)
        {
            var course = await _repository.GetCourses();
            return _mapper.Map<IEnumerable<CourseResponse>>(course);
        }
    }
}
