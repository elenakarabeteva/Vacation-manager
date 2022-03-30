using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vacation_manager.Data.Models
{
    public class Vacation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        public bool HalfADayVacation { get; set; }

        [Required]
        public bool Accepted { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

        public User User { get; set; }

        [Required]
        [ForeignKey(nameof(VacationType))]
        public int TypeId { get; set; }

        public Type Type { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public int AcceptedByUserId { get; set; }
    }
}
