using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mb_lib.Interface
{
    public interface Icomments
    {
        public bool addComments(long CommentOwnerId, long PostId, string Comments);
    }
}
