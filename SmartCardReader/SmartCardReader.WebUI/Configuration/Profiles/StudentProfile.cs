using System.Collections.Generic;
using AutoMapper;
using SmartCardReader.ServiceLayer.Models.Response;
using SmartCardReader.WebUI.ViewModels;

namespace SmartCardReader.WebUI.Configuration.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<StudentResponse, StudentViewModel>()
                .ForMember(studentVm => studentVm.Id, options => options.MapFrom(src => src.Id))
                .ForMember(studentVm => studentVm.FirstName, options => options.MapFrom(src => src.FirstName))
                .ForMember(studentVm => studentVm.LastName, options => options.MapFrom(src => src.LastName))
                .ForMember(studentVm => studentVm.Classes, options => options.MapFrom(src => src.Classes))
                .ForMember(studentVm => studentVm.Majors, options => options.MapFrom(src => src.Majors));
        }
    }
}