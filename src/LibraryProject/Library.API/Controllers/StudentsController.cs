using Library.Application.UseCases.Students.Commands.CreateStudent;
using Library.Application.UseCases.Students.Commands.UpdateStudent;
using Library.Application.UseCases.Users.Queries.GetUserById;
using Library.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class StudentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public StudentsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    public async ValueTask<IActionResult> GetStudentById(GetUserByIdQuery query)
    {
        User user = await _mediator.Send(query);
        return Ok(user);
    }


    [HttpPost]
    public async ValueTask<IActionResult> CreateStudent(CreateStudentCommand command)
    {
        bool result = await _mediator.Send(command);
        return Ok(result);
    }
    [HttpPut]
    public async ValueTask<IActionResult> UpdateStudent(UpdateStudentCommand command)
    {
        bool result = await _mediator.Send(command);
        return Ok();
    }
}
