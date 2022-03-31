using AutoMapper;
using Tasnim.Domain.Entities.Users;
using Tasnim.Service.DTOs;

namespace Tasnim.Service.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserForRegistrationDto, User>().ReverseMap();
        }
    }
}
