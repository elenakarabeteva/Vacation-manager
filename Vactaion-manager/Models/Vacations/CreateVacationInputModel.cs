﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Vactaion_manager.Data.Models;

namespace Vactaion_manager.Models.Vacations
{
    public class CreateVacationInputModel
    {
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

        public User user { get; set; }

        public User AcceptedByUser { get; set; }
    }
}