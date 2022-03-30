using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
