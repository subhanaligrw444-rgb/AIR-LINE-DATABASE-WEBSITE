using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace airline_system.Models
{
    public class CrewDetails
    {
        [Key]
        public int Schedule_ID { get; set; }

        [ForeignKey("Flight")]
        public int Flight_ID { get; set; }
        public Flight Flight { get; set; } = null!;

        [ForeignKey("Staff")]
        public int Staff_ID { get; set; }
        public Staff Staff { get; set; } = null!;

        [Required]
        public string Role { get; set; } = string.Empty;

        [Required]
        public string Shift { get; set; } = string.Empty;
    }
}
