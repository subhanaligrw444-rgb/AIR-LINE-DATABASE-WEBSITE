using System.ComponentModel.DataAnnotations;

namespace airline_system.Models
{
    public class Passenger
    {
        [Key]
        public int Passenger_ID { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Phone_No { get; set; } = string.Empty;

        [Required]
        public string Passport_No { get; set; } = string.Empty;

        [Required]
        public string Nationality { get; set; } = string.Empty;

        // Navigation property
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
