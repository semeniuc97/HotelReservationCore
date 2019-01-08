using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessAccessLayer.Services;
using BusinessAccessLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using NLog;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class BookingsController : Controller
    {
        private IBookingService _bookingService;
        private IBookedDatesService _bookedDatesService;
        ILogger<BookingsController> _log;
        public BookingsController(IBookingService bookingService, IBookedDatesService bookedDatesService, ILogger<BookingsController> log)
        {
            _bookingService = bookingService;
            _bookedDatesService = bookedDatesService;
            _log = log;
           
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

        [HttpGet("{roomId}")]
        public ActionResult<IEnumerable<Booking>> GetAllByRoomId(int roomId)
        {
            return _bookingService.GetAllByRoomId(roomId);
        }

        [HttpGet("{startDate}/{endDate}")]
        public ActionResult<IEnumerable<RoomBookings>> GetRoomBookingsRating(DateTime startDate, DateTime endDate)
        {
            var logger = LogManager.GetCurrentClassLogger();
            var roomsRating = new List<RoomBookings>();

            try
            {
                var bookings = _bookingService.GetRoomReservationsByDatesRange(startDate, endDate);
                roomsRating = _bookingService.GetRoomBookingsRating(bookings);
                //_log.LogInformation($"The rating has been generated.Total rating`s count {roomsRating.Count}");
                logger.Info($"The rating has been generated.Total rating`s count {roomsRating.Count}");
            }
            catch (Exception ex)
            {
                logger.Error(ex,"Oops!I did it agian.");
            }
            return roomsRating;

        }

        [HttpGet("{roomId}")]
        public ActionResult<IEnumerable<DateTime>> GetBookedDays(int roomId)
        {
            var logger = LogManager.GetCurrentClassLogger();
            var bookedDates = new List<DateTime>();

            try
            {
                var bookings = _bookingService.GetAllByRoomId(roomId);
                bookedDates = _bookedDatesService.GetAllBookedDays(bookings);
                //_log.LogInformation($"{bookedDates.Count} new bookings have been added succesfully!");
                logger.Info($"{bookedDates.Count} new bookings have been added succesfully!");
                return bookedDates;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Oops,I did it again!");
            }

            return bookedDates;
        }





    }
}
