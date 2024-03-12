using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WAZ_Assessment.Models;

namespace WAZ_Assessment
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<Login> Login { get; set; }
        public DbSet<Platform> Platform { get; set; }
        public DbSet<Well> Well { get; set; }
        public DbSet<PlatformDummy> PlatformDummy { get; set; }
        public DbSet<WellDummy> WellDummy { get; set; }
    }
}