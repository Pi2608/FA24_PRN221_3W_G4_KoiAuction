using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiAuction.Repositories.Models;
using KoiAuction.Services;

namespace KoiAuction.RazorWebApp.Pages.KoiFishes
{
    public class CreateModel : PageModel
    {
        private readonly KoiFishService _koiFishService;
        private readonly KoiFarmService _farmsService;
        private readonly GroupKoiService _groupKoiService;

        public CreateModel(KoiFishService koiFishService, KoiFarmService koiFarmsService, GroupKoiService groupKoiService)
        {
            _koiFishService = koiFishService;
            _farmsService = koiFarmsService;
            _groupKoiService = groupKoiService;
        }

        public async Task<IActionResult> OnGet()
        {
           

            var famrs = await _farmsService.GetAll();
            ViewData["FarmId"] = new SelectList(famrs, "Id", "FarmName");
            var groupkois = await _groupKoiService.GetAll();
            ViewData["GroupKoiId"] = new SelectList(groupkois, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public KoiFish KoiFish { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _koiFishService.Create(KoiFish);

            return RedirectToPage("./Index");
        }
    }
}
