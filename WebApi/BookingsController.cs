using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessAccessLayer.Services;
using BusinessAccessLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class BookingsController : Controller
    {
        private IBookingService _bookingService;
        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost]
        public Booking Add([FromBody]Booking booking)
        {
            return _bookingService.Add(booking);
        }

        [HttpDelete("{id}")]
        public Booking Delete(int id)
        {
            return _bookingService.Delete(id);
        }

        [HttpGet]
        public IEnumerable<Booking> GetAllByRoomId(int roomId)
        {
            return _bookingService.GetAllByRoomId(roomId);
        }

        
        [HttpGet]
        public IEnumerable<RoomBookings> GetRoomBookingsRating(DateTime startDate, DateTime endDate)
        {
            var bookings = _bookingService.GetRoomReservationsByDatesRange(startDate, endDate);
            return _bookingService.GetRoomBookingsRating(bookings);
        }

        
    }
}
