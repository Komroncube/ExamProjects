using AutoMapper;

namespace Library.Application.UseCases.Students.Commands.CreateStudent;
public class CreateStudentCommandHandler : ICommandHandler<CreateStudentCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public CreateStudentCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }



    public async Task<bool> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        var checkUser = await _applicationDbContext.Users.FirstOrDefaultAsync(x => x.UserName == request.UserName, cancellationToken);
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
