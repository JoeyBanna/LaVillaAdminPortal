using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class HotelRoomImage
    {
        public string Id { get; set; }
        public string RoomId { get; set; }
        public string RoomImageUrl { get; set; } = null!;

        public virtual HotelRoom Room { get; set; } = null!;
    }
}
