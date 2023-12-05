using Library.Application.Abstractions;
using Library.Application.Abstractions.Messaging.Queries;

namespace Library.Application.UseCases.Users.Queries.GetAllUsers;
public class GetAllUserQueryHandler : IQueryHandler<GetAllUsersQuery, IEnumerable<User>>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetAllUserQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<IEnumerable<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<User> users = await _applicationDbContext.Users.ToListAsync();

        return users;
    }
}
