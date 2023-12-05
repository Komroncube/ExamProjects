using Library.Application.Abstractions.Messaging.Queries;
using Library.Domain.Entities;

namespace Library.Application.UseCases.Users.Queries.GetAllUsers;
public class GetAllUsersQuery : IQuery<IEnumerable<User>>
{
}
