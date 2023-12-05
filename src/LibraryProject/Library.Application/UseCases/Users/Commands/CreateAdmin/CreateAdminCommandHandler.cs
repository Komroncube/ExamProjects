using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.UseCases.Users.Commands.CreateAdmin;
public class CreateAdminCommandHandler : ICommandHandler<CreateAdminCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public CreateAdminCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }

    public async Task<bool> Handle(CreateAdminCommand request, CancellationToken cancellationToken)
    {
        var checkUser = _applicationDbContext.Users.FirstOrDefaultAsync(x=>x.UserName==request.UserName, cancellationToken);
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
