using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using cakenuy.Data;
using cakenuy.Models;

namespace cakenuy.Pages
{
    public class TestOrderModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public TestOrderModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Service> Services { get; set; } = new();
        public List<MenuItem> MenuItems { get; set; } = new();
        public int ServicesCount { get; set; }
        public int MenuItemsCount { get; set; }

        public async Task OnGetAsync()
        {
            Services = await _context.Services
                .OrderBy(s => s.SortOrder)
                .ToListAsync();

            MenuItems = await _context.MenuItems
                .OrderBy(m => m.Category)
                .ThenBy(m => m.Name)
                .ToListAsync();

            ServicesCount = Services.Count;
            MenuItemsCount = MenuItems.Count;
        }
    }
}