using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Models.Customer, Dtos.CustomerDto>();
            Mapper.CreateMap<Dtos.CustomerDto, Models.Customer>();
            //Mapper.CreateMap<Dtos.MovieDto, Models.Movie>();
            Mapper.CreateMap<Models.Movie, Dtos.MovieDto>();

            Mapper.CreateMap<MovieDto, Movie>()
                  .ForMember(m => m.Id, opt => opt.Ignore());
        }
    }
}