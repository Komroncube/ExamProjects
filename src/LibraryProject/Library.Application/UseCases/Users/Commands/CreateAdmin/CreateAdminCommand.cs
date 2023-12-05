
using Library.Application.Abstractions.Messaging.Commands;

namespace Library.Application.UseCases.Users.Commands.CreateAdmin;
public class CreateAdminCommand : ICommand<bool>
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string UserName { get; private set; }
    public string Password { get; private set; }
    public string Phone { get; private set; }

}
