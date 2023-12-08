namespace Library.Domain.Entities;
public class Book : BaseEntity
{
    public string Title { get; private set; }
    public string? Description { get; private set; }
    public string Author { get; private set; }
    public string Category { get; private set; }
    public string? CoverImage { get; private set; }

    public ICollection<BookCopy> BookCopies { get; private set; }
    public ICollection<BookingList> BookingLists { get; private set; }


    public Book(string title, string? description, string author, string category)
    {
        Title = title;
        Description = description; 
        Author = author; 
        Category = category;
    }
    public Book(int id, string title, string? description, string author, string category) : this(title, description, author, category)
    {
        Id = id;
    }


}
