using BlazorApp.ModelsModels;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Models
{
    public class CreateHotelRoomModel
    {
        public string Id { get; set; }
        public string name { get; set; }
        public int occupancy { get; set; }
        public int regularRate { get; set; }
        public string details { get; set; }
        public string sqFt { get; set; }
        public List<HotelRoomImage> hotelRoomImages { get; set; } = new List<HotelRoomImage>();
    }
    public class UpdateHotelRoomModel
    {

        public string name { get; set; }
        public int regularRate { get; set; }
        public int amountToPay { get; set; }
        public int occupancy { get; set; }
        public string details { get; set; }
        public string sqFt { get; set; }
        public string roomTypeId { get; set; }
        public List<HotelRoomImage> hotelRoomImages { get; set; }
    }
}
