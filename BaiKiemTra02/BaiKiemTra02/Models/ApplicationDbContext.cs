using Microsoft.EntityFrameworkCore;

namespace BaiKiemTra02.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<LopHoc> LopHocs { get; set; }
    }
}