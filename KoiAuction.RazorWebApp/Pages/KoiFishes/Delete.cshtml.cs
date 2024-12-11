﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiAuction.Repositories.Models;
using KoiAuction.Services;

namespace KoiAuction.RazorWebApp.Pages.KoiFishes
{
    public class DeleteModel : PageModel
    {
        private readonly KoiFishService _koiFishService;
        private readonly KoiFarmService _farmsService;
        private readonly GroupKoiService _groupKoiService;

        public DeleteModel(KoiFishService koiFishService, KoiFarmService koiFarmsService, GroupKoiService groupKoiService)
        {
            _koiFishService = koiFishService;
            _farmsService = koiFarmsService;
            _groupKoiService = groupKoiService;
        }

        [BindProperty]
        public KoiFish KoiFish { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var koifish = await _koiFishService.GetById(id);

            if (koifish == null)
            {
                return NotFound();
            }
            else
            {
                KoiFish = koifish;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var koifish = await _koiFishService.GetById(id);
            if (koifish != null)
            {
                KoiFish = koifish;
                await _koiFishService.Delete(koifish);
            }

            return RedirectToPage("./Index");
        }
    }
}

