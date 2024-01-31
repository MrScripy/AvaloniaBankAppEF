using System.ComponentModel.DataAnnotations;

namespace AvaloniaBankAppEF.Entities
{
    public class Order : NamedEntity
    {
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

        [Required]
        public string? Mail { get; set; } 
        public int ItemCode { get; set; }
    }
}
