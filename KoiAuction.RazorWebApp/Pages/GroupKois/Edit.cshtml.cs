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

namespace KoiAuction.RazorWebApp.Pages.GroupKois
{
    public class EditModel : PageModel
    {
        private readonly GroupKoiService _groupService;
        private readonly KoiFarmService _farmService;
        //private readonly KoiAuction.Repositories.Models.FA24_PRN221_3W_G4_KoiAuctionContext _context;

        public EditModel(GroupKoiService groupService, KoiFarmService farmService)
        {
            _groupService = groupService;
            _farmService = farmService;
        }

        [BindProperty]
        public GroupKoi GroupKoi { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupkoi =  await _groupService.GetById(id);
            if (groupkoi == null)
            {
                return NotFound();
            }
            GroupKoi = groupkoi;
            var farm = await _farmService.GetAll();
            ViewData["FarmId"] = new SelectList(farm, "Id", "FarmName");
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

            GroupKoi group = await _groupService.GetById(GroupKoi.Id);

            try
            {
                await _groupService.Update(GroupKoi);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (group == null)
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
