using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SmartCardReader.DataAccessLayer.Models;
using SmartCardReader.ServiceLayer.Models.Request;
using SmartCardReader.ServiceLayer.Models.Response;

namespace SmartCardReader.ServiceLayer.Configuration.AutoMapperProfiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentResponse>()
                .ForMember(dest => dest.Classes, opts => opts.MapFrom(src => src.Classes.Select(x => x.Course.Name)))
                .ForMember(dest => dest.Majors, opts => opts.MapFrom(src => src.Majors.Select(x => x.MajorBase.Name)));

            CreateMap<StudentRequest, Student>()
                .ForMember(dst => dst.IndexNumber, opts => opts.MapFrom(x => x.Id))
                .ForMember(dst => dst.Id, opts => opts.Ignore());
        }
    }
}