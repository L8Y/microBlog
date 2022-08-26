using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mb_lib.Interface
{
    public interface IComments
    {
        public bool AddComments(long CommentOwnerId, long PostId, string Comments);
    }
}
