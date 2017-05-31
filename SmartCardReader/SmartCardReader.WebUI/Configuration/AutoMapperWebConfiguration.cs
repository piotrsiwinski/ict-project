using AutoMapper;
using SmartCardReader.ServiceLayer.Configuration.AutoMapperProfiles;
using StudentProfile = SmartCardReader.WebUI.Configuration.Profiles.StudentProfile;

namespace SmartCardReader.WebUI.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<StudentProfile>();
                cfg.AddProfile<ClassProfile>();
                cfg.AddProfile<ServiceLayer.Configuration.AutoMapperProfiles.StudentProfile>();
            });
        }
    }
}