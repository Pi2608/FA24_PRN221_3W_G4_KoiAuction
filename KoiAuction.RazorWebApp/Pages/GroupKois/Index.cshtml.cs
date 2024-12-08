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
    public class IndexModel : PageModel
    {
        private readonly GroupKoiService _groupService;
        //private readonly KoiAuction.Repositories.Models.FA24_PRN221_3W_G4_KoiAuctionContext _context;

        public IndexModel(GroupKoiService groupService)
        {
            _groupService = groupService;
        }

        public IList<GroupKoi> GroupKoi { get;set; } = default!;

        public async Task OnGetAsync()
        {
            GroupKoi = await _groupService.GetAll();
        }
    }
}
