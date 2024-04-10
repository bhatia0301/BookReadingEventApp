using BookReadingApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BookReadingApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEventRepository _eventPageService;
        public HomeController(IEventRepository eventPageService)
        {
            _eventPageService = eventPageService;
        }

        [Route("")]
        public async Task<IActionResult> Index()
        {
            var eventList = await _eventPageService.GetEvents();
            return View(eventList);
        }

        [Route("Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [Route("customer-support")]

        public IActionResult CustomerSupport()
        {
            return Redirect("https://www.nagarro.com/en/contact-us");
        }
    }
}
