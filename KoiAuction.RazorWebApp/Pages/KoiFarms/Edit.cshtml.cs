using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KoiAuction.Repositories.Models;
using KoiAuction.Services;

namespace KoiAuction.RazorWebApp.Pages.KoiFarms
{
    public class EditModel : PageModel
    {
        private KoiFarmService _farmService;
        //private readonly KoiAuction.Repositories.Models.FA24_PRN221_3W_G4_KoiAuctionContext _context;

        public EditModel(KoiFarmService farmService)
        {
            _farmService = farmService;
        }

        [BindProperty]
        public KoiFarm KoiFarm { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var koifarm =  await _farmService.GetById(id);
            if (koifarm == null)
            {
                return NotFound();
            }
            KoiFarm = koifarm;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _farmService.Update(KoiFarm);
            }
            catch (DbUpdateConcurrencyException)
            {
                KoiFarm farm = await _farmService.GetById(KoiFarm.Id.ToString());

                if (farm == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
