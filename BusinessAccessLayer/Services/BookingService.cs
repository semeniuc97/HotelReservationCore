﻿using DataAccessLayer;
using DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BusinessAccessLayer.Services.Interfaces;

namespace BusinessAccessLayer.Services
{
    public class BookingService : IBookingService
    {
        HotelContext _hotelContext;

        public BookingService()
        {

        }

        public BookingService(HotelContext hotelContext)
        {
            _hotelContext = hotelContext;
        }

        public Booking Delete(int id)
        {
            var booking = new Booking() { Id = id };
            _hotelContext.Entry(booking).State = EntityState.Deleted;
            _hotelContext.SaveChanges();
            return booking;
        }

        public Booking Add(Booking booking)
        {
            _hotelContext.Bookings.Add(booking);
            _hotelContext.SaveChanges();
            return booking;
        }

        public List<BookingDetails> GetAllByRoomId(int roomId)
        {
            return _hotelContext.Bookings
                .Include(x => x.Room)
                .Include(x => x.User)
                .Where(x => x.RoomId == roomId)
                .Select(x => new BookingDetails
                {
                    Id = x.Id,
                    UserName = x.User.UserName,
                    Email = x.User.Email,
                    EndDate = x.EndDate,
                    StartDate = x.StartDate,
                    Price = x.Room.Price
                }).ToList();
            //.Where(x => x.RoomId == roomId)
            //.Include(x => x.Room)
            //.Include(x => x.User)
            //.ToList();
        }

        public List<Booking> GetRoomReservationsByDatesRange(DateTime StartDate, DateTime EndDate)
        {
            return _hotelContext.Bookings
                .Include(x => x.Room.Hotel)
                .Where(x => x.StartDate >= StartDate && x.EndDate <= EndDate)
                .ToList();
        }

        public List<RoomBookings> GetRoomBookingsRating(List<Booking> bookings)
        {
            var roombookings = bookings.GroupBy(x => new { x.Room.Number, x.Room.Hotel.HotelName })
                .Select(y => new RoomBookings { HotelName = y.Key.HotelName, RoomNumber = y.Key.Number, CountBookings = y.Count() })
                .OrderByDescending(x => x.CountBookings)
                .ToList();

            return roombookings;
        }
    }
}
