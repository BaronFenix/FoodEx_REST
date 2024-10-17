using FoodEx.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodEx.Domain
{
    public class OrderProduct : BaseEntity
    {
        public int Quantity { get; set; }
        
        public Order? Order { get; set; }
        public Product? Product { get; set; }


        public OrderProduct() { }
        public OrderProduct(int quantity, Order order, Product product) 
        {
            this.Quantity = quantity;
            this.Product = product;
            this.Order = order;
        }

    }
}
