using System.ComponentModel.DataAnnotations;

namespace airline_system.Models
{
    public class Aircraft
    {
        [Key]
        public int Aircraft_ID { get; set; }

        [Required]
        public string Model { get; set; } = string.Empty;

        [Required]
        public int Capacity { get; set; }

        [Required]
        public string Regrestration_No { get; set; } = string.Empty;

        // Navigation property
        public ICollection<Flight> Flights { get; set; } = new List<Flight>();
    }
}
