using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace airline_system.Models
{
    public class Airport
    {
        [Key]
        public int Airport_ID { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Country_Name { get; set; } = string.Empty;

        [Required]
        public string City { get; set; } = string.Empty;

        [Required]
        public string IATA_Code { get; set; } = string.Empty;

        // Navigation properties
        [InverseProperty("OriginAirport")]
        public ICollection<Flight> OriginFlights { get; set; } = new List<Flight>();

        [InverseProperty("DestinationAirport")]
        public ICollection<Flight> DestinationFlights { get; set; } = new List<Flight>();
    }
}
