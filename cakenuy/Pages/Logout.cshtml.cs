using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cakenuy.Pages
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            // Debug: Check if session exists
            var isLoggedIn = HttpContext.Session.GetString("IsLoggedIn");
            var username = HttpContext.Session.GetString("Username");
            
            Console.WriteLine($"Logout - IsLoggedIn: {isLoggedIn}, Username: {username}");
            
            // Clear session
            HttpContext.Session.Clear();
            
            // Verify session is cleared
            var isLoggedInAfter = HttpContext.Session.GetString("IsLoggedIn");
            Console.WriteLine($"After clear - IsLoggedIn: {isLoggedInAfter}");

            // Redirect to login page
            return RedirectToPage("/Login");
        }

        public IActionResult OnPost()
        {
            // Clear session
            HttpContext.Session.Clear();

            // Redirect to login page
            return RedirectToPage("/Login");
        }
    }
}