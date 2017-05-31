using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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


        public List<string> Majors { get; set; }
        public List<string> Classes { get; set; }
    }
}