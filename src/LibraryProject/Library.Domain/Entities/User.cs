using Library.Domain.Enums;

namespace Library.Domain.Entities;
public class User : BaseEntity
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string UserName { get; private set; }
    public string Password { get; private set; }
    public string Phone { get; private set; }
    public Role Role { get; private set; } = Role.Student;

    public ICollection<BookingList> Bookings { get; private set; }
    public ICollection<Checkout> Checkouts { get; private set; }
    public void SetPassword(string password) => Password = password;

    public User(string firstname, string lastname, string email, string username, string password, string phone, Role? role)
    {
        FirstName = firstname;
        LastName = lastname;
        Email = email;
        UserName = username;
        Password = password;
        Phone = phone;
        Role = role ?? Role.Student;
    }
    public User(int id, string firstname, string lastname, string email, string username, string password, string phone, Role? role): this(firstname, lastname, email, username, password, phone, role)
    {
        Id = id;
    }
    public User()
    {

    }

    public void SetRole(Role role)
    {
        if (this.Role == role)
        {
            throw new InvalidOperationException("Role alread been set");
        }
        Role = role;
    }
}
