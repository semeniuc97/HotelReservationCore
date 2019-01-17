using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessAccessLayer.Services;
using BusinessAccessLayer.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WebApi.ApiControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private IRoomService _roomService;

        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpPost]
        public Room Add([FromBody] Room room)
        {
            return _roomService.Add(room);
        }

        [HttpGet("{id}")]
        public ActionResult<Room> Get(int id)
        {
            return _roomService.GetById(id);
        }

        [HttpGet("{hotelId}")]
        public ActionResult<IEnumerable<Room>> GetByHotelId(int hotelid)
        {
            return _roomService.GetAllByHotelId(hotelid);
        }

        // PUT: api/Rooms/5
        [HttpPut("{id}")]
        public Room Update(int id, [FromBody] Room room)
        {
            return _roomService.Update(id,room);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public Room Delete(int id)
        {
            return _roomService.Delete(id);
        }
    }
}
