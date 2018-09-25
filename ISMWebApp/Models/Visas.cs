using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISMWebApp.Models
{
    [Table("visas")]
    public class Visas
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("title")]
        public string Title { get; set; }
        [Required]
        [Column("imgurl")]
        public string ImgUrl { get; set; }
        [Required]
        [Column("html")]
        public string Html { get; set; }
        [Required]
        [Column("isdeleted")]
        public bool IsDeleted { get; set; }
        [Required]
        [Column("visaspageid")]
        public int VisasPageId { get; set; }
        public VisasPage VisasPage { get; set; }
    }
}