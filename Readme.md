<div align="center">
Made with ❤️ by Nurul Aisyah
</div>

## 👤 Profil Mahasiswa

| Atribut         | Keterangan            |
| --------------- | --------------------- |
| **Nama**        | Nurul Aisyah         |
| **NIM**         | 312310476             |
| **Kelas**       | TI.23.A.5             |
| **Mata Kuliah** | Pemrograman Visual |
| **Link Youtube** | wait |


# 📌 Tugas UAS
# 🍰 Cakenuy — Deployment & Setup Guide

> Panduan instalasi & konfigurasi aplikasi **Cakecute**  
> Berbasis **IIS**, **MongoDB**, dan **SQL Server**

---

## 🧰 Prasyarat

Pastikan environment kamu sudah memiliki:

- **Windows + IIS (Internet Information Services)**
- **.NET Runtime / Hosting Bundle** (sesuai versi aplikasi)
- **Microsoft SQL Server + SSMS**
- **MongoDB**
- (Opsional) **Git** untuk clone project

---

✨ *Simple • Modern • Friendly* ✨  

![ASP.NET](https://img.shields.io/badge/ASP.NET%20Core-8.0-purple)
![SQLite](https://img.shields.io/badge/Database-SQLite-blue)
![Bootstrap](https://img.shields.io/badge/UI-Bootstrap%205-pink)
![Status](https://img.shields.io/badge/Status-Development-success)

📍 **Subang, Jawa Barat**

</div>

---

## 📖 Tentang Proyek

**Sweet Delight Nusantara** adalah aplikasi web yang dikembangkan untuk membantu **toko kue lokal** dalam mengelola operasional usaha yang sebelumnya masih dilakukan secara manual.

Website ini dibuat untuk:
- Mengelola menu kue secara terpusat  
- Memudahkan pelanggan melakukan pemesanan online  
- Membantu admin dan staff memproses pesanan  
- Menghasilkan struk digital secara otomatis  

---

## 🎯 Tujuan Sistem

- ✅ Mengurangi kesalahan pencatatan manual  
- ✅ Mempercepat proses pemesanan  
- ✅ Memberikan pengalaman pengguna yang lebih baik  
- ✅ Mendukung digitalisasi usaha toko kue  
## 📘 Cara Menggunakan Aplikasi Cakenuy

1. Menjalankan Aplikasi
   - Buka project menggunakan Visual Studio
   - Jalankan aplikasi (Run / dotnet run)
   - Buka browser dan akses:
     http://localhost:5004

2. Login ke Sistem
   - Akses halaman login:
     http://localhost:5004/Login

   - Gunakan akun demo berikut:
     Admin
     Username : admin
     Password : admin123

     User
     Username : user
     Password : user123

3. Menggunakan Fitur Sistem
   - Pilih menu kue yang tersedia
   - Tambahkan menu ke keranjang
   - Pilih layanan pemesanan:
     • Dine In
     • Take Away
     • Delivery
   - Isi data pelanggan
   - Konfirmasi dan kirim pesanan

4. Melihat Struk Pesanan
   - Setelah pesanan berhasil:
     • Struk digital akan ditampilkan otomatis
     • Detail pesanan dan total pembayaran dapat dilihat

5. Cetak atau Unduh Struk
   - Struk dapat:
     • Dicetak langsung melalui browser
     • Diunduh dalam format PDF

6. Logout dari Sistem
   - Klik nama pengguna pada navigation bar
   - Pilih menu Logout
   - Atau akses langsung:
     http://localhost:5004/Logout
---

## ⚙️ Teknologi yang Digunakan

```txt
Backend   : ASP.NET Core 8.0 (Razor Pages)
Frontend  : Bootstrap 5, CSS, JavaScript
Database  : SQLite + Entity Framework Core
Icons     : Font Awesome
PDF       : jsPDF & html2canvas
📂 Struktur Folder
txt
Salin kode
SweetDelightNusantara
│
├── Data
│   └── ApplicationDbContext.cs
│
├── Models
│   ├── User.cs
│   ├── MenuItem.cs
│   ├── Order.cs
│   ├── OrderItem.cs
│   ├── Service.cs
│   └── Employee.cs
│
├── Pages
│   ├── Auth
│   ├── Menu
│   ├── Orders
│   ├── Employees
│   └── Services
│
├── wwwroot
│   ├── css
│   ├── js
│   └── images
│
└── README.md
🧩 Contoh Kode (Clean & Rapi)
csharp
Salin kode
public class MenuItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public bool IsAvailable { get; set; } = true;
}
🔐 Akun Demo
Role	Username	Password
Admin	admin	admin123
User	user	user123

🛒 Layanan Pemesanan
🍽️ Dine In

🥡 Take Away

🚚 Delivery Order

🧾 Fitur Unggulan
🧁 Manajemen Menu

👨‍🍳 Manajemen Karyawan

🛍️ Pemesanan Online

📄 Struk Digital & PDF

📱 Responsive Design
