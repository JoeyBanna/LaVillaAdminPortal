using AutoMapper;
using Business.Repository.IRepository;
using DataAccess.Data;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository
{
    public class HotelImagesRepository:IHotelRoomImagesRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public HotelImagesRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;

        }

        //public async Task<int> CreateHotelRoomImage(HotelRoomImageDT imageDTO)
        //{
        //    var image = _mapper.Map<HotelRoomImage>(imageDTO);
        //   await _db.HotelRoomImages.AddAsync(image);
        //    return await _db.SaveChangesAsync();
        //}

        public async Task<int> DeleteHotelImageByImageURL(string imageUrl)
        {
            var allImages = await _db.HotelRoomImages.FirstOrDefaultAsync(x => x.RoomImageUrl.ToLower() == imageUrl.ToLower());
            if (allImages == null)
            {
                return 0;
            }
            _db.HotelRoomImages.Remove(allImages);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> DeleteHotelRoomImageByRoomID(string roomId)
        {

            var imageList = await _db.HotelRoomImages.Where(x => x.RoomId == roomId).ToListAsync();
            _db.HotelRoomImages.RemoveRange(imageList);
            return await _db.SaveChangesAsync();


        }

        
        public async Task<int> DeleteHotelRoomImageID(string imageId)
        {
            var image = await _db.HotelRoomImages.FindAsync(imageId);
            _db.HotelRoomImages.Remove(image);
            return await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<HotelRoomImageDT>> GetHotelRoomImages(string RoomId)
        {
            var response = await _db.HotelRoomImages.Where(x => x.RoomId == RoomId).ToListAsync();
            return _mapper.Map<IEnumerable<HotelRoomImageDT>>(response);   
        }

      

        //Task<IEnumerable<HotelRoomImageDTO>> IHotelRoomImagesRepository.GetHotelRoomImages(string RoomId)
        //{
        //    throw new NotImplementedException();
        //}
    }
}

