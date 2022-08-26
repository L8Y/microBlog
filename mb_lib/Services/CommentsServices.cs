using mb_lib.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mb_lib.Services
{
    public class CommentsServices : IComments
    {
        private readonly bloggingContext _context;
        public CommentsServices(bloggingContext context)
        {
              _context = context; 
        }
        public bool AddComments(long CommentOwnerId, long PostId, string Comments)
        {           
                DateTime date = DateTime.UtcNow;
                Comment newComment = new Comment();
                newComment.Comments = Comments;
                newComment.CommentOwnerId = CommentOwnerId;
                newComment.Date = date;
                newComment.PostId = PostId;
                _context.Comments.Add(newComment);
                bool isCommentCreated = _context.SaveChanges() > 0;
                return isCommentCreated;
        }
    }
}
