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

namespace KoiAuction.RazorWebApp.Pages.KoiFishes
{
    public class EditModel : PageModel
    {
        private readonly KoiFishService _koiFishService;
        private readonly KoiFarmService _farmsService;
        private readonly GroupKoiService _groupKoiService;

        public EditModel(KoiFishService koiFishService, KoiFarmService koiFarmsService, GroupKoiService groupKoiService)
        {
            _koiFishService = koiFishService;
            _farmsService = koiFarmsService;
            _groupKoiService = groupKoiService;
        }

        [BindProperty]
        public KoiFish KoiFish { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (HttpContext.Session.GetString("roleId") != "1")
            {

                return RedirectToPage("./Index");// Returns a 403 Forbidden response if not admin
            }
            if (id == null)
            {
                return NotFound();
            }

            var koifish = await _koiFishService.GetById(id);
            if (koifish == null)
            {
                return NotFound();
            }
            var famrs = await _farmsService.GetAll();
            ViewData["FarmId"] = new SelectList(famrs, "Id", "FarmName");
            var groupkois = await _groupKoiService.GetAll();
            ViewData["GroupKoiId"] = new SelectList(groupkois, "Id", "Name");
            KoiFish = koifish;
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

            await _koiFishService.UpdateAsync(KoiFish);

            return RedirectToPage("./Index");
        }

        //private bool KoiFishExists(int id)
        //{
        //    return _context.KoiFishes.Any(e => e.Id == id);
        //}
    }
}
