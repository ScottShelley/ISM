using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISMWebApp.Models
{
    [Table("visaspage")]
    public class VisasPage
    {
        [Key]
        [Column("url")]
        public string Url { get; set; }
        [Key]
        [Column("id")]
        public int Id { get; set; }
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
        [Column("visascategory")]
        public VisasCategory VisasCategory { get; set; }

        public List<Visas> Visas { get; set; }
    }
}