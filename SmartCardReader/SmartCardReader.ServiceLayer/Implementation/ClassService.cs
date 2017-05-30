using System.Collections.Generic;
using System.Linq;
using Autofac;
using Autofac.Core;
using AutoMapper;
using SmartCardReader.DataAccessLayer.Models;
using SmartCardReader.DataAccessLayer.Repository.Base;
using SmartCardReader.ServiceLayer.Base.Class;
using SmartCardReader.ServiceLayer.Models.Response;

namespace SmartCardReader.ServiceLayer.Implementation
{
    public class ClassService : IClassService
    {
        private static IContainer Container { get; set; }

        private readonly IClassRepository _classRepository;

        public ClassService()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Class, ClassResponse>()
                    .ForMember(dest => dest.Lecturers, opts => opts.MapFrom(src => src.Course.Lecturers.Select(x => x.FirstName + x.LastName)));
            });
        }

        public ClassService(IClassRepository classRepository) : this()
        {
            this._classRepository = classRepository;
        }

        public ICollection<ClassResponse> GetClassesResponse()
        {
            var result = _classRepository.GetAll().ToList();
            var test = Mapper.Map<List<Class>, List<ClassResponse>>(result);
            return test;
        }

        ICollection<Class> IClassService.GetClasses()
        {
            return _classRepository.GetAll().ToList();
        }
    }
}