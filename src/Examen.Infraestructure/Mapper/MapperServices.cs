using AutoMapper;
using Examen.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Infraestructure.Mapper
{
    public class MapperServices : Profile
    {
        public MapperServices() 
        {
            CreateMap<CustomerDTO, CustomerEntity>();
            CreateMap<CustomerEntity, CustomerDTO>();

            CreateMap<MovieDTO, MovieEntity>();
            CreateMap<MovieEntity, MovieDTO>();

            CreateMap<BillboardDTO, BillboardEntity>();
            CreateMap<BillboardEntity, BillboardDTO>();

            CreateMap<BookingDTO, BookingEntity>();
            CreateMap<BookingEntity, BookingDTO>();

            CreateMap<RoomDTO, RoomEntity>();
            CreateMap<RoomEntity, RoomDTO>();

            CreateMap<SeatDTO, SeatEntity>();
            CreateMap<SeatEntity, SeatDTO>();

            CreateMap<BaseDTO, BaseEntity>();
            CreateMap<BaseEntity, BaseDTO>();
        }
    }
}
