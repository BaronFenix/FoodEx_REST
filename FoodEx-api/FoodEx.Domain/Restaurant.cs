using FoodEx.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodEx.Domain
{
    public class Restaurant : BaseEntity
    {
        [MaxLength(50), Required]
        public string? Name { get; set; }

        [MaxLength(30)]
        public string? Address { get; set; }

        public string? Description { get; set; }

        [Required]
        public string? PreviewImagePath { get; set; }

        [Required]
        public string? HeaderImagePath { get; set; }


    }
}
