namespace Library.Application.UseCases.Students.Commands.DeleteStudent;
public class DeleteStudentCommand : ICommand<bool>
{
    public int Id { get; set; }
}
