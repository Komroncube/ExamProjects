using AutoMapper;
using Library.Application.Abstractions;
using Library.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.UseCases.Users.Commands.CreateStudent;
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
        var checkUser = _applicationDbContext.Users.FirstOrDefaultAsync(x => x.UserName == request.UserName, cancellationToken);
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
