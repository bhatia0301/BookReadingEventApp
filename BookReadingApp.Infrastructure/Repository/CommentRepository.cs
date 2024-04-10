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
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _commentContext;
        public CommentRepository(ApplicationDbContext commentContext)
        {
            _commentContext = commentContext;
        }
        public async Task<int> PostComment(Comment response)
        {
            var newComment = new Comment()
            {
                comment = response.comment,
                EventId = response.EventId
            };
            await _commentContext.Comment.AddAsync(newComment);
            _commentContext.SaveChanges();
            return newComment.Id;
        }
        public async Task<IList<Comment>> GetComments()
        {
            var result = await _commentContext.Comment.OrderBy(x => x.TimeStamp).ToListAsync();
            return result;
        }
        public async Task<Comment> ViewComment(int commentId)
        {
            var result = await _commentContext.Comment.FindAsync(commentId);
            return result;
        }
        public int EditComment(Comment response)
        {
            _commentContext.Comment.Update(response);
            _commentContext.SaveChanges();
            return response.Id;
        }
    }
}
