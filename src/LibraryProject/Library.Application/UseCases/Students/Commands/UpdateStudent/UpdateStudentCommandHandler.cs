namespace Library.Application.UseCases.Students.Commands.UpdateStudent;
public class UpdateStudentCommandHandler : ICommandHandler<UpdateStudentCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;

    private readonly IMapper _mapper;

    public UpdateStudentCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
    {
        var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => x.UserName == request.UserName && x.Role == Role.Student, cancellationToken);
        if (user is null)
        {
            throw new InvalidOperationException("Username not found exits");
        }
        _mapper.Map(request, user);

        _applicationDbContext.Users.Update(user);
        int result = await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return result > 0;
    }
}
