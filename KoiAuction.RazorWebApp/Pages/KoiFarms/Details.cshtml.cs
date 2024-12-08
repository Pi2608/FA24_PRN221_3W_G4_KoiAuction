using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiAuction.Repositories.Models;
using KoiAuction.Services;

namespace KoiAuction.RazorWebApp.Pages.KoiFarms
{
    public class DetailsModel : PageModel
    {
        private readonly KoiFarmService _farmService;
        //private readonly KoiAuction.Repositories.Models.FA24_PRN221_3W_G4_KoiAuctionContext _context;

        public DetailsModel(KoiFarmService farmService)
        {
            _farmService = farmService;
        }

        public KoiFarm KoiFarm { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var koifarm = await _farmService.GetById(id);
            if (koifarm == null)
            {
                return NotFound();
            }
            else
            {
                KoiFarm = koifarm;
            }
            return Page();
        }
    }
}
