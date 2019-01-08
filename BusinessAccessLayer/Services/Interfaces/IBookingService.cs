using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessAccessLayer.Services.Interfaces
{
    public interface IBookingService
    {
        Booking Delete(int id);
        Booking Add(Booking booking);
        List<Booking> GetAllByRoomId(int roomId);
        List<Booking> GetRoomReservationsByDatesRange(DateTime StartDate, DateTime EndDate);
        List<RoomBookings> GetRoomBookingsRating(List<Booking> bookings);
    }
}
