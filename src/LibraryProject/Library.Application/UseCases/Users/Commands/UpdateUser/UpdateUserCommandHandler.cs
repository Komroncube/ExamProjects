using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.UseCases.Users.Commands.UpdateUser;
public class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand, User>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public UpdateUserCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }

    public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        User? user = await _applicationDbContext.Users.FirstOrDefaultAsync(x=>x.UserName == request.UserName, cancellationToken);
        if(user is null)
        {
            throw new InvalidOperationException("User not found");
        }
        _mapper.Map(request, user);
        user.UpdateEntity();
        int result = await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return result > 0 ? user : throw new Exception();    
    }
}
