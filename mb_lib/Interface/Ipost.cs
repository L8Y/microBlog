using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mb_lib.Interface
{
    public interface Ipost
    {
        public int createPost(string post, string category, int PostOwnerId, DateTime date);
        public IEnumerable<Post> getPost();
        public IEnumerable<Post> getPostById(long PostId);
        public int deletePostById(long postId);

    }
}
