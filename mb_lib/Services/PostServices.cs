using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mb_lib.Interface;

namespace mb_lib.Services
{
    public class PostServices : IPost
    {
        private readonly bloggingContext _context;
        public PostServices(bloggingContext context)
        {
            _context = context;
        }
        public int CreatePost(string post, string category, int PostOwnerId, DateTime date)
        {
            Post newPost = new Post();
            newPost.Category = category;
            newPost.PostOwnerId = PostOwnerId;
            newPost.Post1 = post;
            newPost.Date = date;
            _context.Posts.Add(newPost);
            int isPostCreated = _context.SaveChanges();
            return isPostCreated;
        }
        public IEnumerable<Post> GetPost()
        {
            var post = _context.Posts;
            return post;
        }
        public IEnumerable<Post> GetPostById(long PostId)
        {
            var postById = _context.Posts.Where(p => p.PostId == PostId);
            return postById;
        }

        public int DeletePostById(long postId)
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
