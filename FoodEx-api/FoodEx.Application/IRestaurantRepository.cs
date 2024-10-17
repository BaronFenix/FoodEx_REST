using FoodEx.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodEx.Application
{
    public interface IRestaurantRepository : IGenericRepository<Restaurant>
    {
        public Task<List<Restaurant>> SearchByName(string query);
        public Task<List<Restaurant>> FindAllByCuisine(string cuisine);
        public Task<Restaurant> FindByName(string name);
    }
}
