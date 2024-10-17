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
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly ApplicationContext _context;
        public ProductRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllByRestaurant(int restaurantId)
        {
            return await _context.Products.Where(x => x.Restaurant.Id == restaurantId).ToListAsync();
        }

        public async Task<List<Product>> FindAllByRestaurant(string restaurantName)
        {
            return await _context.Products
                .Where(x => x.Restaurant.Name == restaurantName)
                .Include(x => x.Category)
                .ToListAsync();
        }

        public async Task<Product> FindByName(string name)
        {
            return await _context.Products.Where(x => x.Name == name).FirstOrDefaultAsync();
        }

        public async Task<List<Product>> Search(string query)
        {
            return await _context.Products.Where(x => x.Name.Contains(query) || x.Description.Contains(query)).ToListAsync();
        }
    }
}
