namespace Library.Domain.Entities;
public class BookCopy : BaseEntity
{
    public DateTime PublishedYear { get; private set; }
    public int BookId { get; private set; }
    public Book Book { get; private set; }
}
