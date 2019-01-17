using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("[controller]/[action]")]
    public class HomePageController : Controller
    {
        public IActionResult MainPage()
        {
            return View();
        }
    }
}