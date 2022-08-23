using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mb_lib.Interface;

namespace mb_lib.Services
{
    public class PostServices : Ipost
    {
        private readonly bloggingContext _context;
        public PostServices(bloggingContext context)
        {
            _context = context;
        }
        public int createPost(string post, string category, int PostOwnerId, DateTime date)
        {
            Post p = new Post();
            p.Category = category;
            p.PostOwnerId = PostOwnerId;
            p.Post1 = post;
            p.Date = date;
            _context.Posts.Add(p);
            int isPostCreated = _context.SaveChanges();
            return isPostCreated;
        }
        public IEnumerable<Post> getPost()
        {
            var post = _context.Posts.ToList();
            return post;
        }
        public IEnumerable<Post> getPostById(long PostId)
        {
            var postById = _context.Posts.Where(p => p.PostId == PostId).ToList();
            return postById;
        }

        public int deletePostById(long postId)
        {
            var postById = _context.Posts.Where(p => p.PostId == postId).FirstOrDefault();
            int isDeleted = 0;
            if (postById != null)
            {
                _context.Posts.Remove(postById);
                 isDeleted = _context.SaveChanges();
            }
            return isDeleted;
        }
    }
}
