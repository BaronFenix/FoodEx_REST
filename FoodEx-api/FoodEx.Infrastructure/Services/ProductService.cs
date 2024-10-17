using FoodEx.Application;
using FoodEx.Application.IServices;
using FoodEx.Domain;
using FoodEx.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodEx.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private ICategoryRepository _categoryRepository;

        public ProductService(ApplicationContext context)
        {
            _productRepository = new ProductRepository(context);
            _categoryRepository = new CategoryRepository(context);
        }


        public async Task<Category> AddCategory(Category category)
        {
            return await _categoryRepository.Insert(category);
        }

        public async Task<Product> AddProduct(Product product)
        {
            return await _productRepository.Insert(product);
        }

        public async Task EditCategory(Category category)
        {
            await _categoryRepository.Update(category);
        }

        public async Task EditProduct(Product product)
        {
            await _productRepository.Update(product);
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _productRepository.FindAll();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _categoryRepository.FindById(id);
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _productRepository.FindById(id);
        }

        public async Task<Product> GetProductByName(string name)
        {
            return await _productRepository.FindByName(name);
        }

        public async Task<IEnumerable<Product>> GetProductsByRestaurant(string restaurantName)
        {
            return await _productRepository.FindAllByRestaurant(restaurantName);
        }

        public async Task<IEnumerable<Product>> SearchProduct(string query)
        {
            return await _productRepository.Search(query);
        }

        public async Task RemoveCategory(Category category)
        {
            await _categoryRepository.Delete(category);
        }

        public async Task RemoveCategoryById(int id)
        {
            await _categoryRepository.Delete(id);
        }

        public async Task RemoveProduct(Product product)
        {
            await _productRepository.Delete(product);
        }

        public async Task RemoveProductById(int id)
        {
            await _productRepository.Delete(id);
        }
    }
}
