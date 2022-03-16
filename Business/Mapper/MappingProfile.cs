﻿using AutoMapper;
using BlazorApp.Models;
using DataAccess.Data;
using DataAccess.Models;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<HotelRoomDTO, HotelRoom>();
            CreateMap<HotelRoom, HotelRoomDTO>();
            CreateMap<HotelAmenity, HotelAmenityDTO>();
            CreateMap<HotelAmenityDTO, HotelAmenity>();
            //CreateMap<HotelRoomImage, HotelRoomImageDTO>().ReverseMap();
        }
        

    }
}