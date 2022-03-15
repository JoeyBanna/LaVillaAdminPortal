using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public partial class HotelAmenity
    {
       [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter amenity name")]
        public string Name { get; set; }
        
        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter the appropriate Time")]
        public string Timing { get; set; }
        [Required(ErrorMessage = "Please enter amenity Icon using Font Awesome")]
        public string IconStyle { get; set; } 
        public string? CreatedBy { get; set; }
        public string? UpDatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
