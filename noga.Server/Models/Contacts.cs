using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace NOGA.Server.Models
{

    public class Contacts
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? FullName { get; set; }

        [StringLength(20)]
        public string OfficeNumber { get; set; }

        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        [JsonIgnore]
        public Customers Customer { get; set; }
        
        [Required]
      
        public bool isDeleted { get; set; }

        [Required]
       
        public DateTime CreatedAt { get; set; }

    }
}
