using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SmartCardReader.WebUI.ViewModels
{
    public class StudentViewModel
    {
        [Required]
        [Display(Name = "Index number")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

//        [Required]
        [Display(Name = "University")]
        public string University { get; set; }

//        [Required]
        [Display(Name = "Faculty")]
        public string Faculty { get; set; }


        public List<string> Majors { get; set; }
        public List<string> Classes { get; set; }
        
        
        public List<SelectListItem> UniversitieSelectListItems { get; set; }
        public List<SelectListItem> FacultiesSelectListItems { get; set; }
        public List<SelectListItem> MajorsSelectListItems { get; set; }
    }
}