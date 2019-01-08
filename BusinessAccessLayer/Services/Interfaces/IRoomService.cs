using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessAccessLayer.Services.Interfaces
{
    public interface IRoomService
    {
        Room Add(Room room);
        Room Delete(int id);
        Room Update(int id, Room room);
        Room GetById(int id);
        List<Room> GetAllByHotelId(int hotelId);
    }
}
