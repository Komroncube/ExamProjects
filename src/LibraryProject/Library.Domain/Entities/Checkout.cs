using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities;
public class Checkout : BaseEntity
{

    public int BookCopyId { get; private set; }
    public BookCopy BookCopy { get; private set; }

    public int UserId { get; private set; }
    public User User { get; private set; }
    public TimeInterval BookingIterval { get; private set; }
    public bool IsReturned { get; private set; }

}
[NotMapped]
public record TimeInterval
{
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public TimeInterval(DateTime startDate, DateTime endTime)
    {
        if (startDate >= endTime)
            throw new InvalidOperationException("Tugash vaqti boshlash vaqtidan keyin kelishi kerak");
        StartDate = startDate;
        EndDate = endTime;
    }
    public TimeInterval()
    {

    }
}

