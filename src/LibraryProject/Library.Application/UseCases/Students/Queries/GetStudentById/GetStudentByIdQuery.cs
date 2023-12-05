namespace Library.Application.UseCases.Students.Queries.GetStudentById;
public class GetStudentByIdQuery : IQuery<User>
{
    public int Id { get; set; }
}
