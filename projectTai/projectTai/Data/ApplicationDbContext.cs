﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using projectTai.Controllers;
using projectTai.Models;
using ProjectTai.Models;

namespace projectTai.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<TheLoai> TheLoai { get; set; }
        public DbSet<SanPham> SanPham { get; set; }
        public DbSet<ApplicationUser> applicationUsers { get; set; }
    }
}
