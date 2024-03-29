﻿using System.ComponentModel.DataAnnotations;

namespace AvaloniaBankAppEF.Entities
{
    public class NamedEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
    }
}
