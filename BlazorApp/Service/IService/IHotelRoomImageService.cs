using Models;

namespace BlazorApp.Service.IService
{
    public interface IHotelRoomImageService
    {
        public Task<HotelRoomImageDT> CreateHotelRoomImage(HotelRoomImageDT image);
        public Task<HotelRoomImageDT> DeleteHotelRoomImageID(string imageId);
        public Task<HotelRoomImageDT> DeleteHotelImageByImageURL(string imageName);
        public Task<IEnumerable<HotelRoomImageDT>> GetHotelRoomImages(string RoomId);
    }
}
