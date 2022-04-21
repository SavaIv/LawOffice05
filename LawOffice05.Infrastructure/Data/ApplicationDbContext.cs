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

        public DbSet<Case> Cases { get; set; }
        public DbSet<Instance> Instances { get; set; }
        public DbSet<OutsideDocument> OutsideDocuments { get; set; }
        public DbSet<InsideDocument> InsideDocuments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CompanyInfo> CompanyInfos { get; set; }
        public DbSet<OrderProblemType> OrderProblemTypes { get; set; }
    }
}