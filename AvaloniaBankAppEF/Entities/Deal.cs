using System.ComponentModel.DataAnnotations;

namespace AvaloniaBankAppEF.Entities
{
    internal class Deal : NamedEntity
    {
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

        [Required]
        public string? Mail { get; set; } 
        public int ItemCode { get; set; }
    }
}
