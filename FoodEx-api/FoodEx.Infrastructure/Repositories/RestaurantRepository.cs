using FoodEx.Application;
using FoodEx.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodEx.Infrastructure.Repositories
{
    public class RestaurantRepository : GenericRepository<Restaurant>, IRestaurantRepository
    {
        private readonly ApplicationContext _context;
        public RestaurantRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Restaurant>> FindAllByCuisine(string cuisine)
        {
            return await _context.RestaurantCuisines
                .Where(x => x.Cuisine.Name == cuisine)
                .Select(x => x.Restaurant).ToListAsync();
        }

        public async Task<List<Restaurant>> SearchByName(string query)
        {
            return await _context.Restaurants.Where(x => x.Name.Contains(query)).ToListAsync();
        }

        public async Task<Restaurant> FindByName(string name)
        {
            return await _context.Restaurants.Where(x => x.Name == name).FirstOrDefaultAsync();
        }
    }
}
