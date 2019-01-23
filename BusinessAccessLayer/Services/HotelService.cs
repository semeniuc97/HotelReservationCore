using DataAccessLayer.Context;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BusinessAccessLayer.Services.Interfaces;

namespace BusinessAccessLayer.Services
{
    public class HotelService : IHotelService
    {
        private HotelContext _hotelContext;

        public HotelService(HotelContext hotelContext)
        {
            _hotelContext = hotelContext;
        }

        public HotelService()
        {
        }

        public Hotel Add(Hotel hotel)
        {
            _hotelContext.Hotels.Add(hotel);
            _hotelContext.SaveChanges();
            return hotel;
        }

        public Hotel Delete(int id)
        {
            var hotel = new Hotel() { Id = id };
            _hotelContext.Entry(hotel).State = EntityState.Deleted;
            _hotelContext.SaveChanges();
            return hotel;
        }

        public Hotel Update(int id,Hotel hotel)
        {
            hotel.Id = id;
            _hotelContext.Attach(hotel).State = EntityState.Modified;
            _hotelContext.SaveChanges();
            return hotel;
        }

        public Hotel Get(int id)
        {
            return _hotelContext.Hotels.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Hotel> GetAll()
        {
            return _hotelContext.Hotels.Include(x=>x.Rooms).AsNoTracking().ToList();
        }
    }
}
