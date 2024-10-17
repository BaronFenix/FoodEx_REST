using FoodEx.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodEx.Application
{
    public interface IRestaurantCuisineRepository : IGenericRepository<RestaurantCuisine>
    {
        public Task<IEnumerable<RestaurantCuisine>> FindCuisinesAndRestaurants();
    }
}
