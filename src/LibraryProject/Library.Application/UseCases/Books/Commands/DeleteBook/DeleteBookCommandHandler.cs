namespace Library.Application.UseCases.Books.Commands.DeleteBook;
public class DeleteBookCommandHandler : ICommandHandler<DeleteBookCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public DeleteBookCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _applicationDbContext.Books.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (book == null)
        {
            throw new Exception("Book not found");
        }
        _applicationDbContext.Books.Remove(book);
        int result = await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return result > 0;

    }
}
