using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISMWebApp.Models
{
    [Table("image")]
    public class Images
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [Column("name")]
        [Display(Name = "Image Name")]
        public string Name { get; set; }
        [Required]
        [Column("key")]
        public string Key { get; set; }
        [Required]
        [Column("url")]
        [Display(Name = "Image URL")]
        public string URL { get; set; }
        [Required]
        [Column("isdeleted")]
        public bool IsDeleted { get; set; }
        
    }
}