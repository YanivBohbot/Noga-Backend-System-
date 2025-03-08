using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace NOGA.Server.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Street { get; set; }

        [Required]
        [StringLength(100)]
        public string City { get; set; }

        [Required]
        [ForeignKey("Customer")]  // מפתח זר
        public int CustomerId { get; set; }

        [Required]
        [JsonIgnore]
        public bool isDeleted { get; set; }
        
        [Required]
       
        public DateTime CreatedAt { get; set; }

        [JsonIgnore] // התעלמות משדה זה בסריאליזציה
        public Customers Customer { get; set; }



    }
}
