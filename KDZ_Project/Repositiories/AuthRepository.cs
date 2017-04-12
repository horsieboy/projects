using KDZ_Project.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDZ_Project.Repositiories
{
   public class AuthRepository
    {
        private CompetitiondbContext _context;

        public AuthRepository()
        {
            _context = new CompetitiondbContext();
        }
        public bool Authenticate(string login, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Login.Trim().ToLower() == login.Trim().ToLower());
            if (user == null) return false;
            return user.Password == password;
        }
    }
}
