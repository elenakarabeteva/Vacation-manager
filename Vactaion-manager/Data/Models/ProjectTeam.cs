using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vactaion_manager.Data.Models
{
    public class ProjectTeam
    {
        [ForeignKey(nameof(Project))]
        public int ProjectId { get; set; }

        public Project Project { get; set; }

        [ForeignKey(nameof(Team))]
        public int TeamId { get; set; }

        public Team Team { get; set; }
    }
}
