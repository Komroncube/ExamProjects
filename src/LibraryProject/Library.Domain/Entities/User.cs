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
    public Role Role { get; private set; }

    public void SetPassword(string password) => Password = password;
}
