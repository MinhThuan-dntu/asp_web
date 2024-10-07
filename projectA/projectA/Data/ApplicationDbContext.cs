using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using projectA.Models;

namespace projectA.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<TheLoaiViewModel> TheLoai { get; set; }
        public DbSet<SanPhamViewModel> SanPham { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}