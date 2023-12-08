using Library.Application.Services;

namespace Library.Application.UseCases.Users.Queries.GetAllUsers;
public class GetAllUsersQueryHandler : IQueryHandler<GetAllUsersQuery, IEnumerable<User>>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly ICacheService _cacheService;

    public GetAllUsersQueryHandler(IApplicationDbContext applicationDbContext, ICacheService cacheService)
    {
        _applicationDbContext = applicationDbContext;
        _cacheService = cacheService;
    }

    public async Task<IEnumerable<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _cacheService.GetDataAsync<IEnumerable<User>>(CacheKeys.USERSKEY); //await _applicationDbContext.Users.ToListAsync();
        if (users is null)
        {
            users = await _applicationDbContext.Users.ToListAsync(cancellationToken);
            await _cacheService.SetDataAsync(CacheKeys.USERSKEY, users, TimeSpan.FromMinutes(10));
        }
        return users;
    }
}
