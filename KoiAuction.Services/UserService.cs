using KoiAuction.Repositories;
using KoiAuction.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiAuction.Services
{
    public class UserService
    {
        private UserRepository _repo;

        public UserService()
        {
            _repo = new UserRepository();
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _repo.GetUserByEmail(email);
        }
    }
}
