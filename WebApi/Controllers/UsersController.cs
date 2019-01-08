using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessAccessLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UsersController : Controller
    {
        private IUserService _userService;
        UsersController(IUserService userService)
        {
            _userService = userService;
        }

        UsersController()
        {

        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            return _userService.GetAll();
        }

        
    }
}
