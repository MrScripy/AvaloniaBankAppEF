
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AvaloniaBankAppEF.Entities
{
    internal class Customer : NamedEntity
    {
        [Required]
        public string? Patronymic { get; set; }
        [Required]
        public string? Surname { get; set; }
        [Required]
        public string? Phone { get; set; }
        [Required]
        public string? Mail { get; set; }

        public List<Deal> Deals { get; set; } = new();
    }
}
