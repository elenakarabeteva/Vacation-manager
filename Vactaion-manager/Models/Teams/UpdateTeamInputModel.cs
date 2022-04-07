using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vactaion_manager.Models.Teams
{
    public class UpdateTeamInputModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Required]
        public int LeaderId { get; set; }
    }
}
