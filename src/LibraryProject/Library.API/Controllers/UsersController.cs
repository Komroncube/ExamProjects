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
    public async ValueTask<IActionResult> GetAllUser()
    {
        IEnumerable<User> users = await _mediator.Send(new GetAllUsersQuery());
        return Ok(users);
    }
}
