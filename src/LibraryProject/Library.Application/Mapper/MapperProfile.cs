using AutoMapper;
using Library.Application.UseCases.Users.Commands.CreateAdmin;

namespace Library.Application.Mapper;
public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<User, CreateAdminCommand>().ReverseMap();
    }
}
