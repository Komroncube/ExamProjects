using Library.Application.UseCases.Books.Commands.CreateBook;
using Library.Application.UseCases.Books.Commands.UpdateBook;
using Library.Application.UseCases.Students.Commands.CreateStudent;
using Library.Application.UseCases.Students.Commands.UpdateStudent;
using Library.Application.UseCases.Users.Commands.CreateUser;
using Library.Application.UseCases.Users.Commands.UpdateUser;

namespace Library.Application.Mapper;
public class MapperProfile : Profile
{
    public MapperProfile()
    {
        //user
        CreateMap<User, CreateUserCommand>().ReverseMap();
        CreateMap<User, UpdateUserCommand>().ReverseMap();


        //student
        CreateMap<User, CreateStudentCommand>().ReverseMap();
        CreateMap<User, UpdateStudentCommand>().ReverseMap();
        
        //book
        CreateMap<Book, CreateBookCommand>().ReverseMap();
        CreateMap<Book, UpdateBookCommand>().ReverseMap();

    }
}
