using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Vacation_manager.Data.Models;

namespace Vactaion_manager.Models.Vacations
{
    public class UpdateVacationInputModel
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public bool HalfADayVacation { get; set; }

        [Required]
        public bool Accepted { get; set; }
    }
}
