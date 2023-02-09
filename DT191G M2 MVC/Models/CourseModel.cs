using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations; // requires that all form fields are filled in

namespace DT191G_M2_MVC.Models
{
    public class CourseModel
    {
        // properties
        [Required(ErrorMessage = "Please give correct course code.")]
        [Display(Name = "Course Code")] // changes the name of the label shown to users
        public string? Kurskod { get; set; }
        [Required]
        public string? Namn { get; set; }
        [Required(ErrorMessage = "Please give a correct URL for the course syllabus.")]
        [Url]   //[Phone][EmailAddress] : other options
        public string? Kursplan { get; set; }
        [Required]
        [MaxLength(2)]
        [MinLength(1)]
        public string? Progression { get; set; }

    }
}
