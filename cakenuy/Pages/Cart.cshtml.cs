using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using cakenuy.Data;
using cakenuy.Models;

namespace cakenuy.Pages
{
    public class CartModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CartModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Service> AvailableServices { get; set; } = new();
        public List<MenuItem> MenuItems { get; set; } = new();

        [BindProperty]
        public Order NewOrder { get; set; } = new();

        [BindProperty]
        public List<OrderItemDto> OrderItems { get; set; } = new();

        // Properties for completed order display
        public Order? CompletedOrder { get; set; }
        public bool IsOrderCompleted { get; set; } = false;

        public async Task OnGetAsync()
        {
            // Get only active services, ordered by SortOrder
            AvailableServices = await _context.Services
                .Where(s => s.IsActive)
                .OrderBy(s => s.SortOrder)
                .ToListAsync();

            // Get available menu items
            MenuItems = await _context.MenuItems
                .Where(m => m.IsAvailable)
                .OrderBy(m => m.Category)
                .ThenBy(m => m.Name)
                .ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                // Validate ServiceId first
                if (NewOrder.ServiceId <= 0)
                {
                    ModelState.AddModelError("NewOrder.ServiceId", "Silakan pilih layanan");
                    await OnGetAsync();
                    return Page();
                }
                
                // Validate that we have order items
                if (OrderItems == null || !OrderItems.Any() || OrderItems.All(oi => oi.Quantity <= 0))
                {
                    ModelState.AddModelError("", "Silakan pilih minimal satu menu item");
                    await OnGetAsync();
                    return Page();
                }

                // Validate service exists and is active
                var service = await _context.Services
                    .FirstOrDefaultAsync(s => s.Id == NewOrder.ServiceId && s.IsActive);

                if (service == null)
                {
                    ModelState.AddModelError("NewOrder.ServiceId", "Layanan yang dipilih tidak tersedia");
                    await OnGetAsync();
                    return Page();
                }

                // Validate delivery address for delivery service
                if (service.Name.ToLower().Contains("delivery") || service.Name.ToLower().Contains("antar"))
                {
                    if (string.IsNullOrWhiteSpace(NewOrder.DeliveryAddress))
                    {
                        ModelState.AddModelError("NewOrder.DeliveryAddress", "Alamat pengiriman wajib diisi untuk layanan delivery");
                        await OnGetAsync();
                        return Page();
                    }
                }
                else
                {
                    // Clear delivery address for non-delivery services
                    NewOrder.DeliveryAddress = string.Empty;
                }

                // Validate order datetime is not in the past
                if (NewOrder.OrderDateTime < DateTime.Now.AddHours(1))
                {
                    ModelState.AddModelError("NewOrder.OrderDateTime", "Tanggal dan waktu pesanan minimal 1 jam dari sekarang");
                    await OnGetAsync();
                    return Page();
                }

                if (!ModelState.IsValid)
                {
                    await OnGetAsync();
                    return Page();
                }

                // Create order
                NewOrder.CreatedAt = DateTime.Now;
                NewOrder.UpdatedAt = DateTime.Now;
                NewOrder.Status = OrderStatus.Pending;

                _context.Orders.Add(NewOrder);
                await _context.SaveChangesAsync();

                // Create order items
                decimal totalAmount = 0;
                foreach (var orderItemDto in OrderItems.Where(oi => oi.Quantity > 0))
                {
                    var menuItem = await _context.MenuItems.FindAsync(orderItemDto.MenuItemId);
                    if (menuItem != null && menuItem.IsAvailable)
                    {
                        var orderItem = new OrderItem
                        {
                            OrderId = NewOrder.Id,
                            MenuItemId = orderItemDto.MenuItemId,
                            Quantity = orderItemDto.Quantity,
                            UnitPrice = orderItemDto.UnitPrice,
                            Notes = orderItemDto.Notes ?? ""
                        };

                        _context.OrderItems.Add(orderItem);
                        totalAmount += orderItem.TotalPrice;
                    }
                }

                // Update total amount
                NewOrder.TotalAmount = totalAmount;
                await _context.SaveChangesAsync();

                // Load the complete order with related data for display
                CompletedOrder = await _context.Orders
                    .Include(o => o.Service)
                    .Include(o => o.OrderItems)
                        .ThenInclude(oi => oi.MenuItem)
                    .FirstOrDefaultAsync(o => o.Id == NewOrder.Id);

                // Set success flag
                IsOrderCompleted = true;

                // Reset form for potential new orders
                NewOrder = new Order();
                OrderItems = new List<OrderItemDto>();

                // Reload data for potential new orders
                await OnGetAsync();

                return Page();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Terjadi kesalahan saat memproses pesanan: " + ex.Message);
                await OnGetAsync();
                return Page();
            }
        }
    }

    public class OrderItemDto
    {
        public int MenuItemId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string Notes { get; set; } = "";
    }
}