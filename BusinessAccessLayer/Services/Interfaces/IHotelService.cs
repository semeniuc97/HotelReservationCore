using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessAccessLayer.Services.Interfaces
{
   public interface IHotelService
    {
        Hotel Add(Hotel hotel);
        Hotel Delete(int id);
        Hotel Update(int id, Hotel hotel);
        Hotel Get(int id);
        List<Hotel> GetAll();
    }
}
