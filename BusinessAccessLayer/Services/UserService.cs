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
   public class UserService:IUserService
    {
        HotelContext _hotelContext;
        public UserService(HotelContext hotelContext)
        {
            _hotelContext = hotelContext;
        }

        public List<User> GetAll()
        {
            return _hotelContext.Users.ToList();
        }
    }
}
