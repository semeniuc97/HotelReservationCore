using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessAccessLayer.Services;
using BusinessAccessLayer.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using NLog;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private IBookingService _bookingService;
        private IBookedDatesService _bookedDatesService;
        ILoggerManager _log;
        ILogger<BookingsController> _logger;
        public BookingsController(IBookingService bookingService, IBookedDatesService bookedDatesService,
            ILoggerManager log, ILogger<BookingsController> logger)
        {
            _bookingService = bookingService;
            _bookedDatesService = bookedDatesService;
            _log = log;
            _logger = logger;
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

        [Authorize]
        [HttpGet("{roomId}")]
        public ActionResult<IEnumerable<BookingDetails>> GetAllByRoomId(int roomId)
        {
            return _bookingService.GetAllByRoomId(roomId);
           
        }

        [HttpGet("{startDate}/{endDate}")]
        public ActionResult<IEnumerable<RoomBookings>> GetRoomBookingsRating(DateTime startDate, DateTime endDate)
        {
            var roomsRating = new List<RoomBookings>();

            try
            {
                var bookings = _bookingService.GetRoomReservationsByDatesRange(startDate, endDate);
                roomsRating = _bookingService.GetRoomBookingsRating(bookings);
                //_logger.LogInformation($"The rating has been generated.Total rating`s count {roomsRating.Count}");
                _log.LogInfo($"The rating has been generated.Total rating`s count {roomsRating.Count}");
                return roomsRating;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception while fetching all the bookigns from the storage.");
            }
        }

        [HttpGet("{roomId}")]
        public ActionResult<IEnumerable<DateTime>> GetBookedDays(int roomId)
        {
            var bookedDates = new List<DateTime>();
            try
            {
                var bookings = _bookingService.GetAllByRoomId(roomId);
                bookedDates = _bookedDatesService.GetAllBookedDays(bookings);
                //_logger.LogInformation($"{bookedDates.Count} new bookings have been added succesfully!");
                _log.LogInfo($"{bookedDates.Count} new bookings have been added succesfully!");
                return bookedDates;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception while fetching all the bookigns from the storage.");
            }
            //return bookedDates;
        }

    }
}
