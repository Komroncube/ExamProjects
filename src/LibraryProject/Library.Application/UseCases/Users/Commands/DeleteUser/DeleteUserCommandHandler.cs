namespace Library.Application.UseCases.Users.Commands.DeleteUser;
public class DeleteUserCommandHandler : ICommandHandler<DeleteUserCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public DeleteUserCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        User? user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (user is null)
        {
            throw new ArgumentException("User not found");
        }
        _applicationDbContext.Users.Remove(user);
        int result = await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return result > 0;
    }
}
