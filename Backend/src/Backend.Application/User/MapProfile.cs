using AutoMapper;
using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<AddUserInput, User>();
            CreateMap<User, UserOutput>();
        }
    }
}
