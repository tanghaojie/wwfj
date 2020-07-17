using AutoMapper;
using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Dtos
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<FJ, FJOutput>();
            CreateMap<NewInput, FJ>();
        }
    }
}
