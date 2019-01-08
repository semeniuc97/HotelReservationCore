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
    public class RoomService : IRoomService
    {
        private HotelContext _hotelContext;

        public RoomService(HotelContext hotelContext)
        {
            _hotelContext = hotelContext;
        }

        public RoomService()
        {

        }

        public Room Add(Room room)
        {
            _hotelContext.Rooms.Add(room);
            _hotelContext.SaveChanges();
            return room;
        }

        public Room Delete(int id)
        {
            var room = new Room() { Id = id };
            _hotelContext.Entry(room).State = EntityState.Deleted;
            _hotelContext.SaveChanges();
            return room;
        }

        public Room Update(int id,Room room)
        {
            room.Id = id;
            _hotelContext.Attach<Room>(room).State = EntityState.Modified;
            _hotelContext.SaveChanges();
            return room;
        }

        public Room GetById(int id)
        {
            return _hotelContext.Rooms.AsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }

        public List<Room> GetAllByHotelId(int hotelId)
        {
            return _hotelContext.Rooms
                .Where(x => x.HotelId == hotelId)
                .ToList();
        }
    }
}
