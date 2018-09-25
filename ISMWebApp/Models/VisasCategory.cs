using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISMWebApp.Models
{
    [Table("visascategory")]
    public class VisasCategory
    {
        [Key]
        [Column("visaurl")]
        public string VisaUrl { get; set; }
        [Required]
        [Column("title")]
        public string Title { get; set; }
        [Required]
        [Column("description")]
        public string Description { get; set; }
        [Required]
        [Column("imgurl")]
        public string ImgUrl { get; set; }
        [Required]
        [Column("isdeleted")]
        public bool IsDeleted { get; set; }        
        public VisasPage VisasPage { get; set; }
    }
}