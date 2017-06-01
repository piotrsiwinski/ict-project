using System.Collections.Generic;
using SmartCardReader.DataAccessLayer.Models;

namespace SmartCardReader.WebUI.ViewModels
{
    public class CourseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Class> Classes { get; set; }
    }
}