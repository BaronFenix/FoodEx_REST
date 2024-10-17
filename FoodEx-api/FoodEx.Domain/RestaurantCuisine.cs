using FoodEx.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodEx.Domain
{
    public class RestaurantCuisine : BaseEntity
    {
        public Restaurant? Restaurant { get; set; }
        public Cuisine? Cuisine { get; set; }
    }
}
