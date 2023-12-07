namespace Library.Application.Abstractions;
public interface IApplicationDbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<BookCopy> BookCopies { get; set; }
    public DbSet<Checkout> Checkouts { get; set; }
    public DbSet<BookingList> BookingLists { get; set; }
    public ValueTask<int> SaveChangesAsync(CancellationToken cancellationToken);
}
