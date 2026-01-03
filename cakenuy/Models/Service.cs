using System.ComponentModel.DataAnnotations;

namespace cakenuy.Models
{
    public class Service
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nama layanan wajib diisi")]
        [StringLength(100, ErrorMessage = "Nama layanan tidak boleh lebih dari 100 karakter")]
        [Display(Name = "Nama Layanan")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Deskripsi wajib diisi")]
        [StringLength(500, ErrorMessage = "Deskripsi tidak boleh lebih dari 500 karakter")]
        [Display(Name = "Deskripsi")]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Status")]
        public bool IsActive { get; set; } = true;

        [Display(Name = "Icon")]
        [StringLength(50, ErrorMessage = "Icon tidak boleh lebih dari 50 karakter")]
        public string Icon { get; set; } = string.Empty;

        [Display(Name = "Warna")]
        [StringLength(20, ErrorMessage = "Warna tidak boleh lebih dari 20 karakter")]
        public string Color { get; set; } = string.Empty;

        [Display(Name = "Urutan")]
        public int SortOrder { get; set; } = 0;

        [Display(Name = "Tanggal Dibuat")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Display(Name = "Tanggal Diupdate")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Helper properties for display
        [Display(Name = "Status")]
        public string StatusDisplay => IsActive ? "Aktif" : "Nonaktif";

        [Display(Name = "Icon Display")]
        public string IconDisplay => string.IsNullOrEmpty(Icon) ? "🍽️" : Icon;
    }

    public static class ServiceDefaults
    {
        public static readonly List<(string Name, string Description, string Icon, string Color)> DefaultServices = new()
        {
            ("Dine In", "Makan di tempat dengan suasana nyaman dan pelayanan langsung dari staff kami", "🍽️", "bg-success"),
            ("Take Away", "Pesan dan ambil langsung di toko, praktis untuk dibawa pulang", "🥡", "bg-warning"),
            ("Delivery Order", "Pesan online dan kami antar langsung ke alamat Anda", "🚚", "bg-info")
        };

        public static readonly List<string> AvailableIcons = new()
        {
            "🍽️", "🥡", "🚚", "📱", "💳", "🎂", "🧁", "☕", "🍰", "🎉", 
            "🏪", "🛍️", "📦", "🚀", "⭐", "💝", "🎈", "🌟", "✨", "🎊"
        };

        public static readonly List<(string Name, string Class)> AvailableColors = new()
        {
            ("Pink", "bg-pink"),
            ("Hijau", "bg-success"),
            ("Biru", "bg-info"),
            ("Kuning", "bg-warning"),
            ("Merah", "bg-danger"),
            ("Ungu", "bg-purple"),
            ("Abu-abu", "bg-secondary")
        };
    }
}