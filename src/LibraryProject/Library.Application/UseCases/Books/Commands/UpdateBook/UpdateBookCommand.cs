namespace Library.Application.UseCases.Books.Commands.UpdateBook;
public class UpdateBookCommand : ICommand<Book>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public string Category { get; set; }

}
