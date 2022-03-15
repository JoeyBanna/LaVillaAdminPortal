using AutoMapper;
using BlazorApp.Models;
using Business.Repository.IRepository;
using DataAccess.Data;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository
{
    public class HotelAmenityRepository : IHotelAmenityRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public HotelAmenityRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;

        }

        public async Task<HotelAmenityDTO> CreateHotelAmenity(HotelAmenityDTO hotelAmenityDTO)
        {
            var amenity = _mapper.Map<HotelAmenityDTO, HotelAmenity>(hotelAmenityDTO);
            amenity.CreatedBy = "";
            amenity.CreatedDate = DateTime.UtcNow;
            var addedHotelAmenity = await _db.HotelAmenitys.AddAsync(amenity);
            await _db.SaveChangesAsync();
            return _mapper.Map<HotelAmenity, HotelAmenityDTO>(addedHotelAmenity.Entity);
        }

        public async Task<int> DeleteHotelAmenity(int amenityId)
        {
            var amenityDetails = await _db.HotelAmenitys.FindAsync(amenityId);
            if (amenityDetails != null)
            {
                _db.HotelAmenitys.Remove(amenityDetails);
                return await _db.SaveChangesAsync();
            }
            return 0;

        }

        public async Task<IEnumerable<HotelAmenityDTO>> GetAllHotelAmenity()
        {
            var response = await _db.HotelAmenitys.ToListAsync();
             IEnumerable<HotelAmenityDTO> hotelAmenityDTOs =_mapper.Map<IEnumerable<HotelAmenity>, IEnumerable<HotelAmenityDTO>>(response) ;
                return hotelAmenityDTOs;
        }

        public async Task<HotelAmenityDTO> GetHotelAmenity(int amenityId)
        {
            var amenityData = await _db.HotelAmenitys.FirstOrDefaultAsync(x => x.Id == amenityId);

            if (amenityData == null)
            {
                return null;
            }
            return _mapper.Map<HotelAmenity, HotelAmenityDTO>(amenityData);
        }

        public async Task<HotelAmenityDTO> HotelAmenityNameAlreadyExist(string name)
        {
            try
            {
                var amenityDetails = await _db.HotelAmenitys.FirstOrDefaultAsync(x => x.Name.ToLower().Trim() == name.ToLower().Trim());
                if (amenityDetails != null)
                {
                    return _mapper.Map<HotelAmenity, HotelAmenityDTO>(amenityDetails);

                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<HotelAmenityDTO> UpdateHotelAmenity(int amenityId, HotelAmenityDTO hotelAmenityDTO)
        {

            var amenityDetails = await _db.HotelAmenitys.FindAsync(amenityId);

            var amenity = _mapper.Map<HotelAmenityDTO, HotelAmenity>(hotelAmenityDTO, amenityDetails);
            amenity.Id = amenityId;
            amenity.UpDatedBy = "";
            amenity.UpdatedDate = DateTime.UtcNow;
            var updatedamenity = _db.HotelAmenitys.Update(amenity);
            await _db.SaveChangesAsync();
            return _mapper.Map<HotelAmenity, HotelAmenityDTO>(updatedamenity.Entity);

        }
      

       
    }
}
