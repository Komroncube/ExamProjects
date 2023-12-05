using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Application.Abstractions.Messaging.Queries;

namespace Library.Application.UseCases.Users.Queries.GetUserById;
public class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, User>
{
    public Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
