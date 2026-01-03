using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using cakenuy.Data;
using cakenuy.Models;

namespace cakenuy.Pages
{
    public class LoginPageModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public LoginPageModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LoginModel LoginData { get; set; } = new();

        public string? ReturnUrl { get; set; }

        public void OnGet(string? returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        {
            ReturnUrl = returnUrl;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                // Find user by username
                var user = await _context.Users
                    .FirstOrDefaultAsync(u => u.Username == LoginData.Username && u.IsActive);

                if (user == null)
                {
                    ModelState.AddModelError("", "Username tidak ditemukan atau akun tidak aktif");
                    return Page();
                }

                // Verify password (in production, use proper password hashing)
                if (user.Password != LoginData.Password)
                {
                    ModelState.AddModelError("", "Password salah");
                    return Page();
                }

                // Set session
                HttpContext.Session.SetString("UserId", user.Id.ToString());
                HttpContext.Session.SetString("Username", user.Username);
                HttpContext.Session.SetString("FullName", user.FullName);
                HttpContext.Session.SetString("Role", user.Role);
                HttpContext.Session.SetString("IsLoggedIn", "true");

                // Debug: Verify session is set
                Console.WriteLine($"Login - Session set for user: {user.Username}");
                Console.WriteLine($"Login - IsLoggedIn: {HttpContext.Session.GetString("IsLoggedIn")}");

                // Update last login
                user.UpdatedAt = DateTime.Now;
                await _context.SaveChangesAsync();

                // Redirect to return URL or home
                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }

                return RedirectToPage("/Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Terjadi kesalahan saat login: " + ex.Message);
                return Page();
            }
        }
    }
}