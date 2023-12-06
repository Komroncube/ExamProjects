namespace Library.Application.UseCases.Users.Commands.UpdateUser;
public class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand, User>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public UpdateUserCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }

    public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        User? user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (user is null)
        {
            throw new InvalidOperationException("User not found");
        }
        User? checkUsername = await _applicationDbContext.Users.FirstOrDefaultAsync(x => x.UserName == request.UserName, cancellationToken);
        if (checkUsername is not null)
        {
            throw new Exception("Username already exists");
        }
        _mapper.Map(request, user);
        user.UpdateEntity();
        int result = await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return result > 0 ? user : throw new Exception();
    }
}
