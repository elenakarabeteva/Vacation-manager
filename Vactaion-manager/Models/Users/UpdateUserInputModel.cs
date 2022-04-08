using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Vactaion_manager.Data.Models;

namespace Vactaion_manager.Models.Users
{
    public class UpdateUserInputModel
    {
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Surname { get; set; }

        public virtual Role Role { get; set; }

        public virtual Team Team { get; set; }
    }
}
