using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.UseCases.Books.Commands.UpdateBook;
public class UpdateBookCommandHandler : ICommandHandler<UpdateBookCommand, Book>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public UpdateBookCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }

    public async Task<Book> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        Book? book = await _applicationDbContext.Books.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (book == null)
        {
            throw new Exception("Book not found");
        }
        _mapper.Map(request, book);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return book;
    }
}
