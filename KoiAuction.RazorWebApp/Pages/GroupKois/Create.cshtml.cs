using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiAuction.Repositories.Models;
using KoiAuction.Services;

namespace KoiAuction.RazorWebApp.Pages.GroupKois
{
    public class CreateModel : PageModel
    {
        private readonly GroupKoiService _groupService;
        private readonly KoiFarmService _farmService;
        //private readonly KoiAuction.Repositories.Models.FA24_PRN221_3W_G4_KoiAuctionContext _context;

        public CreateModel(GroupKoiService groupService, KoiFarmService farmService)
        {
            _groupService = groupService;
            _farmService = farmService;
        }

        public async Task<IActionResult> OnGet()
        {
            var farm = await _farmService.GetAll();
            ViewData["FarmId"] = new SelectList(farm, "Id", "FarmName");
            return Page();
        }

        [BindProperty]
        public GroupKoi GroupKoi { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _groupService.Create(GroupKoi);

            return RedirectToPage("./Index");
        }
    }
}
