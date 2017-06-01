using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using SmartCardReader.ServiceLayer.Models.Request;
using SmartCardReader.ServiceLayer.Models.Response;
using SmartCardReader.WebUI.ViewModels;

namespace SmartCardReader.WebUI.Configuration.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<StudentResponse, StudentViewModel>();
            CreateMap<StudentViewModel, StudentRequest>();
            CreateMap<StudentResponse, StudentRequest>();
            CreateMap<StudentRequest, StudentResponse>();
            CreateMap<CreateStudentResponse, StudentViewModel>()
                .ForMember(svm => svm.UniversitieSelectListItems,
                    opts => opts.MapFrom(
                        x => x.Universities.Select(
                            item => new SelectListItem {Text = item.Name, Value = item.Id.ToString()})))
            
                .ForMember(svm => svm.FacultiesSelectListItems,
                    opts => opts.MapFrom(
                        x => x.Faculties.Select(
                            item => new SelectListItem {Text = item.Name, Value = item.Id.ToString()})))
            
                .ForMember(svm => svm.MajorsSelectListItems,
                    opts => opts.MapFrom(
                        x => x.Majors.Select(
                            item => new SelectListItem {Text = item.Name, Value = item.Id.ToString()})));

        }
    }
}