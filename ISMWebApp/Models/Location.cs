using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISMWebApp.Models
{
    [Table("locations")]
    public class Location
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [Column("name")]
        [Display(Name = "Location Name")]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        [Column("latitude")]
        [Display(Name = "Location Latitude")]
        public string Latitude { get; set; }
        [Required]
        [MaxLength(50)]
        [Column("longitude")]
        [Display(Name = "Location Longitude")]
        public string Longitude { get; set; }
        [Required]
        [MaxLength(50)]
        [Column("street")]
        public string Street { get; set; }
        [Required]
        [MaxLength(30)]
        [Column("suburb")]
        public string Suburb { get; set; }
        [Column("postcode")]
        [Required]
        [Display(Name = "Post Code")]
        [MaxLength(5)]
        public string PostCode { get; set; }
        [Required]
        [MaxLength(30)]
        [Column("state")]
        public string State { get; set; }
        [Required]
        [MaxLength(30)]
        [Column("country")]
        public string Country { get; set; }
        [Required]
        [Column("isdeleted")]
        public bool IsDeleted { get; set; }
        [Required]
        [Display(Name = "Institute")]
        [Column("instituteid")]
        public int InstituteId { get; set; }
        public Institute Institute { get; set; }
        public List<CourseLocation> CourseLocations { get; set; }
    }
}