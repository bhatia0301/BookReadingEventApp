using BookReadingApp.Application.Interfaces;
using BookReadingApp.Core.Modals;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookReadingApp.Web.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentRepository _commentPageService;
        public CommentController(ICommentRepository commentPageService)
        {
            _commentPageService = commentPageService;
        }
        public async Task<IActionResult> GetComments()
        {
            var commentList = await _commentPageService.GetComments();
            return View(commentList);
        }
        public async Task<IActionResult> ViewComment(int id)
        {
            var comment = await _commentPageService.ViewComment(id);
            if (comment == null)
            {
                return RedirectToAction("GetComments");
            }
            return View(comment);
        }

        //POST :- CommentController/Create
        [HttpPost]
        public async Task<IActionResult> PostComment(Comment commentViewModel)
        {
            var result = await _commentPageService.PostComment(commentViewModel);
            return RedirectToAction("ViewDetails", "Event", new { id = commentViewModel.EventId });
        }

        //GET: CommentController/Edit/5

        public async Task<IActionResult> EditComment(int id)
        {
            var ans = await _commentPageService.ViewComment(id);
            if (ans == null)
            {
                return RedirectToAction("GetComments");
            }
            return View(ans);
        }
        //POST :- CommentController/Edit/5
        [HttpPost]
        public ActionResult EditComment(Comment commentViewModel)
        {
            var _id = _commentPageService.EditComment(commentViewModel);
            if (_id > 0)
            {
                return RedirectToAction("ViewComment", new { id = _id });
            }
            return View();
        }
    }
}
