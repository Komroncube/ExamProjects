using Library.Application.UseCases.Users.Commands.CreateUser;
using Library.Application.UseCases.Users.Commands.DeleteUser;
using Library.Application.UseCases.Users.Commands.UpdateUser;
using Library.Application.UseCases.Users.Queries.GetAllUsers;
using Library.Application.UseCases.Users.Queries.GetUserById;
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
    public async ValueTask<IActionResult> GetAllUsers()
    {
        IEnumerable<User> users = await _mediator.Send(new GetAllUsersQuery());
        return Ok(users);
    }
    [HttpGet]
    public async ValueTask<IActionResult> GetUserById(GetUserByIdQuery getUserByIdQuery)
    {
        User user = await _mediator.Send(getUserByIdQuery);
        return Ok(user);
    }

    /// <summary>
    /// faqat admin tomonidan yaratiladi
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    public async ValueTask<IActionResult> CreateUser(CreateUserCommand command)
    {
        bool result = await _mediator.Send(command);
        return Ok(result);
    }
    [HttpPut]
    public async ValueTask<IActionResult> UpdateUser(UpdateUserCommand updateUserCommand)
    {
        User user = await _mediator.Send(updateUserCommand);
        return Ok(user);
    }
    [HttpDelete]
    public async ValueTask<IActionResult> DeleteUser(DeleteUserCommand deleteUserCommand)
    {
        bool isDeleted = await _mediator.Send(deleteUserCommand);
        return Ok(isDeleted);
    }
    


}
