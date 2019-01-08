using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessAccessLayer.Services.Interfaces
{
    public interface IBookedDatesService
    {
        List<DateTime> GetAllBookedDays(List<Booking> bookings);
        bool CheckIsBookedDates(DateTime StartDate, DateTime EndDate, List<DateTime> bookedDates);
        List<DateTime> GetBookingDatesRange(DateTime StartDate, DateTime EndDate);
    }
}
