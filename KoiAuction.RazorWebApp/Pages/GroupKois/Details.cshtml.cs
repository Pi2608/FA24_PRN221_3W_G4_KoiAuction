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
    public class DetailsModel : PageModel
    {
        private readonly GroupKoiService _groupService;
        //private readonly KoiAuction.Repositories.Models.FA24_PRN221_3W_G4_KoiAuctionContext _context;

        public DetailsModel(GroupKoiService groupService)
        {
            _groupService = groupService;
        }

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
    }
}
