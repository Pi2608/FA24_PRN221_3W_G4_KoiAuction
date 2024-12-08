using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiAuction.Repositories.Models;
using KoiAuction.Services;

namespace KoiAuction.RazorWebApp.Pages.GroupKois
{
    public class DeleteModel : PageModel
    {
        private readonly GroupKoiService _groupService;
        //private readonly KoiAuction.Repositories.Models.FA24_PRN221_3W_G4_KoiAuctionContext _context;

        public DeleteModel(GroupKoiService groupService)
        {
            _groupService = groupService;
        }

        [BindProperty]
        public GroupKoi GroupKoi { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupkoi = await _groupService.GetById(id);

            if (groupkoi == null)
            {
                return NotFound();
            }
            else
            {
                GroupKoi = groupkoi;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupkoi = await _groupService.GetById(id);
            if (groupkoi != null)
            {
                GroupKoi = groupkoi;
                await _groupService.Delete(GroupKoi);
            }

            return RedirectToPage("./Index");
        }
    }
}
