using System;
using System.Collections.Generic;


namespace BlazorApp.Model
{
    public class BlazorRoom
    {
        public int id { get; set; }
        public string RoomName { get; set; } = string.Empty;
         
        public double price { get; set; }

        public bool isActive { get; set; }

        public string valid { get; set; } = "is Available";
        public string inValid { get; set; } = " is Unavailable";
        public List<BlazorRoomProp> RoomProps { get; set; }
    }
}
