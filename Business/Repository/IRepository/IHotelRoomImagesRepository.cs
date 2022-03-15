using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.IRepository
{
    public interface IHotelRoomImagesRepository
    {
       // public Task<int> CreateHotelRoomImage(HotelRoomImageDT image);
        public Task<int> DeleteHotelRoomImageID(string imageId);
        public Task<int> DeleteHotelRoomImageByRoomID(string roomId);
        public Task<int> DeleteHotelImageByImageURL(string imageUrl);
        //public Task<IEnumerable<HotelRoomImageDTO>> GetHotelRoomImages(string RoomId);
    }
}
