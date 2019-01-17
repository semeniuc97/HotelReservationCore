using BusinessAccessLayer.Services.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessAccessLayer.Services
{
    public class BookedDatesService : IBookedDatesService
    {
        public BookedDatesService()
        {

        }

        public virtual List<DateTime> GetAllBookedDays(List<BookingDetails> bookings)
        {
            var roomAllBookedDays = new List<DateTime>();
            foreach (var booking in bookings)
            {
                roomAllBookedDays.AddRange(GetBookingDatesRange(booking.StartDate, booking.EndDate));
            }

            return roomAllBookedDays;
        }

        public virtual bool CheckIsBookedDates(DateTime StartDate, DateTime EndDate, List<DateTime> bookedDates)
        {
            if (bookedDates.Contains(StartDate) || bookedDates.Contains(EndDate))
            {
                return false;
            }
            else
                return true;
        }

        public virtual List<DateTime> GetBookingDatesRange(DateTime StartDate, DateTime EndDate)
        {
            var bookedDate = StartDate;
            var bookedDates = new List<DateTime>()
            {
                StartDate,
                EndDate
            };

            if ((EndDate.Date - bookedDate.Date).TotalDays == 1)
            {
                return bookedDates;
            }

            while ((EndDate.Date - bookedDate.Date).TotalDays != 1)
            {
                bookedDate = bookedDate.AddDays(1);
                bookedDates.Add(bookedDate);
            }
            return bookedDates;
        }
    }
}
