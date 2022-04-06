using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vacation_manager.Data.Models
{
    public class Project
    {
        public Project()
        {
            this.ProjectTeams = new HashSet<ProjectTeam>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual ICollection<ProjectTeam> ProjectTeams { get; set; }
    }
}
