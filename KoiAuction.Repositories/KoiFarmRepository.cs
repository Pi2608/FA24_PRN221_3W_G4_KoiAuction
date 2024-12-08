using KoiAuction.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiAuction.Repositories
{
    public class KoiFarmRepository : GenericRepository<KoiFarm>
    {
        public KoiFarmRepository() { }

        public async Task<List<KoiFarm>> Search(string? email, string? farmName, string? location)
        {
            var query = _context.KoiFarms.AsQueryable();

            if (!string.IsNullOrEmpty(email) || !string.IsNullOrEmpty(farmName) || !string.IsNullOrEmpty(location))
            {
                query = query.Where(f => f.Email.Contains(email) || f.FarmName.Contains(farmName) || f.Location.Contains(location));
            }
            return query.ToList();
        }
    }
}
