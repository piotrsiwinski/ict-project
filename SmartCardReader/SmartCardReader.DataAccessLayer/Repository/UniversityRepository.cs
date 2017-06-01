using System;
using System.Collections.Generic;
using System.Linq;
using SmartCardReader.DataAccessLayer.Concrete;
using SmartCardReader.DataAccessLayer.Models;
using SmartCardReader.DataAccessLayer.Repository.Abstract;
using SmartCardReader.DataAccessLayer.Repository.Base;

namespace SmartCardReader.DataAccessLayer.Repository
{
    public class UniversityRepository : AbstractRepository<University>, IUniversityRepository
    {
        public UniversityRepository(EfDbContext context) : base(context)
        {
        }

        public IQueryable<UniversityModel> GetUniversitiesIdAndName()
        {
            return Context.Universities.Select(x => new UniversityModel {Id = x.Id, Name = x.Name});
        }

        public IQueryable<FacultyModel> GetFacultiesByUniversityId(int id)
        {
            throw new NotImplementedException();
        }
    }
}