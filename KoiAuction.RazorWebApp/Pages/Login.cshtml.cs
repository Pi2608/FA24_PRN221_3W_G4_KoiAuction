using KoiAuction.Repositories.Models;
using KoiAuction.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiAuction.RazorWebApp.Pages
{
    public class LoginModel : PageModel
    {
        private readonly UserService _userService;
        
        public LoginModel(UserService userService)
        {
            _userService = userService;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            string email = Request.Form["email"];
            string password = Request.Form["password"];


            User account = await _userService.GetUserByEmail(email);
            if (account != null && account.Password.Equals(password))
            {
                HttpContext.Session.SetString("Role", account.Role.ToString());
                return RedirectToPage("/Index");
            }
            else
            {
                TempData["Error"] = "You do not have permission to do this function!";
                return Page();
            }
        }
    }
}
