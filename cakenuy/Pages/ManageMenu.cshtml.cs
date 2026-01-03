using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using cakenuy.Data;
using cakenuy.Models;
using System.Linq;

namespace cakenuy.Pages
{
    public class ManageMenuModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ManageMenuModel(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public List<MenuItem> MenuItems { get; set; } = new List<MenuItem>();

        [BindProperty]
        public MenuItem MenuItem { get; set; } = new MenuItem();

        [BindProperty]
        public IFormFile? ImageFile { get; set; }

        public async Task OnGetAsync()
        {
            MenuItems = await _context.MenuItems
                .OrderByDescending(m => m.CreatedAt)
                .ToListAsync();
        }

        public async Task<IActionResult> OnPostCreateAsync()
        {
            Console.WriteLine("OnPostCreateAsync called");
            Console.WriteLine($"MenuItem.Name: {MenuItem?.Name}");
            Console.WriteLine($"MenuItem.Price: {MenuItem?.Price}");
            Console.WriteLine($"MenuItem.Category: {MenuItem?.Category}");
            Console.WriteLine($"ImageFile: {ImageFile?.FileName}");
            
            if (!ModelState.IsValid)
            {
                Console.WriteLine("ModelState is invalid:");
                // Log validation errors for debugging
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine($"Validation Error: {error.ErrorMessage}");
                }
                
                MenuItems = await _context.MenuItems
                    .OrderByDescending(m => m.CreatedAt)
                    .ToListAsync();
                return Page();
            }

            Console.WriteLine("ModelState is valid, proceeding with save");

            // Handle image upload
            if (ImageFile != null && ImageFile.Length > 0)
            {
                Console.WriteLine($"Processing image file: {ImageFile.FileName}");
                // Validate file type
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                var fileExtension = Path.GetExtension(ImageFile.FileName).ToLowerInvariant();
                
                if (!allowedExtensions.Contains(fileExtension))
                {
                    ModelState.AddModelError("ImageFile", "Hanya file gambar (JPG, PNG, GIF) yang diperbolehkan!");
                    MenuItems = await _context.MenuItems
                        .OrderByDescending(m => m.CreatedAt)
                        .ToListAsync();
                    return Page();
                }
                
                // Validate file size (5MB max)
                if (ImageFile.Length > 5 * 1024 * 1024)
                {
                    ModelState.AddModelError("ImageFile", "Ukuran file terlalu besar! Maksimal 5MB.");
                    MenuItems = await _context.MenuItems
                        .OrderByDescending(m => m.CreatedAt)
                        .ToListAsync();
                    return Page();
                }

                var uploadsFolder = Path.Combine(_env.WebRootPath, "images");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var uniqueFileName = Guid.NewGuid().ToString() + "_" + ImageFile.FileName;
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(fileStream);
                }

                MenuItem.ImageUrl = "/images/" + uniqueFileName;
                Console.WriteLine($"Image saved: {MenuItem.ImageUrl}");
            }
            else
            {
                MenuItem.ImageUrl = "/images/default-cake.png"; // Default image
                Console.WriteLine("Using default image");
            }

            MenuItem.CreatedAt = DateTime.Now;
            MenuItem.UpdatedAt = DateTime.Now;

            Console.WriteLine("Adding MenuItem to context");
            _context.MenuItems.Add(MenuItem);
            
            Console.WriteLine("Saving changes to database");
            await _context.SaveChangesAsync();
            
            Console.WriteLine("Menu item saved successfully, redirecting");
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostEditAsync(int id)
        {
            var menuItem = await _context.MenuItems.FindAsync(id);
            if (menuItem == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                MenuItems = await _context.MenuItems
                    .OrderByDescending(m => m.CreatedAt)
                    .ToListAsync();
                return Page();
            }

            // Handle image upload for edit
            if (ImageFile != null && ImageFile.Length > 0)
            {
                // Delete old image if it exists and is not default
                if (!string.IsNullOrEmpty(menuItem.ImageUrl) && 
                    !menuItem.ImageUrl.Contains("default-cake.png"))
                {
                    var oldImagePath = Path.Combine(_env.WebRootPath, menuItem.ImageUrl.TrimStart('/'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                var uploadsFolder = Path.Combine(_env.WebRootPath, "images");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var uniqueFileName = Guid.NewGuid().ToString() + "_" + ImageFile.FileName;
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(fileStream);
                }

                menuItem.ImageUrl = "/images/" + uniqueFileName;
            }

            menuItem.Name = MenuItem.Name;
            menuItem.Description = MenuItem.Description;
            menuItem.Price = MenuItem.Price;
            menuItem.Category = MenuItem.Category;
            menuItem.IsAvailable = MenuItem.IsAvailable;
            menuItem.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var menuItem = await _context.MenuItems.FindAsync(id);
            if (menuItem == null)
            {
                return NotFound();
            }

            _context.MenuItems.Remove(menuItem);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }

        public async Task<IActionResult> OnGetItemAsync(int id)
        {
            var menuItem = await _context.MenuItems.FindAsync(id);
            if (menuItem == null)
            {
                return new JsonResult(new { success = false });
            }

            return new JsonResult(new
            {
                success = true,
                item = menuItem
            });
        }
    }
}
