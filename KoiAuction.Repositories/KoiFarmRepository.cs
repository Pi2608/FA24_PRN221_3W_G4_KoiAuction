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

        public async Task<List<KoiFarm>> Search(string? farmName, string? location, string? owner)
        {
            var query = _context.KoiFarms.AsQueryable();

            if (!string.IsNullOrEmpty(farmName))
            {
                query = query.Where(f => f.FarmName.Contains(farmName));
            }

            if (!string.IsNullOrEmpty(location))
            {
                query = query.Where(f => f.Location.Contains(location));
            }

            if (!string.IsNullOrEmpty(owner))
            {
                query = query.Where(f => f.OwnerName.Contains(owner));
            }

            return query.ToList();
        }
    }
}
