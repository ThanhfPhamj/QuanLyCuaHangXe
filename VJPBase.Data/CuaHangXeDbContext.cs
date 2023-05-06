using Microsoft.EntityFrameworkCore;
using VJPBase.Data.Entities;


namespace VJPBase.Data
{
    public class CuaHangXeDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }

        public DbSet<KhachHang> KhachHangs { get; set; }

        public DbSet<ChucVu> ChucVus { get; set; }
        public DbSet<CuaHang> CuaHangs { get; set; }
        public DbSet<Xe> Xes { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        public DbSet<HangXe> HangXes { get; set; }
        public DbSet<LoaiXe> LoaiXes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=QuanLyCuaHangXe;Trusted_Connection=True;user id = sa ; password = 123");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //NHAN VIEN
            modelBuilder.Entity<NhanVien>()
                .HasOne<ChucVu>(cv => cv.ChucVus)
                .WithMany(nv => nv.NhanViens)
                .HasForeignKey(nv => nv.MaChucVu);

            modelBuilder.Entity<NhanVien>()
                .HasOne(cv => cv.CuaHangs)
                .WithMany(nv => nv.NhanViens)
                .HasForeignKey(nv => nv.MaCuaHang);

            //XE
            modelBuilder.Entity<Xe>()
                .HasOne(hx => hx.HangXes)
                .WithMany(xe => xe.Xes)
                .HasForeignKey(xe => xe.MaHangXe);

            modelBuilder.Entity<Xe>()
                .HasOne(hx => hx.LoaiXes)
                .WithMany(xe => xe.Xes)
                .HasForeignKey(xe => xe.MaLoaiXe);

            //HOA DON
            modelBuilder.Entity<HoaDon>()
               .HasKey(t => new { t.MaHoaDon, t.MaKhachHang, t.MaNhanVien });

            modelBuilder.Entity<HoaDon>()
                .HasOne(t => t.NhanViens)
                .WithMany(t => t.HoaDons)
                .HasForeignKey(t => t.MaNhanVien);

            modelBuilder.Entity<HoaDon>()
                .HasOne(t => t.KhachHangs)
                .WithMany(t => t.HoaDons)
                .HasForeignKey(t => t.MaKhachHang);


            //CHI TIET HOA DON
            modelBuilder.Entity<ChiTietHoaDon>()
               .HasKey(t => new { t.MaXe, t.MaHoaDon });

            modelBuilder.Entity<ChiTietHoaDon>()
                .HasOne(t => t.Xe)
                .WithMany(t => t.ChiTietHoaDons)
                .HasForeignKey(t => t.MaXe);

            modelBuilder.Entity<ChiTietHoaDon>()
                .HasOne(t => t.HoaDon)
                .WithMany(t => t.ChiTietHoaDons)
                .HasForeignKey(cthd => cthd.MaHoaDon)
                .HasPrincipalKey(hd => hd.MaHoaDon);
        }
    }
}
