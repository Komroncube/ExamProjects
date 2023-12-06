namespace Library.Application.UseCases.Students.Commands.UpdateStudent;
public class UpdateStudentCommand : ICommand<bool>
{
    public int Id { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public string UserName { get; set; }
}
