using AutoMapper;
using CourseManagement.Application.Commands;
using CourseManagement.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CourseManagement.Application.Handlers
{
    public class DeleteCourseHandler: IRequestHandler<DeleteCourseCommand, int>
    {
        private readonly ICoursesRepository _repository;

        public DeleteCourseHandler(ICoursesRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(DeleteCourseCommand command, CancellationToken token)
            => await _repository.DeleteCourse(command.Id);
    }
}
