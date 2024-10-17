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
    public class RestaurantCuisineRepository : GenericRepository<RestaurantCuisine>, IRestaurantCuisineRepository
    {
        private readonly ApplicationContext _context;
        public RestaurantCuisineRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RestaurantCuisine>> FindCuisinesAndRestaurants()
        {
            return await _context.RestaurantCuisines
                .Include(x => x.Cuisine)
                .Include(x => x.Restaurant)
                .ToListAsync();
        }
    }
}
