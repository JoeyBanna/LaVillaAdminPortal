using Models;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models
{
    public class HotelAmenityDTO
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Enter amenity name")]
        public string Name { get; set; }

        public string Description { get; set; }
        [Required(ErrorMessage = "Enter duration")]
        public string Timing { get; set; }

        public string IconStyle { get; set; }


    }
    public class HotelAmenityDT
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

        public string Id { get; set; }

        [Required(ErrorMessage = "Enter amenity name")]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "Enter duration")]
        public string Timing { get; set; }
        public DateTime DateCreated { get; set; }
        public object CreatedBy { get; set; }
        public DateTime DateModified { get; set; }
        public object UpdatedBy { get; set; }
        public string IconStyle { get; set; }



    }
}
