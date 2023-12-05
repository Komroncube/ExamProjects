namespace Library.Domain.Entities;
public class Book : BaseEntity
{
    public string Title { get; private set; }
    public string? Description { get; private set; }
    public string Author { get; private set; }
    public string Category { get; private set; }
    public string CoverImage { get; private set; }

    public ICollection<BookCopy> BookCopies { get; private set; }
}
