using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RpgFight.Models;
using RpgFight.Dtos.User;

namespace RpgFight
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, GetUserDto>();
            CreateMap<GetUserDto, User>();
        }
    }
}