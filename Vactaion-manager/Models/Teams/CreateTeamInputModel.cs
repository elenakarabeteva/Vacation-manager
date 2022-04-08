using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Vactaion_manager.Data.Models;

namespace Vactaion_manager.Models.Teams
{
    public class CreateTeamInputModel
    {
        [Required]
        public string Name { get; set; }

        public virtual User Leader { get; set; }
    }
}
