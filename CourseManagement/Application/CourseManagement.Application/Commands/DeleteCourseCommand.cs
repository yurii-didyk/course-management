using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseManagement.Application.Commands
{
    public class DeleteCourseCommand: IRequest<int>
    {
        public int Id { get; set; }

        public DeleteCourseCommand(int id)
        {
            Id = id;
        }
    }
}
