using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using cakenuy.Data;
using cakenuy.Models;

namespace cakenuy.Pages
{
    public class ManageServicesModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ManageServicesModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Service> Services { get; set; } = new();

        [BindProperty]
        public Service NewService { get; set; } = new();

        public async Task OnGetAsync()
        {
            Services = await _context.Services
                .OrderBy(s => s.SortOrder)
                .ToListAsync();
        }

        public async Task<IActionResult> OnPostCreateAsync()
        {
            if (!ModelState.IsValid)
            {
                await OnGetAsync();
                return Page();
            }

            try
            {
                // Check if service name already exists
                var existingService = await _context.Services
                    .FirstOrDefaultAsync(s => s.Name.ToLower() == NewService.Name.ToLower());

                if (existingService != null)
                {
                    ModelState.AddModelError("NewService.Name", "Nama layanan sudah ada");
                    await OnGetAsync();
                    return Page();
                }

                // Set default values
                NewService.CreatedAt = DateTime.Now;
                NewService.UpdatedAt = DateTime.Now;

                // If no sort order specified, put at the end
                if (NewService.SortOrder <= 0)
                {
                    var maxOrder = await _context.Services.MaxAsync(s => (int?)s.SortOrder) ?? 0;
                    NewService.SortOrder = maxOrder + 1;
                }

                // Set default icon if not provided
                if (string.IsNullOrEmpty(NewService.Icon))
                {
                    NewService.Icon = "🍽️";
                }

                // Set default color if not provided
                if (string.IsNullOrEmpty(NewService.Color))
                {
                    NewService.Color = "bg-pink";
                }

                _context.Services.Add(NewService);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = $"Layanan {NewService.Name} berhasil ditambahkan!";
                return RedirectToPage();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Terjadi kesalahan saat menyimpan layanan: " + ex.Message);
                await OnGetAsync();
                return Page();
            }
        }

        public async Task<IActionResult> OnGetGetServiceAsync(int id)
        {
            var service = await _context.Services.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }

            return new JsonResult(service);
        }

        public async Task<IActionResult> OnPostUpdateAsync(int id, string name, string description, 
            string icon, string color, int sortOrder, bool isActive = false)
        {
            try
            {
                var service = await _context.Services.FindAsync(id);
                if (service == null)
                {
                    return NotFound();
                }

                // Check if service name already exists for other services
                var existingService = await _context.Services
                    .FirstOrDefaultAsync(s => s.Name.ToLower() == name.ToLower() && s.Id != id);

                if (existingService != null)
                {
                    TempData["ErrorMessage"] = "Nama layanan sudah ada";
                    return RedirectToPage();
                }

                // Validate required fields
                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(description))
                {
                    TempData["ErrorMessage"] = "Nama dan deskripsi layanan wajib diisi";
                    return RedirectToPage();
                }

                service.Name = name.Trim();
                service.Description = description.Trim();
                service.Icon = string.IsNullOrWhiteSpace(icon) ? "🍽️" : icon.Trim();
                service.Color = string.IsNullOrWhiteSpace(color) ? "bg-pink" : color.Trim();
                service.SortOrder = sortOrder > 0 ? sortOrder : 1;
                service.IsActive = isActive;
                service.UpdatedAt = DateTime.Now;

                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = $"Layanan {service.Name} berhasil diupdate!";
                return RedirectToPage();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Terjadi kesalahan saat mengupdate layanan: " + ex.Message;
                return RedirectToPage();
            }
        }

        public async Task<IActionResult> OnPostToggleStatusAsync(int id, bool isActive)
        {
            try
            {
                var service = await _context.Services.FindAsync(id);
                if (service == null)
                {
                    return new JsonResult(new { success = false, message = "Layanan tidak ditemukan" });
                }

                service.IsActive = isActive;
                service.UpdatedAt = DateTime.Now;

                await _context.SaveChangesAsync();

                return new JsonResult(new { success = true });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, message = ex.Message });
            }
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            try
            {
                var service = await _context.Services.FindAsync(id);
                if (service == null)
                {
                    return new JsonResult(new { success = false, message = "Layanan tidak ditemukan" });
                }

                _context.Services.Remove(service);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = $"Layanan {service.Name} berhasil dihapus!";
                return new JsonResult(new { success = true });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, message = ex.Message });
            }
        }

        // Helper method to get service statistics
        public async Task<object> GetServiceStatisticsAsync()
        {
            var services = await _context.Services.ToListAsync();
            
            return new
            {
                TotalServices = services.Count,
                ActiveServices = services.Count(s => s.IsActive),
                InactiveServices = services.Count(s => !s.IsActive),
                ServicesByColor = services.GroupBy(s => s.Color)
                    .Select(g => new { Color = g.Key, Count = g.Count() })
                    .OrderByDescending(x => x.Count)
                    .ToList(),
                RecentServices = services.Where(s => s.CreatedAt >= DateTime.Now.AddDays(-30))
                    .OrderByDescending(s => s.CreatedAt)
                    .Take(5)
                    .Select(s => new { s.Name, s.CreatedAt, s.IsActive })
                    .ToList()
            };
        }

        // Helper method to reorder services
        public async Task<IActionResult> OnPostReorderAsync(List<int> serviceIds)
        {
            try
            {
                for (int i = 0; i < serviceIds.Count; i++)
                {
                    var service = await _context.Services.FindAsync(serviceIds[i]);
                    if (service != null)
                    {
                        service.SortOrder = i + 1;
                        service.UpdatedAt = DateTime.Now;
                    }
                }

                await _context.SaveChangesAsync();
                return new JsonResult(new { success = true });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, message = ex.Message });
            }
        }
    }
}