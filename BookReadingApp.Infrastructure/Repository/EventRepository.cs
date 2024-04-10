using BookReadingApp.Application.Interfaces;
using BookReadingApp.Core.Modals;
using BookReadingApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReadingApp.Infrastructure.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly ApplicationDbContext _eventContext;
        public EventRepository(ApplicationDbContext eventContext)
        {
            _eventContext = eventContext;
        }
        public async Task<IList<Event>> GetEvents()
        {
            return await _eventContext.Events.OrderBy(x => x.Date).ToListAsync();
        }
        public async Task<Event> ViewDetails(int eventId)
        {
            return await _eventContext.Events.FindAsync(eventId);
        }
        public async Task<int> CreateEvent(Event _event)
        {
            var newEvent = new Event()
            {
                Title = _event.Title,
                Description = _event.Description,
                Date = _event.Date,
                StartTime = _event.StartTime,
                Location = _event.Location,
                Duration = _event.Duration,
                Organiser = _event.Organiser,
                EventType = _event.EventType,
                Invitees = _event.Invitees
            };
            await _eventContext.Events.AddAsync(newEvent);
            _eventContext.SaveChanges();
            return newEvent.Id;
        }
        public int UpdateEvent(Event _event)
        {
            _eventContext.Events.Update(_event);
            _eventContext.SaveChanges();
            return _event.Id;
        }
        public async Task<IList<Event>> MyEvents(string organiser)
        {
            var output = from _event in _eventContext.Events
                         where _event.Organiser == organiser
                         orderby _event.Date
                         select _event;

            return await output.ToListAsync();
        }
        public async Task<IList<Comment>> GetAllCommentByEventId(int eventId)
        {
            var output = await (from e in _eventContext.Events
                                join c in _eventContext.Comment on
                                e.Id equals c.EventId
                                where c.EventId == eventId
                                orderby c.TimeStamp
                                select new Comment()
                                {
                                    EventId = eventId,
                                    comment = c.comment,
                                    TimeStamp = c.TimeStamp
                                }).ToListAsync();
            return output;
        }
    }
}
