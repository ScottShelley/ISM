using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISMWebApp.Models
{
    [Table("institutes")]
    public class Institute
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        [Column("provider")]
        public string Provider { get; set; }
        [MaxLength(40)]
        [Column("institutename")]
        public string InstituteName { get; set; }
        [Required]
        [Column("isdeleted")]
        public bool IsDeleted { get; set; }
        [Required]
        [Column("description")]
        public string Description { get; set; }
        [Required]
        [MaxLength(50)]
        [Column("imgurl")]
        public string ImgUrl { get; set; }
        public List<CourseInstitute> CourseInstitute { get; set; }

        public List<Location> Locations { get; set; }
    }
}