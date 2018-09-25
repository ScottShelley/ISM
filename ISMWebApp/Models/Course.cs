using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISMWebApp.Models
{
    [Table("courses")]
    public class Course
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [Column("name")]
        [Display(Name = "Course Name")]
        public string Name { get; set; }
        [Required]
        [MaxLength(30)]
        [Column("level")]
        [Display(Name = "Course Level/Qualification")]
        public string Level { get; set; }
        [Required]
        [MaxLength(10)]
        [Column("code")]
        [Display(Name = "Course Code")]
        public string Code { get; set; }
        [Required]
        [Column("description")]
        public string Description { get; set; }
        [Column("overview")]
        public string Overview { get; set; }
        [Column("entryrequirements")]
        [Display(Name = "Entry Requirements")]
        public string EntryRequirements { get; set; }
        [Column("careers")]
        public string Careers { get; set; }
        [Required]
        [Column("imgurl")]
        [Display(Name = "Image URL")]
        public string ImgUrl { get; set; }
        [Required]
        [Column("isdeleted")]
        public bool IsDeleted { get; set; }
        public List<CourseInstitute> CourseInstitute { get; set; }
    }
}