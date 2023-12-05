using AutoMapper;
using Library.Application.UseCases.Students.Commands.CreateStudent;
using Library.Application.UseCases.Students.Commands.UpdateStudent;
using Library.Application.UseCases.Users.Commands.CreateUser;

namespace Library.Application.Mapper;
public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<User, CreateStudentCommand>().ReverseMap();
        CreateMap<User, CreateUserCommand>().ReverseMap();

        CreateMap<User, UpdateStudentCommand>().ReverseMap();
    }
}
