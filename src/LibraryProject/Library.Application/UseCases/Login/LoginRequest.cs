using JwtTokenProvider.Models;

namespace Library.Application.UseCases.Login;
public class LoginRequest : IRequest<AuthenticationResponse?>
{
    public string UserName { get; set; }
    public string Password { get; set; }
}
