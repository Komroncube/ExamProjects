namespace Library.Application.UseCases.Students.Commands.DeleteStudent;
public class DeleteStudentCommandHandler : ICommandHandler<DeleteStudentCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public DeleteStudentCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<bool> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
    {
        User? user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => x.Id == request.Id && x.Role == Role.Student);
        if (user is null)
        {
            throw new InvalidOperationException("student not found ");
        }
        _applicationDbContext.Users.Remove(user);
        int result = await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return result > 0;
    }
}
