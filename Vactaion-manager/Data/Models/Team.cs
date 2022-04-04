using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vacation_manager.Data.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public int LeaderId { get; set; }

        public virtual User Leader { get; set; }

        public ICollection<User> Users { get; set; }

        public ICollection<Project> Projects { get; set; }
    }
}
