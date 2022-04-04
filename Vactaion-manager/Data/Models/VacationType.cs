using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vacation_manager.Data.Models
{
    public class VacationType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Type { get; set; }
    }
}
