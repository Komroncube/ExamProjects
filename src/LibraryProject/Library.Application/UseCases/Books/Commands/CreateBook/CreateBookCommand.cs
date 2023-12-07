namespace Library.Application.UseCases.Books.Commands.CreateBook;
public class CreateBookCommand : ICommand<Book>
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public string Author { get; set; }
    public string Category { get; set; }
    //cover image ham bo'lishi kerak keyinchalik
    //public IFormFile BookImage { get; set; }
}
