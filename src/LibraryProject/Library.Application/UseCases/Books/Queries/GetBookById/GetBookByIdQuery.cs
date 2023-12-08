namespace Library.Application.UseCases.Books.Queries.GetBookById;
public class GetBookByIdQuery : IQuery<Book>
{
    public int Id { get; set; }
}
