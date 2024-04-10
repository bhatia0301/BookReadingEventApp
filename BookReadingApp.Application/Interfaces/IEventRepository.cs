using BookReadingApp.Core.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReadingApp.Application.Interfaces
{
    public interface IEventRepository
    {
        Task<IList<Event>> GetEvents();
        Task<Event> ViewDetails(int _eventId);
        Task<int> CreateEvent(Event _event);
        int UpdateEvent(Event _event);
        Task<IList<Event>> MyEvents(string organiser);
        Task<IList<Comment>> GetAllCommentByEventId(int eventId);
    }
}
