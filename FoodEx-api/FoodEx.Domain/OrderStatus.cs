using FoodEx.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodEx.Domain
{
    public class OrderStatus : BaseEntity
    {
        [MaxLength(30), Required]
        public string? Name { get; set; }

        public OrderStatus() { }

        public OrderStatus(string name) 
        {
            this.Name = name;
        }

    }
}
