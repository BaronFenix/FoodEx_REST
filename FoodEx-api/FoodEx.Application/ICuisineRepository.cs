using FoodEx.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodEx.Application
{
    public interface ICuisineRepository : IGenericRepository<Cuisine>
    {
        public Task<List<Cuisine>> FindCuisinesByRestaurant(string restaurantName);
        public Task<Cuisine> FindByName(string restaurantName);

    }
}
