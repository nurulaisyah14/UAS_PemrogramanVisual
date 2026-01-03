using Microsoft.EntityFrameworkCore;
using cakenuy.Models;

namespace cakenuy.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure decimal precision for Price
            modelBuilder.Entity<MenuItem>()
                .Property(m => m.Price)
                .HasPrecision(18, 2);

            // Configure Employee entity
            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.PhoneNumber)
                .IsUnique();

            modelBuilder.Entity<Employee>()
                .Property(e => e.FullName)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Position)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Employee>()
                .Property(e => e.PhoneNumber)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Address)
                .IsRequired()
                .HasMaxLength(200);

            modelBuilder.Entity<Employee>()
                .Property(e => e.WorkShift)
                .IsRequired()
                .HasMaxLength(50);

            // Configure Service entity
            modelBuilder.Entity<Service>()
                .Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Service>()
                .Property(s => s.Description)
                .IsRequired()
                .HasMaxLength(500);

            modelBuilder.Entity<Service>()
                .Property(s => s.Icon)
                .HasMaxLength(50);

            modelBuilder.Entity<Service>()
                .Property(s => s.Color)
                .HasMaxLength(20);

            // Configure Order entity
            modelBuilder.Entity<Order>()
                .Property(o => o.CustomerName)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Order>()
                .Property(o => o.PhoneNumber)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<Order>()
                .Property(o => o.Email)
                .HasMaxLength(100);

            modelBuilder.Entity<Order>()
                .Property(o => o.DeliveryAddress)
                .HasMaxLength(500);

            modelBuilder.Entity<Order>()
                .Property(o => o.Notes)
                .HasMaxLength(1000);

            modelBuilder.Entity<Order>()
                .Property(o => o.TotalAmount)
                .HasPrecision(18, 2);

            // Configure relationships
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Service)
                .WithMany()
                .HasForeignKey(o => o.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.MenuItem)
                .WithMany()
                .HasForeignKey(oi => oi.MenuItemId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderItem>()
                .Property(oi => oi.UnitPrice)
                .HasPrecision(18, 2);

            // Configure User entity
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<User>()
                .Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<User>()
                .Property(u => u.FullName)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<User>()
                .Property(u => u.Role)
                .HasMaxLength(20);

            // Seed data
            modelBuilder.Entity<MenuItem>().HasData(
                new MenuItem
                {
                    Id = 1,
                    Name = "Chocolate Delight",
                    Description = "Kue coklat berlapis dengan frosting coklat krim yang lembut, dihiasi chocolate shavings dan buah berry segar.",
                    Price = 180000,
                    ImageUrl = "/images/chocolate_cake.png",
                    Category = "Cake",
                    IsAvailable = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new MenuItem
                {
                    Id = 2,
                    Name = "Strawberry Bliss",
                    Description = "Kue strawberry segar dengan krim lembut dan strawberry premium di setiap lapisan. Sempurna untuk perayaan spesial.",
                    Price = 200000,
                    ImageUrl = "/images/strawberry_cake.png",
                    Category = "Cake",
                    IsAvailable = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new MenuItem
                {
                    Id = 3,
                    Name = "Vanilla Dream Cupcakes",
                    Description = "Set 6 cupcake vanilla dengan frosting pink yang manis, ditaburi sprinkles warna-warni. Cocok untuk acara kecil.",
                    Price = 85000,
                    ImageUrl = "/images/vanilla_cupcake.png",
                    Category = "Cupcake",
                    IsAvailable = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new MenuItem
                {
                    Id = 4,
                    Name = "Red Velvet Romance",
                    Description = "Kue red velvet klasik dengan cream cheese frosting yang creamy. Warna merah menawan dengan rasa yang tak terlupakan.",
                    Price = 195000,
                    ImageUrl = "/images/red_velvet_cake.png",
                    Category = "Cake",
                    IsAvailable = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new MenuItem
                {
                    Id = 5,
                    Name = "Matcha Heaven",
                    Description = "Kue matcha premium dengan krim putih lembut, ditaburi bubuk matcha pilihan. Perpaduan rasa manis dan pahit yang sempurna.",
                    Price = 175000,
                    ImageUrl = "/images/matcha_cake.png",
                    Category = "Cake",
                    IsAvailable = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new MenuItem
                {
                    Id = 6,
                    Name = "Tiramisu Classic",
                    Description = "Tiramisu Italia autentik dengan ladyfinger yang direndam kopi espresso dan mascarpone cream. Ditaburi cocoa powder premium.",
                    Price = 185000,
                    ImageUrl = "/images/tiramisu_cake.png",
                    Category = "Cake",
                    IsAvailable = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            );

            // Seed Service data
            modelBuilder.Entity<Service>().HasData(
                new Service
                {
                    Id = 1,
                    Name = "Dine In",
                    Description = "Makan di tempat dengan suasana nyaman dan pelayanan langsung dari staff kami",
                    Icon = "🍽️",
                    Color = "bg-success",
                    IsActive = true,
                    SortOrder = 1,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Service
                {
                    Id = 2,
                    Name = "Take Away",
                    Description = "Pesan dan ambil langsung di toko, praktis untuk dibawa pulang",
                    Icon = "🥡",
                    Color = "bg-warning",
                    IsActive = true,
                    SortOrder = 2,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Service
                {
                    Id = 3,
                    Name = "Delivery Order",
                    Description = "Pesan online dan kami antar langsung ke alamat Anda",
                    Icon = "🚚",
                    Color = "bg-info",
                    IsActive = true,
                    SortOrder = 3,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            );

            // Seed User data
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "admin",
                    Password = "admin123", // In production, this should be hashed
                    FullName = "Administrator",
                    Email = "admin@cakenuy.com",
                    Role = "Admin",
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new User
                {
                    Id = 2,
                    Username = "user",
                    Password = "user123", // In production, this should be hashed
                    FullName = "User Demo",
                    Email = "user@cakenuy.com",
                    Role = "User",
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            );
        }
    }
}