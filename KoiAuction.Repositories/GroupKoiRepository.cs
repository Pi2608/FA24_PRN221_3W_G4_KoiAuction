using KoiAuction.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiAuction.Repositories
{
    public class GroupKoiRepository:GenericRepository<GroupKoi>
    {
        public GroupKoiRepository() { }

        public async Task<List<GroupKoi>> GetAllAsync()
        {
            return _context.GroupKois.Include(gk => gk.Farm).ToList();
        }
    }
}
