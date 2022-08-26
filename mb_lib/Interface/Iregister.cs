using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mb_lib.Interface
{
    public interface IRegister
    {
        public int AddUser(Register r);
        public bool Login(string email, string password);
        public long GetUserId(string email);
    }
}
