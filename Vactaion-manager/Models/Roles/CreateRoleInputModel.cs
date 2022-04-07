using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vactaion_manager.Models.Roles
{
    public class CreateRoleInputModel
    {
        [Required]
        public string Type { get; set; }
    }
}
