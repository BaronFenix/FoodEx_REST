using FoodEx.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace FoodEx.Domain
{
    public class Order : BaseEntity
    {
        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public decimal TotalSum { get; set; }

        public User? User { get; set; }

        public OrderStatus? Status { get; set; }

        public Order() { }

        public Order(User user, OrderStatus orderStatus, decimal totalSum, DateTime date)
        {
            this.User = user;
            this.Status = orderStatus;
            this.TotalSum = totalSum;
            this.OrderDate = date;
        }
    }
}
