using FoodEx.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FoodEx.Application.IServices
{
    public interface IProductService
    {
        public Task<Product> AddProduct(Product product);

        public Task EditProduct(Product product);

        public Task RemoveProduct(Product product);

        public Task RemoveProductById(int id);

        public Task<Product> GetProductByName(string name);

        public Task<IEnumerable<Product>> SearchProduct(string query);

        public Task<Product> GetProductById(int id);

        public Task<IEnumerable<Product>> GetAllProducts();

        public Task<IEnumerable<Product>> GetProductsByRestaurant(string restaurantName);

        public Task<Category> AddCategory(Category category);

        public Task EditCategory(Category category);

        public Task RemoveCategory(Category category);

        public Task RemoveCategoryById(int id);

        public Task<Category> GetCategoryById(int id);

    }
}
