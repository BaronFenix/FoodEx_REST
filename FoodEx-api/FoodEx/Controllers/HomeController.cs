using FoodEx.Application;
using FoodEx.Application.IServices;
using FoodEx.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodEx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        private readonly  IProductService _productService;

        public HomeController(
            IRestaurantService restaurantService,
            IProductService productService)
        {
            _restaurantService = restaurantService;
            _productService = productService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Restaurant>>> GetRestaurants()
        {
            try
            {
                List<Restaurant> restaurants = (List<Restaurant>)await _restaurantService.GetAllRestaurants();
                return Ok(restaurants);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("getRestaurantsByCategory")]
        public async Task<ActionResult<List<Restaurant>>> GetRestaurantsByCategory(string category)
        {
            try
            {
                List<Restaurant> restaurantCuisines = (List<Restaurant>) await _restaurantService.GetRestaurantsByCuisine(category);
                return restaurantCuisines;
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("getRestaurantsAndCuisine")]
        public async Task<ActionResult<Dictionary<string, List<Restaurant>>>> GetRestaurantsByCuisine()
        {
            try
            {
                List<RestaurantCuisine> restaurantCuisines = (List<RestaurantCuisine>)await _restaurantService.GetCusinesAndRestaurants();
                Dictionary<string, List<Restaurant>> restaurantsByCuisine = new();

                foreach (RestaurantCuisine item in restaurantCuisines)
                {
                    if (!restaurantsByCuisine.ContainsKey(item.Cuisine.Name))
                    {
                        restaurantsByCuisine.Add(item.Cuisine.Name, new List<Restaurant>() { item.Restaurant });
                    }
                    else
                    {
                        restaurantsByCuisine[item.Cuisine.Name].Add(item.Restaurant);
                    }
                }
                return restaurantsByCuisine;
            }
            catch
            {
                return BadRequest();
            }
        }





    }
}
