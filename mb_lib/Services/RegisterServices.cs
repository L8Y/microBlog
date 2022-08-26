using mb_lib.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mb_lib.Services
{
    public class RegisterServices : IRegister
    {
        private readonly bloggingContext _context;
        public RegisterServices(bloggingContext context)
        {
            _context = context;
        }
        public int AddUser(Register r)
        {
            _context.Registers.Add(r);
            int isUserCreated = _context.SaveChanges();
            return isUserCreated;
        }
        public bool Login(string email, string password)
        {
            bool isValidUser = _context.Registers.Where(c => c.Email == email && c.Password == password).Any();
            return isValidUser;
        }
        public long GetUserId(string email)
        {
            long userId = (from register in _context.Registers
                           where register.Email == email
                           select register.UserId).FirstOrDefault();
            return userId;

        }
    }
}
