using mb_lib.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mb_lib.Services
{
    public class CommentsServices : Icomments
    {
        private readonly bloggingContext _context;
        public CommentsServices(bloggingContext context)
        {
              _context = context; 
        }
        public bool addComments(long CommentOwnerId, long PostId, string Comments)
        {           
                DateTime date = DateTime.UtcNow;
                Comment c = new Comment();
                c.Comments = Comments;
                c.CommentOwnerId = CommentOwnerId;
                c.Date = date;
                c.PostId = PostId;
                _context.Comments.Add(c);
                bool isCommentCreated = _context.SaveChanges() > 0;
                return isCommentCreated;
        }
    }
}
