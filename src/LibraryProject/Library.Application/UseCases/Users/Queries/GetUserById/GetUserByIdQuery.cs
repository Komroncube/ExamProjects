using Library.Application.Abstractions.Messaging.Queries;

namespace Library.Application.UseCases.Users.Queries.GetUserById;
public class GetUserByIdQuery : IQuery<User>
{
    public int Id { get; set; }
}
