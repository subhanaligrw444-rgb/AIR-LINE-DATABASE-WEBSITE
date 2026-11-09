using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace airline_system.Models
{
    public class Payment
    {
        [Key]
        public int Payment_ID { get; set; }

        [ForeignKey("Ticket")]
        public int Ticket_ID { get; set; }
        public Ticket Ticket { get; set; } = null!;

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }

        [Required]
        public DateTime Payment_Date { get; set; }

        [Required]
        public string Payment_Method { get; set; } = string.Empty;

        [Required]
        public string Currency { get; set; } = "PKR";

        [Required]
        public string Transaction_Status { get; set; } = "Pending";
    }
}
