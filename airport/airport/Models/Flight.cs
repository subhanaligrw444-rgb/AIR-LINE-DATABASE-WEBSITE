using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace airline_system.Models
{
    public class Flight
    {
        [Key]
        public int Flight_ID { get; set; }

        [Required]
        public string Flight_No { get; set; } = string.Empty;

        [ForeignKey("OriginAirport")]
        public int Origin_ID { get; set; }
        public Airport OriginAirport { get; set; } = null!;

        [ForeignKey("DestinationAirport")]
        public int Dest_ID { get; set; }
        public Airport DestinationAirport { get; set; } = null!;

        [ForeignKey("Aircraft")]
        public int Aircraft_ID { get; set; }
        public Aircraft Aircraft { get; set; } = null!;

        [Required]
        public DateTime Arr_Time { get; set; }

        [Required]
        public DateTime Dep_Time { get; set; }

        [Required]
        public string Status { get; set; } = "Scheduled";

        // Navigation properties
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
        public ICollection<CrewDetails> CrewDetails { get; set; } = new List<CrewDetails>();
    }
}
