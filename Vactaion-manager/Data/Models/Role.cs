using System.ComponentModel.DataAnnotations;

namespace Vacation_manager.Data.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Type { get; set; }
    }
}
