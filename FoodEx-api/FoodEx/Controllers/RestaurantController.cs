using FoodEx.Application.IServices;
using FoodEx.Domain;
using FoodEx.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodEx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        private readonly IProductService _productService;

        public RestaurantController(
            IRestaurantService restaurantService,
            IProductService productService)
        {
            _restaurantService = restaurantService;
            _productService = productService;
        }

        [HttpGet("GetRestaurant")]
        public async Task<ActionResult<Restaurant>> GetRestaurantByName(string name)
        {
            if(name == null)
            {
                return BadRequest();
            }
            Restaurant restaurant = await _restaurantService.GetRestaurantByName(name);
            return Ok(restaurant);
        }

        [HttpGet("GetProducts")]
        public async Task<ActionResult<List<Product>>> GetRestaurantMenuByName(string name)
        {
            if (name == null)
            {
                return BadRequest();
            }
            List<Product> menu = (List<Product>) await _productService.GetProductsByRestaurant(name);

            return Ok(menu);
        }

        [HttpGet("GetProductCategories")]
        public async Task<ActionResult<List<string>>> GetRestaurantMenuCategoriesByName(string name)
        {
            if (name == null)
            {
                return BadRequest();
            }
            List<Product> menu = (List<Product>)await _productService.GetProductsByRestaurant(name);

            List<string> categories = new List<string>();
            menu.ForEach(x => {
                if (!categories.Contains(x.Category.Name))
                    categories.Add(x.Category.Name);
                });

            return Ok(categories);
        }

        [HttpGet("GetProductsByCategory")]
        public async Task<ActionResult<Dictionary<string, List<Product>>>> GetProductsByCategories(string name)
        {
            if (name == null)
            {
                return BadRequest();
            }
            List<Product> products = (List<Product>)await _productService.GetProductsByRestaurant(name);

            Dictionary<string, List<Product>> productsByCategory = new Dictionary<string, List<Product>>();

            foreach (Product product in products)
            {
                if(!productsByCategory.ContainsKey(product.Category.Name))
                {
                    productsByCategory.Add(product.Category.Name, new List<Product>() { product });
                }
                else
                {
                    productsByCategory[product.Category.Name].Add(product);
                }
            }

            return Ok(productsByCategory);
        }

        [HttpGet("GetCuisines")]
        public async Task<ActionResult<List<Cuisine>>> GetCuisines()
        {
            try
            {
                List<Cuisine> cuisines = (List<Cuisine>)await _restaurantService.GetAllCuisines();
                return Ok(cuisines);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("SearchRestaurants")]
        public async Task<ActionResult<List<Restaurant>>> SearchRestaurants(string query)
        {
            try
            {
                List<Restaurant> searchedRestaurants = (List<Restaurant>)await _restaurantService.SearchRestaurant(query);
                return Ok(searchedRestaurants);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("SearchProducts")]
        public async Task<ActionResult<List<Product>>> SearchProducts(string query)
        {
            try
            {
                List<Product> searchedProducts = (List<Product>)await _productService.SearchProduct(query);
                return Ok(searchedProducts);
            }
            catch
            {
                return BadRequest();
            }
        }



    }
}
