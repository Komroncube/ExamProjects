namespace Library.Application.UseCases.Users.Commands.UpdateUser;
public class UpdateUserCommand : ICommand<User>
{
    public int Id { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public string UserName { get; set; }
    public Role Role { get; set; }
}
