using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CleanArch.Domain.Models;
using CleanArch.Mvc.Dtos;

namespace CleanArch.Mvc.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            
            //Customer
            CreateMap<Customer, CustomerDto>();
            //Movie
            CreateMap<Movie, MovieDto>();
            CreateMap<MembershipType, MembershipTypeDto>();
            CreateMap<Genre, GenreDto>();
            // Dto to Domain
            CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            CreateMap<MovieDto, Movie>()
                .ForMember(c => c.Id, opt => opt.Ignore());
            /*.ForMember(c => c.DateAdded, opt => opt.Ignore())*/
        }
    }
}
