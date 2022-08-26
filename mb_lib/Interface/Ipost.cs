using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mb_lib.Interface
{
    public interface IPost
    {
        public int CreatePost(string post, string category, int PostOwnerId, DateTime date);
        public IEnumerable<Post> GetPost();
        public IEnumerable<Post> GetPostById(long PostId);
        public int DeletePostById(long postId);


    }
}
