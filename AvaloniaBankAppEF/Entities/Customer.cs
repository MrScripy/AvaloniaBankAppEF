using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AvaloniaBankAppEF.Entities
{
    public class Customer : NamedEntity
    {
        [Required]
        public string? Patronymic { get; set; }
        [Required]
        public string? Surname { get; set; }
        [Required]
        public string? Phone { get; set; }
        [Required]
        public string? Mail { get; set; }

        public List<Order> Deals { get; set; } = new();
    }
}
