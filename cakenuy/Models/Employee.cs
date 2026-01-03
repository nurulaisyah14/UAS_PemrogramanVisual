using System.ComponentModel.DataAnnotations;

namespace cakenuy.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nama lengkap wajib diisi")]
        [StringLength(100, ErrorMessage = "Nama tidak boleh lebih dari 100 karakter")]
        [Display(Name = "Nama Lengkap")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Jabatan wajib dipilih")]
        [Display(Name = "Jabatan")]
        public string Position { get; set; } = string.Empty;

        [Required(ErrorMessage = "No. HP wajib diisi")]
        [Phone(ErrorMessage = "Format nomor HP tidak valid")]
        [Display(Name = "No. HP")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Alamat wajib diisi")]
        [StringLength(200, ErrorMessage = "Alamat tidak boleh lebih dari 200 karakter")]
        [Display(Name = "Alamat")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "Tanggal masuk wajib diisi")]
        [Display(Name = "Tanggal Masuk")]
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }

        [Display(Name = "Status")]
        public bool IsActive { get; set; } = true;

        [Required(ErrorMessage = "Shift kerja wajib dipilih")]
        [Display(Name = "Shift Kerja")]
        public string WorkShift { get; set; } = string.Empty;

        [Display(Name = "Tanggal Dibuat")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Display(Name = "Tanggal Diupdate")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Helper properties for display
        [Display(Name = "Status")]
        public string StatusDisplay => IsActive ? "Aktif" : "Nonaktif";

        [Display(Name = "Lama Kerja")]
        public string WorkDuration
        {
            get
            {
                var duration = DateTime.Now - HireDate;
                var years = duration.Days / 365;
                var months = (duration.Days % 365) / 30;
                
                if (years > 0)
                    return $"{years} tahun {months} bulan";
                else if (months > 0)
                    return $"{months} bulan";
                else
                    return $"{duration.Days} hari";
            }
        }
    }

    public static class EmployeePositions
    {
        public static readonly List<string> Positions = new()
        {
            "Admin",
            "Supervisor", 
            "Kasir",
            "Barista",
            "Baker",
            "Decorator",
            "Delivery"
        };
    }

    public static class WorkShifts
    {
        public static readonly List<string> Shifts = new()
        {
            "Pagi (06:00 - 14:00)",
            "Siang (14:00 - 22:00)", 
            "Malam (22:00 - 06:00)"
        };
    }
}