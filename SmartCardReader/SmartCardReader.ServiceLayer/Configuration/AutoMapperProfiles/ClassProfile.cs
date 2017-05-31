using System;
using System.Linq;
using AutoMapper;
using SmartCardReader.DataAccessLayer.Models;
using SmartCardReader.ServiceLayer.Models.Response;

namespace SmartCardReader.ServiceLayer.Configuration.AutoMapperProfiles
{
    public class ClassProfile : Profile
    {
        public ClassProfile()
        {
            CreateMap<Class, ClassResponse>()
                .ForMember(dest => dest.Lecturers, opts => opts.MapFrom(src => src.Course.Lecturers.Select(x => x.FirstName + x.LastName)));
        }
    }
}