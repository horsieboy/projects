using KDZ_Project.Context;
using KDZ_Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace KDZ_Project.Repositiories
{
   public class AuthRepository
    {
        private CompetitiondbContext _context;

        public AuthRepository()
        {
            _context = new CompetitiondbContext();
        }
        public bool Authenticate(string login, string password, out int UserId)
            
        {

            UserId = -1;
            var user = _context.Users.FirstOrDefault(u => u.Login.Trim().ToLower() == login.Trim().ToLower());
            if (user == null) return false;
            UserId = user.Id;
            return user.Password == password;
        }

        public bool Check(string login)
        {
            var user = _context.Users.FirstOrDefault(u => u.Login.Trim().ToLower() == login.Trim().ToLower());
            return user == null;
        }
        public User Create(string login, string password)
        {
            var user = new User { Login = login, Password = password};
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User GetUser(int UserId)
        {

            return _context.Users.Include(x=> x.UserInfo).FirstOrDefault(u=>u.Id == UserId);

        }
    }
}
