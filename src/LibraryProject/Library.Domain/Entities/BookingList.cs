using Library.Domain.Enums;

namespace Library.Domain.Entities;
//hozircha kerak emas
public class BookingList : BaseEntity
{
    public int BookId { get; private set; }
    public Book Book { get; private set; }

    public int UserId { get; private set; }
    public User User { get; private set; }

    public Status Status { get; private set; }


    public void ConfirmBooking(bool confirm = true)
    {
        if (this.Status == Status.Booked)
        {
            throw new InvalidOperationException("Already booked");
        }
        if (confirm)
        {
            this.Status = Status.Booked;
        }
        else
        {
            Status = Status.Rejected;
        }
    }
}
