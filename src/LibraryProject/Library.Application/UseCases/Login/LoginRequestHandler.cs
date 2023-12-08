using JwtTokenProvider;
using JwtTokenProvider.Models;

namespace Library.Application.UseCases.Login;
public class LoginRequestHandler : IRequestHandler<LoginRequest, AuthenticationResponse>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly JwtTokenHandler _jwtTokenHandler;
    public LoginRequestHandler(IApplicationDbContext applicationDbContext, JwtTokenHandler jwtTokenHandler)
    {
        _applicationDbContext = applicationDbContext;
        _jwtTokenHandler = jwtTokenHandler;
    }

    public async Task<AuthenticationResponse?> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        User? user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => x.UserName == request.UserName && x.Password == request.Password);
        if (user == null)
        {
            return null;
        }
        string role = user.Role switch
        {
            Role.Admin => RoleString.ADMIN,
            Role.Student => RoleString.STUDENT,
            Role.Librarian => RoleString.LIBRARIAN
        };
        AuthenticationResponse? response = _jwtTokenHandler.GenerateToken(new TokenRequest()
        {
            Username = user.UserName,
            RoleName = role,
        });
        return response;


    }
}
