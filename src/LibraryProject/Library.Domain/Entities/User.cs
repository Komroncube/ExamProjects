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

    public void SetPassword(string password) => Password = password;

    public User(string firstname, string lastname, string email, string username, string password, string phone)
    {
        FirstName = firstname;
        LastName = lastname;
        Email = email;
        UserName = username;
        Password = password;
        Phone = phone;
    }
    public User()
    {
        
    }

    public void SetRole(Role role)
    {
        if(this.Role == role)
        {
            throw new InvalidOperationException("Role alread been set");
        }
        Role = role;
    }
}
