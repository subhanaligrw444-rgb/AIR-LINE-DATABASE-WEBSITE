using System.ComponentModel.DataAnnotations;

namespace airline_system.Models
{
    public class Staff
    {
        [Key]
        public int Staff_ID { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Phone_No { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Role { get; set; } = string.Empty;

        // Navigation property
        public ICollection<CrewDetails> CrewDetails { get; set; } = new List<CrewDetails>();
    }
}
