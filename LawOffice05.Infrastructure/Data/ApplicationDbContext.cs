using LawOffice05.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LawOffice05.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Case>()
                .HasOne(c => c.User)
                .WithMany(u => u.Cases)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Instance>()
                .HasOne(i => i.Case)
                .WithMany(c => c.Instances)
                .HasForeignKey(i => i.CaseId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<InsideDocument>()
                .HasOne(d => d.Instance)
                .WithMany(i => i.InsideDocuments)
                .HasForeignKey(d => d.InstanceId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<OutsideDocument>()
                .HasOne(d => d.Instance)
                .WithMany(i => i.OutsideDocuments)
                .HasForeignKey(d => d.InstanceId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }

        public DbSet<Case> Cases { get; set; }
        public DbSet<Instance> Instances { get; set; }
        public DbSet<OutsideDocument> OutsideDocuments { get; set; }
        public DbSet<InsideDocument> InsideDocuments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CompanyInfo> CompanyInfos { get; set; }
        public DbSet<OrderProblemType> OrderProblemTypes { get; set; }
    }
}