using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiAuction.Repositories.Models;
using KoiAuction.Services;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace KoiAuction.RazorWebApp.Pages.KoiFarms
{
    public class IndexModel : PageModel
    {
        //private readonly KoiAuction.Repositories.Models.FA24_PRN221_3W_G4_KoiAuctionContext _context;
        private readonly KoiFarmService _farmService;

        public IndexModel(KoiFarmService koiFarmService)
        {
            _farmService = koiFarmService;
        }

        //public IndexModel(KoiAuction.Repositories.Models.FA24_PRN221_3W_G4_KoiAuctionContext context)
        //{
        //    _context = context;
        //}
        [BindProperty]
        public IList<KoiFarm> KoiFarm { get;set; } = default!;
        public string? FarmName { get; set; }
        public string? Location { get; set; }
        public string? Owner { get; set; }

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 2;

        public async Task OnGetAsync(string? farmName, string? location, string? owner, int pageNumber = 1)
        {
            List<KoiFarm> farms;
            List<KoiFarm> allFarms;

            FarmName = farmName;
            Location = location;
            Owner = owner;

            farms = await _farmService.Search(farmName, location, owner);
            allFarms = await _farmService.GetAll();

            if (farms.Count > 0)
            {
                KoiFarm = farms;
            }
            else
            {
                KoiFarm = allFarms;
            }
            var totalItems = KoiFarm.Count();
            TotalPages = (int)Math.Ceiling(totalItems / (double)PageSize);
            CurrentPage = pageNumber;

            KoiFarm = KoiFarm
                .Skip((pageNumber - 1) * PageSize)
                .Take(PageSize)
                .ToList();
        }
    }
}
