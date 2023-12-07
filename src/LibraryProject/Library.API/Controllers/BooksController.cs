

using Library.Application.UseCases.Books.Commands.CreateBook;
using Library.Application.UseCases.Books.Queries.GetAllBooks;
using Library.Domain.Entities;

namespace Library.API.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IMediator _mediator;

    public BooksController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    public async ValueTask<IActionResult> GetAllBooks()
    {
        IEnumerable<Book> books = await _mediator.Send(new GetAllBooksQuery());
        return Ok(books);
    }
    [HttpPost]
    public async ValueTask<IActionResult> CreateBook(CreateBookCommand createBookCommand)
    {
        Book book = await _mediator.Send(createBookCommand);
        return Ok(book);
    }
}
