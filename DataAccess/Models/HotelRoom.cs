using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public partial class HotelRoom
    {
        public HotelRoom()
        {
            HotelRoomImages = new HashSet<HotelRoomImage>();
        }

        [Key]
        public string Id { get; set; }
        [Required(ErrorMessage = "Please enter room name")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Please enter number of occupants")]
        public int Occupancy { get; set; }
        [Required(ErrorMessage ="Please enter room rate(price)")]
        public double RegularRate { get; set; }
       
        public string? Details { get; set; }
        public string? SqFt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public virtual ICollection<HotelRoomImage> HotelRoomImages { get; set; }
    }
}
