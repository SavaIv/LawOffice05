using LawOffice05.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawOffice05.Infrastructure.Data
{
    public class Senior
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(30)]
        public string Position { get; set; }        

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public IEnumerable<Case> Cases { get; init; } = new List<Case>();
    }
}
