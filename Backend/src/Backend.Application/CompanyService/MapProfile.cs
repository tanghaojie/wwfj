using AutoMapper;
using Backend.CompanyService.Dtos;
using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.CompanyService
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Company, CompanyDto>();
            CreateMap<CompanyDto, Company>();
        }
    }
}
