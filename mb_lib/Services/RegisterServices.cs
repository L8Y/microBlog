using mb_lib.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mb_lib.Services
{
    public class RegisterServices : Iregister
    {
        private readonly bloggingContext _context;
        public RegisterServices(bloggingContext context)
        {
            _context = context;
        }
        public int add_user(Register r)
        {
            _context.Registers.Add(r);
            int isUserCreated = _context.SaveChanges();
            return isUserCreated;
        }
        public bool login(string email, string password)
        {
            bool isValidUser = _context.Registers.Where(c => c.Email == email && c.Password == password).Any();
            return isValidUser;
        }
        public long getUserId(string email)
        {
            long userId = (from id in _context.Registers
                           where id.Email == email
                           select id.UserId).FirstOrDefault();
            return userId;

        }
    }
}
