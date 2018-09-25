using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ISMWebApp.ViewModels
{
    public class ImageViewModel
    {
        [Required]
        [Display(Name = "Image Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Image / File")]
        public IFormFile Image { get; set; }
    }
}