using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using cakenuy.Data;
using cakenuy.Models;
using System.ComponentModel.DataAnnotations;

namespace cakenuy.Pages
{
    public class ManageEmployeesModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ManageEmployeesModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Employee> Employees { get; set; } = new();

        [BindProperty]
        public Employee NewEmployee { get; set; } = new();

        public async Task OnGetAsync()
        {
            Employees = await _context.Employees
                .OrderBy(e => e.Id)
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
                // Check if phone number already exists
                var existingEmployee = await _context.Employees
                    .FirstOrDefaultAsync(e => e.PhoneNumber == NewEmployee.PhoneNumber);

                if (existingEmployee != null)
                {
                    ModelState.AddModelError("NewEmployee.PhoneNumber", "Nomor HP sudah terdaftar untuk karyawan lain");
                    await OnGetAsync();
                    return Page();
                }

                NewEmployee.CreatedAt = DateTime.Now;
                NewEmployee.UpdatedAt = DateTime.Now;

                _context.Employees.Add(NewEmployee);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = $"Karyawan {NewEmployee.FullName} berhasil ditambahkan!";
                return RedirectToPage();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Terjadi kesalahan saat menyimpan data karyawan: " + ex.Message);
                await OnGetAsync();
                return Page();
            }
        }

        public async Task<IActionResult> OnGetGetEmployeeAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            return new JsonResult(employee);
        }

        public async Task<IActionResult> OnPostUpdateAsync(int id, string fullName, string position, 
            string phoneNumber, string address, DateTime hireDate, string workShift, bool isActive = false)
        {
            try
            {
                var employee = await _context.Employees.FindAsync(id);
                if (employee == null)
                {
                    return NotFound();
                }

                // Check if phone number already exists for other employees
                var existingEmployee = await _context.Employees
                    .FirstOrDefaultAsync(e => e.PhoneNumber == phoneNumber && e.Id != id);

                if (existingEmployee != null)
                {
                    TempData["ErrorMessage"] = "Nomor HP sudah terdaftar untuk karyawan lain";
                    return RedirectToPage();
                }

                // Validate required fields
                if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(position) ||
                    string.IsNullOrWhiteSpace(phoneNumber) || string.IsNullOrWhiteSpace(address) ||
                    string.IsNullOrWhiteSpace(workShift))
                {
                    TempData["ErrorMessage"] = "Semua field wajib diisi";
                    return RedirectToPage();
                }

                employee.FullName = fullName.Trim();
                employee.Position = position;
                employee.PhoneNumber = phoneNumber.Trim();
                employee.Address = address.Trim();
                employee.HireDate = hireDate;
                employee.WorkShift = workShift;
                employee.IsActive = isActive;
                employee.UpdatedAt = DateTime.Now;

                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = $"Data karyawan {employee.FullName} berhasil diupdate!";
                return RedirectToPage();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Terjadi kesalahan saat mengupdate data karyawan: " + ex.Message;
                return RedirectToPage();
            }
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            try
            {
                var employee = await _context.Employees.FindAsync(id);
                if (employee == null)
                {
                    return NotFound();
                }

                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = $"Karyawan {employee.FullName} berhasil dihapus!";
                return new JsonResult(new { success = true });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, message = ex.Message });
            }
        }

        // Helper method to get employee statistics
        public async Task<object> GetEmployeeStatisticsAsync()
        {
            var employees = await _context.Employees.ToListAsync();
            
            return new
            {
                TotalEmployees = employees.Count,
                ActiveEmployees = employees.Count(e => e.IsActive),
                InactiveEmployees = employees.Count(e => !e.IsActive),
                PositionBreakdown = employees.GroupBy(e => e.Position)
                    .Select(g => new { Position = g.Key, Count = g.Count() })
                    .OrderByDescending(x => x.Count)
                    .ToList(),
                ShiftBreakdown = employees.GroupBy(e => e.WorkShift)
                    .Select(g => new { Shift = g.Key, Count = g.Count() })
                    .ToList(),
                RecentHires = employees.Where(e => e.HireDate >= DateTime.Now.AddDays(-30))
                    .OrderByDescending(e => e.HireDate)
                    .Take(5)
                    .Select(e => new { e.FullName, e.Position, e.HireDate })
                    .ToList()
            };
        }
    }
}