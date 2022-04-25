using LawOffice05.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LawOffice05.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(50)]
        public string? FirstName { get; set; }

        [StringLength(50)]
        public string? LastName { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();

        //public ICollection<Case> Cases { get; set; } = new List<Case>();
    }
}
