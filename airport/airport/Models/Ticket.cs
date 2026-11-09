using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace airline_system.Models
{
    public class Ticket
    {
        [Key]
        public int Ticket_ID { get; set; }

        [ForeignKey("Flight")]
        public int Flight_ID { get; set; }
        public Flight Flight { get; set; } = null!;

        [ForeignKey("Passenger")]
        public int Passenger_ID { get; set; }
        public Passenger Passenger { get; set; } = null!;

        [Required]
        public string Class { get; set; } = string.Empty;

        [Required]
        public string Seat_No { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        // Navigation property
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
