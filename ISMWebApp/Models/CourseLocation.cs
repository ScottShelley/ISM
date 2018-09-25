using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISMWebApp.Models
{
    [Table("courselocations")]
    public class CourseLocation
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("locationid")]
        [Required]
        [Display(Name = "Location Id")]
        public int LocationId { get; set; }
        public Location Location { get; set; }
        [Column("courseinstituteid")]
        [Display(Name = "Course Institute Id")]
        [Required]
        public int CourseInstituteId { get; set; }
        public CourseInstitute CourseInstitute { get; set; }
        [Required]
        [Column("isdeleted")]
        public bool IsDeleted { get; set; }
    }
}