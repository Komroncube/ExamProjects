﻿namespace Library.Application.UseCases.Users.Commands.CreateUser;
public class CreateUserCommand : ICommand<bool>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public Role Role { get; set; }
}
