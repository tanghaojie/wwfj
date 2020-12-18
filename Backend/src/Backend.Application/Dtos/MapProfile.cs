using AutoMapper;
using Backend.Dtos2;
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
            CreateMap<FJ, FJOutput>();
            CreateMap<FJ2, FJ2Output>();
            CreateMap<FJ2NewInput, FJ2>();
            CreateMap<AddRequestCompanyInput, RequestCompany>();
            CreateMap<RequestCompany, RequestCompanyOutput>();

        }
    }
}
