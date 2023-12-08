namespace Library.Application.UseCases.Books.Queries.GetAllBooks;
public class GetAllBooksQueryHandler : IQueryHandler<GetAllBooksQuery, IEnumerable<Book>>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetAllBooksQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<IEnumerable<Book>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Book> books = await _applicationDbContext.Books.ToListAsync(cancellationToken);
        if (books is null)
        {
            return Enumerable.Empty<Book>();
        }
        return books;
    }
}
