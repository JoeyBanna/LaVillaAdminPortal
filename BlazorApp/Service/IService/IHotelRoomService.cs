using BlazorApp.Models;
using Models;

namespace BlazorApp.Service
{
    public interface IHotelRoomService
    {
        public Task<HotelRoomDT> GetHotelRoomById(string id);
        public Task<IEnumerable<HotelRoomDT>> GetHotelRoomsFromApi(string accessToken);
        public Task <HotelRoomDT>DeleteHotelRoom(string id);
        public Task<HotelRoomDT> CreateHotelRoom(HotelRoomDT hotelRoomDTO);
        public Task<HotelRoomDT> CreateHotelRoomModel(CreateHotelRoomModel hotelRoomDTO);
        public Task<HotelRoomDT> UpdateHotelRoom(string roomId, CreateHotelRoomModel hotelRoomDTO);
        public Task<IEnumerable<RoomTypes>> GetRoomTypes();
    }
}
