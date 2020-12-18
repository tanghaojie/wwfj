using AutoMapper;
using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Web.Host.Dtos
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<AddUserInput, User>();
            CreateMap<User, AuthenticateOutput>();
            CreateMap<User, UserOutput>();
        }
    }
}
