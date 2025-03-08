namespace NOGA.Server.Models

{
    using System.ComponentModel.DataAnnotations;
    public class Customers
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]  
        [StringLength(9)]  
        [RegularExpression(@"^\d{9}$")]
        public string CustomerNumber { get; set; }
        
        [Required]
        public bool isDeleted { get; set; }
        
        [Required]
        public DateTime CreatedAt { get; set; }

        public ICollection<Address> Addresses { get; set; }
        public ICollection<Contacts> Contacts { get; set; }
    }
}
