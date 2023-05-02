using ExpressV.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExpressV.Data
{
    public class ExpressVContext : IdentityDbContext
    {
        public ExpressVContext(DbContextOptions<ExpressVContext> options)
            : base(options)
        {
        }
        public DbSet<Inventaire> Inventaires { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Inventaire>().ToTable("Inventaire");
        }
    }
}