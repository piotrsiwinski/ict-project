using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Autofac.Core;
using AutoMapper;
using SmartCardReader.DataAccessLayer.Models;
using SmartCardReader.DataAccessLayer.Repository.Base;
using SmartCardReader.ServiceLayer.Base.Class;
using SmartCardReader.ServiceLayer.Models.Request;
using SmartCardReader.ServiceLayer.Models.Response;

namespace SmartCardReader.ServiceLayer.Implementation
{
    public class ClassService : IClassService
    {
        private readonly IClassRepository _classRepository;

        public ClassService()
        {
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

        public void AddClassToStudent(ClassRequest classRequest)
        {
            var cls = new Class{Id = classRequest.ClassId, StartDateTime = DateTime.Today};
            cls.Students.Add(new Student{Id = classRequest.StudentId});
            
            _classRepository.Add(cls);
        }

        ICollection<Class> IClassService.GetClasses()
        {
            return _classRepository.GetAll().ToList();
        }
    }
}