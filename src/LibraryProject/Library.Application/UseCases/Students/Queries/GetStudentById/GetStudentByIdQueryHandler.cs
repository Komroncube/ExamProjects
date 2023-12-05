namespace Library.Application.UseCases.Students.Queries.GetStudentById;
public class GetStudentByIdQueryHandler : IQueryHandler<GetStudentByIdQuery, User>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetStudentByIdQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<User> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
    {
        User? user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => x.Id == request.Id && x.Role == Role.Student);
        if (user is null)
        {
            throw new InvalidOperationException("studnet not found");
        }
        return user;
    }
}
