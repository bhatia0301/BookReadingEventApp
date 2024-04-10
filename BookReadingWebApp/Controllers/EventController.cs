using BookReadingApp.Application.Interfaces;
using BookReadingApp.Core.Modals;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace BookReadingApp.Web.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventRepository _eventPageService;
        private readonly ICommentRepository _commentPageService;

        public EventController(IEventRepository eventPageService, ICommentRepository commentPageService)
        {
            _eventPageService = eventPageService ?? throw new ArgumentNullException(nameof(eventPageService));
            _commentPageService = commentPageService ?? throw new ArgumentNullException(nameof(commentPageService));
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("Events")]
        public async Task<IActionResult> GetEvents()
        {
            var eventList = await _eventPageService.GetEvents();
            return View(eventList);
        }

        [Route("Events/{id}")]
        public async Task<IActionResult> ViewDetails(int? id)
        {
            var details = await _eventPageService.ViewDetails(id.Value);
            var ans = await _eventPageService.GetAllCommentByEventId(id.Value);
            details.Comments = ans;
            if (details == null)
            {
                return RedirectToAction("GetEvents");
            }
            return View(details);
        }

        [Authorize]
        [Route("CreateEvent")]
        public IActionResult CreateEvent()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [Route("CreateEvent")]

        public async Task<IActionResult> CreateEvent(Event eventViewModel)
        {
            var result = await _eventPageService.CreateEvent(eventViewModel);
            if (result > 0)
            {
                return RedirectToAction(nameof(CreateEvent));
            }
            return View();
        }

        [Authorize]
        [Route("UpdateEvent/{id}")]
        public async Task<IActionResult> UpdateEvent(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("GetEvents");
            }
            var ans = await _eventPageService.ViewDetails(id.Value);

            if (ans == null)
            {
                return RedirectToAction("GetEvents");
            }
            return View(ans);
        }

        [Authorize]
        [HttpPost]
        [Route("UpdateEvent/{id}")]

        public IActionResult UpdateEvent(Event eventViewModel)
        {
            var _id = _eventPageService.UpdateEvent(eventViewModel);
            if (_id > 0)
            {
                return RedirectToAction("ViewDetails", new { id = _id });
            }
            return View();
        }

        [Authorize]
        [Route("MyEvents")]
        public async Task<IActionResult> MyEvents()
        {
            var organiser = User.Identity.Name;
            var eventList = await _eventPageService.MyEvents(organiser);
            return View(eventList);
        }

        [Authorize]
        [Route("EventsInvitedTo")]
        public async Task<IActionResult> EventsInvitedTo()
        {
            var eventList = await _eventPageService.GetEvents();
            return View(eventList);
        }

        [Route("FetchComments/{_id}")]
        public async Task<IActionResult> GetAllCommentByEventId(int _id)
        {
            var ans = await _eventPageService.GetAllCommentByEventId(_id);
            if (ans == null)
            {
                return RedirectToAction("ViewDetails", new { id = _id });
            }
            return View(ans);
        }
    }
}
