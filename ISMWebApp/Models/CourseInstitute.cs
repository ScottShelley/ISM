using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISMWebApp.Models
{
    [Table("coursesinstitute")]
    public class CourseInstitute
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("courseid")]
        public int CourseId { get; set; }
        public Course Course { get; set; }
        [Key]
        [Column("institutionid")]
        public int InstitutionId { get; set; }
        public Institute Institute { get; set; }
        [Required]
        [Column("durationweeks")]
        [Display(Name = "Duration Weeks")]
        public int DurationWeeks { get; set; }
        [Column("tution", TypeName = "money")]
        public decimal? Tution { get; set; }
        [Column("nontution", TypeName = "money")]
        public decimal? NonTution { get; set; }
        [Required]
        [Column("total", TypeName = "money")]
        public decimal? Total { get; set; }
        [Required]
        [Column("isdeleted")]
        public bool IsDeleted { get; set; }

        public List<CourseLocation> CourseLocations { get; set; }
    }
}