using System.ComponentModel.DataAnnotations;

namespace cakenuy.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nama pelanggan wajib diisi")]
        [StringLength(100, ErrorMessage = "Nama tidak boleh lebih dari 100 karakter")]
        [Display(Name = "Nama Pelanggan")]
        public string CustomerName { get; set; } = string.Empty;

        [Required(ErrorMessage = "No. HP wajib diisi")]
        [Phone(ErrorMessage = "Format nomor HP tidak valid")]
        [Display(Name = "No. HP")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Format email tidak valid")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Pilih layanan")]
        [Display(Name = "Layanan")]
        public int ServiceId { get; set; }

        [Display(Name = "Alamat Pengiriman")]
        [StringLength(500, ErrorMessage = "Alamat tidak boleh lebih dari 500 karakter")]
        public string DeliveryAddress { get; set; } = string.Empty;

        [Display(Name = "Catatan Khusus")]
        [StringLength(1000, ErrorMessage = "Catatan tidak boleh lebih dari 1000 karakter")]
        public string? Notes { get; set; } = string.Empty;

        [Required(ErrorMessage = "Tanggal pengambilan/pengiriman wajib diisi")]
        [Display(Name = "Tanggal & Waktu Pengambilan/Pengiriman")]
        public DateTime OrderDateTime { get; set; } = DateTime.Now.AddHours(2);

        [Display(Name = "Total Harga")]
        public decimal TotalAmount { get; set; }

        [Display(Name = "Status Pesanan")]
        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        [Display(Name = "Tanggal Dibuat")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Display(Name = "Tanggal Diupdate")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Navigation properties
        public Service? Service { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new();

        // Helper properties
        [Display(Name = "Status")]
        public string StatusDisplay => Status switch
        {
            OrderStatus.Pending => "Menunggu Konfirmasi",
            OrderStatus.Confirmed => "Dikonfirmasi",
            OrderStatus.InProgress => "Sedang Diproses",
            OrderStatus.Ready => "Siap Diambil/Dikirim",
            OrderStatus.Completed => "Selesai",
            OrderStatus.Cancelled => "Dibatalkan",
            _ => "Unknown"
        };

        [Display(Name = "Status Color")]
        public string StatusColor => Status switch
        {
            OrderStatus.Pending => "bg-warning",
            OrderStatus.Confirmed => "bg-info",
            OrderStatus.InProgress => "bg-primary",
            OrderStatus.Ready => "bg-success",
            OrderStatus.Completed => "bg-success",
            OrderStatus.Cancelled => "bg-danger",
            _ => "bg-secondary"
        };
    }

    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int MenuItemId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice => Quantity * UnitPrice;
        public string Notes { get; set; } = string.Empty;

        // Navigation properties
        public Order? Order { get; set; }
        public MenuItem? MenuItem { get; set; }
    }

    public enum OrderStatus
    {
        Pending = 0,
        Confirmed = 1,
        InProgress = 2,
        Ready = 3,
        Completed = 4,
        Cancelled = 5
    }
}