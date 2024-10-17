using FoodEx.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodEx.Application
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        public Task<Product> FindByName(string name);
        public Task<List<Product>> Search(string query);

        public Task<List<Product>> GetAllByRestaurant(int restaurantId);
        public Task<List<Product>> FindAllByRestaurant(string restaurantName);
    }
}
