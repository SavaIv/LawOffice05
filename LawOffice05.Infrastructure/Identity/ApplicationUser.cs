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
    }
}
