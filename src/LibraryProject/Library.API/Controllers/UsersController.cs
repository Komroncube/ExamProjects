using Library.Application.UseCases.Users.Commands.CreateUser;
using Library.Application.UseCases.Users.Commands.DeleteUser;
using Library.Application.UseCases.Users.Commands.UpdateUser;
using Library.Application.UseCases.Users.Queries.GetAllUsers;
using Library.Application.UseCases.Users.Queries.GetUserById;
using Library.Domain.Entities;
using Microsoft.AspNetCore.Authorization;

namespace Library.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetAllUsers()
    {
        IEnumerable<User> users = await _mediator.Send(new GetAllUsersQuery());
        return Ok(users);
    }
    [HttpGet("{id}")]
    public async ValueTask<IActionResult> GetUserById(int id)
    {
        User user = await _mediator.Send(new GetUserByIdQuery() { Id = id});
        return Ok(user);
    }

    /// <summary>
    /// faqat admin tomonidan yaratiladi
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    [Authorize]
    public async ValueTask<IActionResult> CreateUser([FromForm] CreateUserCommand command)
    {
        bool result = await _mediator.Send(command);
        return Ok(result);
    }
    [HttpPut]
    [Authorize]
    public async ValueTask<IActionResult> UpdateUser(UpdateUserCommand updateUserCommand)
    {
        User user = await _mediator.Send(updateUserCommand);
        return Ok(user);
    }
    [HttpDelete("{id}")]
    [Authorize]
    public async ValueTask<IActionResult> DeleteUser(int id)
    {
        bool isDeleted = await _mediator.Send(new DeleteUserCommand() { Id = id});
        return Ok(isDeleted);
    }



}
