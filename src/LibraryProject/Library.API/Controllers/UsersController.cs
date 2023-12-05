using Library.Application.UseCases.Users.Commands.CreateStudent;
using Library.Application.UseCases.Users.Commands.CreateUser;
using Library.Application.UseCases.Users.Queries.GetAllUsers;
using Library.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;
[ApiController]
[Route("api/[controller]/[action]")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetAllUsers(CancellationToken cancellationToken)
    {
        IEnumerable<User> users = await _mediator.Send(new GetAllUsersQuery(), cancellationToken);
        return Ok(users);
    }

    /// <summary>
    /// faqat admin tomonidan yaratiladi
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    public async ValueTask<IActionResult> AddAdmin(CreateUserCommand command)
    {
        bool result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPost]
    public async ValueTask<IActionResult> CreateStudent(CreateStudentCommand command)
    {
        bool result = await _mediator.Send(command);
        return Ok(result);
    }
}
