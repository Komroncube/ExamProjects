using Library.Application.Services;

namespace Library.Application.UseCases.Books.Queries.GetBookById;
public class GetBookByIdQueryHandler : IQueryHandler<GetBookByIdQuery, Book>
{
    private readonly ICacheService _cacheService;

    public GetBookByIdQueryHandler(ICacheService cacheService)
    {
        _cacheService = cacheService;
    }


    public async Task<Book> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        var books = await _cacheService.GetDataAsync<IEnumerable<Book>>(CacheKeys.BOOKSKEY, cancellationToken);
        Book book = books.FirstOrDefault(x => x.Id == request.Id);


        return book is null ? null : book;
    }
}
