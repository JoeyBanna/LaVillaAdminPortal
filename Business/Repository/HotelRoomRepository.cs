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
    public class HotelRoomRepository : IHotelRoomRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public HotelRoomRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;  
            _mapper = mapper;   

        }
        public async Task<HotelRoomDTO> CreateHotelRoom(HotelRoomDTO hotelRoomDTO)
        {
            try
            {
                var hotelRoom = _mapper.Map<HotelRoom>(hotelRoomDTO);
                hotelRoom.CreatedDate = DateTime.Now;
                hotelRoom.CreatedBy = "";

                var addedHotelRoom = await _db.HotelRooms.AddAsync(hotelRoom);
                await _db.SaveChangesAsync();
                return _mapper.Map<HotelRoom, HotelRoomDTO>(addedHotelRoom.Entity);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public Task<HotelRoomDT> CreateHotelRoom(HotelRoomDT hotelRoomDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<string> DeleteHotelRoom(string roomId)
        {
            var roomDetails = await _db.HotelRooms.FindAsync(roomId);
            if (roomDetails != null)
            {
                var allImages = await _db.HotelRoomImages.Where(x => x.RoomId == roomId).ToListAsync();
                

                _db.HotelRoomImages.RemoveRange(allImages);

                _db.HotelRooms.Remove(roomDetails);
                
            }
            return null;
        }


        public async Task<IEnumerable<HotelRoomDT>> GetAllHotelRoom()
        {
            try
            {
                var response =  await _db.HotelRooms.ToListAsync();
                var hotelRoomDTOs =_mapper.Map<IEnumerable<HotelRoomDT>>(response) ;
                return hotelRoomDTOs;    
            }
            catch(Exception ex) 
            {
                return null;
            }
        }

        public async Task<HotelRoomDT> GetHotelRoom(string roomId)
        {
            try
            {
                HotelRoomDT hotelRoom = _mapper.Map<HotelRoom, HotelRoomDT>(await _db.HotelRooms.Include(x=> x.HotelRoomImages).FirstOrDefaultAsync(x => x.Id == roomId));
                return hotelRoom;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<HotelRoomDT> HotelRoomNameAlreadyExist(string name, string roomId=null)
        {
            try
            {
                if(roomId == null)
                {
                    var resp = await _db.HotelRooms.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());
                    if (resp != null)
                    {
                        HotelRoomDT hotelRoom = _mapper.Map<HotelRoom, HotelRoomDT>(resp);
                        return hotelRoom;
                    }
                    return null;

                }
                else
                {
                    HotelRoomDT hotelRoom = _mapper.Map<HotelRoom, HotelRoomDT>(await _db.HotelRooms.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower() && x.Id != roomId));
                    return hotelRoom;
                }
              
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<HotelRoomDT> UpdateHotelRoom(string roomId, HotelRoomDT hotelRoomDTO)
        {
            try
            {
                if (roomId == hotelRoomDTO.id)
                {
                    HotelRoom roomDetails = await _db.HotelRooms.FindAsync(roomId);
                    HotelRoom room =_mapper.Map<HotelRoomDT, HotelRoom>(hotelRoomDTO, roomDetails);
                    room.UpdatedBy = " ";
                    room.UpdatedDate=DateTime.Now;
                    var updatedRoom = _db.HotelRooms.Update(room);
                    await _db.SaveChangesAsync();
                    return _mapper.Map<HotelRoom, HotelRoomDT>(updatedRoom.Entity);

                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                return null;
            }
          
        }

       
    }
}
