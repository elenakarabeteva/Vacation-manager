using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vactaion_manager.Data.Models
{
    public class Team
    {
        public Team()
        {
            this.Users = new HashSet<User>();
            this.ProjectTeams = new HashSet<ProjectTeam>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public int LeaderId { get; set; }

        public virtual User Leader { get; set; }

        public ICollection<User> Users { get; set; }

        public ICollection<ProjectTeam> ProjectTeams { get; set; }
    }
}
