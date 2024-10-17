using FoodEx.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodEx.Domain
{
    public class Product : BaseEntity
    {
        [MaxLength(50), Required]
        public string? Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public string? ImagePath { get; set; }

        [NotMapped]
        public int Quantity { get; set; } = 0;

        public Restaurant? Restaurant { get; set; }
        public Category? Category { get; set; }
    }
}
