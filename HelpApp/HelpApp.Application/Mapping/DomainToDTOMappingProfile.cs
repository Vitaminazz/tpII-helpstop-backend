﻿using AutoMapper;
using HelpApp.Domain.Entities;
using HelpApp.Application.DTOs;

namespace HelpApp.Application.Mapping
{
    internal class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
