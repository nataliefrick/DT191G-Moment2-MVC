using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace DT191G_M2_MVC.Models
{
    public class PortfolioModel
    {
        // properties
        [Required(ErrorMessage = "Please give a correct title.")]
        //[Display(Name = "Project Name")]  changes the name of the label shown to users
        [Display(Name = "Project Name", Prompt = "Project Name")]
        public string? Title { get; set; }
        
        [Required]
        [Display(Name = "Description", Prompt = "Project description")]
        public string? Description { get; set; }
        
        
        [Required(ErrorMessage = "Please give a correct URL for the portfolio item.")]
        [Display(Name = "URL Link to project", Prompt = "URL Link to project")]
        [Url]   //[Phone][EmailAddress] : other options
        public string? Link { get; set; }

        //[MaxLength(2)][MinLength(1)]  // can limit size of input to nr. characters

        [DefaultValue("mockup.jpg")] // does not work, used a conditional statement instead
        [Display(Name = "Image filename", Prompt = "Image file name (can be blank)")]
        public string? ImgLink { get; set; }
        public string? Keywords { get; set; }
        public string? Year { get; set; }

        public string? Grade { get; set; }

    }
}
