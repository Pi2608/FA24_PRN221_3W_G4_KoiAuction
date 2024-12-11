using KoiAuction.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiAuction.Repositories
{
    public class KoiFishRepository : GenericRepository<KoiFish>
    {
        public KoiFishRepository() { }

        public async Task<List<KoiFish>> GetGroupAll()
        {
            return await _context.Set<KoiFish>()
                .Include(k => k.GroupKoi)
                .Include(k => k.Farm)
                .ToListAsync();
        }

        public async Task<KoiFish?> GetByIdWithIncludesAsync(int? id)
        {
            if (id == null || id <= 0) return null;

            return await _context.Set<KoiFish>()
                .Include(k => k.GroupKoi)
                .Include(k => k.Farm)
                .FirstOrDefaultAsync(k => k.Id == id);
        }

        //public async Task<List<KoiFish>> Search(string? name, string? status, string? gender)
        //{
        //    var query = _context.KoiFishes.AsQueryable();

        //    if (!string.IsNullOrEmpty(name) || !string.IsNullOrEmpty(status) || !string.IsNullOrEmpty(gender))
        //    {
        //        query = query.Where(f =>
        //            (!string.IsNullOrEmpty(name) && f.Name.Contains(name)) ||
        //            (!string.IsNullOrEmpty(status) && f.Status.Contains(status)) ||
        //            (!string.IsNullOrEmpty(gender) && f.Gender.Contains(gender)));
        //    }
        //    return query.ToList();
        //}

        public async Task<List<KoiFish>> SearchAsync(string? name, string? status, string? gender)
        {
            var query = _context.KoiFishes.AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(f => f.Name.Contains(name));
            }

            if (!string.IsNullOrEmpty(status))
            {
                query = query.Where(f => f.Status.Contains(status));
            }

            if (!string.IsNullOrEmpty(gender))
            {
                query = query.Where(f => f.Gender.Contains(gender));
            }

            return await query.ToListAsync();
        }
    }
}
