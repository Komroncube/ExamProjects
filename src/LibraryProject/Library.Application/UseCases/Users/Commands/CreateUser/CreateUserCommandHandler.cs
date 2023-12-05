using AutoMapper;

namespace Library.Application.UseCases.Users.Commands.CreateUser;
public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }

    public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var checkUser = _applicationDbContext.Users.FirstOrDefaultAsync(x => x.UserName == request.UserName, cancellationToken);
        if (checkUser is null)
        {
            throw new InvalidOperationException("Username already exits");
        }
        User user = _mapper.Map<User>(request);

        await _applicationDbContext.Users.AddAsync(user, cancellationToken);
        int result = await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return result > 0;
    }
}
