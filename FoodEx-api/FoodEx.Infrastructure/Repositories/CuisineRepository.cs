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
    public class CuisineRepository : GenericRepository<Cuisine>, ICuisineRepository
    {
        private readonly ApplicationContext _context;
        public CuisineRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Cuisine>> FindCuisinesByRestaurant(string restaurantName)
        {
            return await _context.RestaurantCuisines
                .Where(x => x.Restaurant.Name == restaurantName)
                .Include(x => x.Restaurant)
                .Select(x => x.Cuisine)
                .ToListAsync();
        }

        public async Task<Cuisine> FindByName(string name)
        {
            return await _context.Cuisines.Where(x => x.Name == name).FirstOrDefaultAsync();
        }
    }
}
