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
    [Table("Categories")]
    public class Category : BaseEntity
    {
        [MaxLength(30), Required]
        public string? Name { get; set; }
    }
}
