using CourseManagement.Application.Commands;
using CourseManagement.Application.Queries;
using CourseManagement.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CourseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseResponse>>> GetCourses()
        {
            var query = new GetCoursesQuery();
            var courses = await _mediator.Send(query);
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseResponse>> GetCourse(int id)
        {
            var query = new GetCourseByIdQuery(id);
            var course = await _mediator.Send(query);
            return Ok(course);
        }


        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateCourseCommand command)
        {
            var id = await _mediator.Send(command);
            return Created(Request.Path, id);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateCourseCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var command = new DeleteCourseCommand(id);
            var removedId = await _mediator.Send(command);
            return Ok(removedId);
        }
    }
}
