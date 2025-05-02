using BookReadingApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
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
    }
}
