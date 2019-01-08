﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessAccessLayer.Services;
using BusinessAccessLayer.Services.Interfaces;
using DataAccessLayer.Context;
using Microsoft.AspNetCore.Mvc;
using Models;
using NLog;
using NLog.Web;
using Microsoft.Extensions.Logging;
 

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private IHotelService _hotelService;
        private readonly ILogger<HotelsController> _logger;

        public HotelsController(IHotelService hotelService, ILogger<HotelsController> logger)
        {
            _hotelService = hotelService;
            _logger=logger;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Hotel>> Get()
        {



            return _hotelService.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Hotel> Get(int id)
        {
            return _hotelService.Get(id);
        }

        // POST api/values
        [HttpPost]
        public Hotel Add([FromBody] Hotel hotel)
        {
            return _hotelService.Add(hotel);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public Hotel Put(int id, [FromBody] Hotel hotel)
        {
           return  _hotelService.Update(id,hotel);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public Hotel Delete(int id)
        {
            return _hotelService.Delete(id);
        }
    }
}
