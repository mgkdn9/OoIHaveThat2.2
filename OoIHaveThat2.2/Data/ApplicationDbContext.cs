using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using OoIHaveThat2._2.Models;

namespace OoIHaveThat2._2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<OoIHaveThat2._2.Models.User> User { get; set; } = default!;
        public DbSet<OoIHaveThat2._2.Models.ToolRequest> ToolRequest { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToolRequest>()
                .HasOne(tR => tR.User)
                .WithMany(u => u.ToolRequests)
                .HasForeignKey(tR => tR.UserId);
        }
    }
}