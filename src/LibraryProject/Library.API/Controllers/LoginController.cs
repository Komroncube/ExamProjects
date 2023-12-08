using Library.Application.UseCases.Login;

namespace Library.API.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly IMediator _mediator;
    public LoginController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost]
    public async ValueTask<IActionResult> Login(LoginRequest token)
    {
        var response = await _mediator.Send(token);
        return Ok(response);
    }
    [HttpGet]
    //[Authorize(Roles = RoleString.LIBRARIANROLE)]
    public IActionResult CheckUser()
    {
        return Ok("tekshirildi");
    }
}
