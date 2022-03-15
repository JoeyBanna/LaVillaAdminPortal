using BlazorApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.IRepository
{
    public interface IHotelRoomRepository
    {
        public Task<HotelRoomDT> CreateHotelRoom(HotelRoomDT hotelRoomDTO);
        public Task<HotelRoomDT> UpdateHotelRoom(string roomId,HotelRoomDT hotelRoomDTO);
        public Task<HotelRoomDT> GetHotelRoom(string roomId);
        public Task<IEnumerable<HotelRoomDT>> GetAllHotelRoom();
        public Task<HotelRoomDT> HotelRoomNameAlreadyExist(string name, string roomId);
        public Task <string>DeleteHotelRoom(string roomId=null);
    }   
}
