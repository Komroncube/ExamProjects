namespace Library.Application.UseCases.Books.Commands.CreateBook;
public class CreateBookCommandHandler : ICommandHandler<CreateBookCommand, Book>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public CreateBookCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }

    public async Task<Book> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        Book book = _mapper.Map<Book>(request);
        await _applicationDbContext.Books.AddAsync(book, cancellationToken);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return book;

    }
}
