using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiAuction.Repositories.Models;
using KoiAuction.Services;

namespace KoiAuction.RazorWebApp.Pages.KoiFarms
{
    public class CreateModel : PageModel
    {
        private readonly KoiFarmService _farmService;
        //private readonly KoiAuction.Repositories.Models.FA24_PRN221_3W_G4_KoiAuctionContext _context;

        public CreateModel(KoiFarmService koiFarmService) => _farmService = koiFarmService;

        //public CreateModel(KoiFarmService koiFarmService)
        //{
        //    _farmService = koiFarmService;
        //}

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public KoiFarm KoiFarm { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _farmService.Create(KoiFarm);

            return RedirectToPage("./Index");
        }
    }
}
