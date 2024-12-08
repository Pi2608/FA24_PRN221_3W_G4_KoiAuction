using System;
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
    public class IndexModel : PageModel
    {
        private readonly KoiFishService _koiFishService;

        public IndexModel()
        {
            _koiFishService = new KoiFishService();
        }

        // Thuộc tính cho form tìm kiếm
        public string? Name { get; set; }
        public string? Status { get; set; }
        public string? Gender { get; set; }

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 3;

        // Danh sách KoiFish để hiển thị
        public List<KoiFish> KoiFish { get; set; } = new List<KoiFish>();

        public async Task OnGetAsync(string? name, string? status, string? gender, int pageNumber = 1)
        {
            List<KoiFish> fishs;
            List<KoiFish> allFishs;
            // Gán giá trị từ query string vào các thuộc tính
            Name = name;
            Status = status;
            Gender = gender;

            fishs = await _koiFishService.SearchAsync(name, status, gender);
            allFishs = await _koiFishService.GetAllWith();

            if (fishs.Count > 0)
            {
                KoiFish = fishs;
            }
            else
            {
                KoiFish = allFishs;
            }
            var totalItems = KoiFish.Count();
            TotalPages = (int)Math.Ceiling(totalItems / (double)PageSize);
            CurrentPage = pageNumber;

            KoiFish = KoiFish
                .Skip((pageNumber - 1) * PageSize)
                .Take(PageSize)
                .ToList();
        }
    }
}