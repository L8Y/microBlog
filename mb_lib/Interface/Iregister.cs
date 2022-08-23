using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mb_lib.Interface
{
    public interface Iregister
    {
        public int add_user(Register r);
        public bool login(string email, string password);
        public long getUserId(string email);
    }
}
