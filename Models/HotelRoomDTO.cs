using BlazorApp.ModelsModels;
using Models;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models
{
    public class HotelRoomDTO
    {


        public string Id { get; set; }
        [Required(ErrorMessage = "Enter room name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter occupancy")]
        public int Occupancy { get; set; }
        [Range(1, 3000, ErrorMessage = "Rate must be between 1 and 3000")]
        public double RegularRate { get; set; }
        public string Details { get; set; }
        public string SqFt { get; set; }

        public virtual ICollection<HotelRoomImageDT> HotelRoomImages { get; set; }

        public List<string> ImageUrls { get; set; }
    }
    public class HotelRoomDT
    {

        public string id { get; set; }
        [Required(ErrorMessage = "Enter room name")]
        public string name { get; set; }
        [Required(ErrorMessage = "Enter occupancy")]
        public int occupancy { get; set; }
        [Range(1, 5000, ErrorMessage = "Rate must be between 1 and 3000")]
        public int regularRate { get; set; }
        public string details { get; set; }
        public string sqFt { get; set; }
        public object createdBy { get; set; }
        public DateTime createdDate { get; set; }
        public object updatedBy { get; set; }
        public DateTime updatedDate { get; set; }
        public virtual List<HotelRoomImage> HotelRoomImages { get; set; }
        public List<string> ImageUrls { get; set; }

    }
    public class UpdateRoom
    {
        public string id { get; set; }
        public string name { get; set; }
        public int regularRate { get; set; }
        public int amountToPay { get; set; }
        public int occupancy { get; set; }
        public string details { get; set; }
        public string sqFt { get; set; }
        public string roomTypeId { get; set; }
        public List<HotelRoomImage> hotelRoomImages { get; set; }
        public List<string> ImageUrls { get; set; }
    }
    
}
