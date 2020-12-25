using AutoMapper;
using Backend.Entities;
using Backend.OptionService.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.OptionService
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Option, OptionDto>();
            CreateMap<OptionDto, Option>();
        }
    }
}
