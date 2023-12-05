namespace Library.Domain.Entities;
public class Checkout : BaseEntity
{

    public int BookId { get; private set; }
    public Book Book { get; private set; }

    public int UserId { get; set; }
    public BookCopy BookCopy { get; set; }
    public TimeInterval BookingIterval { get; set; }
    public bool IsReturned { get; set; }

    public record TimeInterval(DateTime startDate, DateTime returnDate);
}
