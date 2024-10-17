using FoodEx.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FoodEx.Application.IServices
{
    public interface IRestaurantService
    {
        public Task<Restaurant> AddRestaurant(Restaurant restaurant);

        public Task RemoveRestaurant(Restaurant restaurant);

        public Task RemoveRestaurantById(int id);

        public Task EditRestaurant(Restaurant restaurant);

        public Task<Restaurant> GetRestaurantByName(string name);

        public Task<Restaurant> GetRestaurantById(int id);

        public Task<IEnumerable<Restaurant>> GetAllRestaurants();

        public Task<IEnumerable<Restaurant>> GetRestaurantsByCuisine(string name);

        public Task<IEnumerable<Restaurant>> SearchRestaurant(string query);


        public Task<IEnumerable<RestaurantCuisine>> GetCusinesAndRestaurants();


        public Task<Cuisine> AddCuisine(Cuisine cuisine);

        public Task RemoveCuisine(Cuisine cuisine);

        public Task RemoveCuisineById(int id);

        public Task editCuisine(Cuisine cuisine);

        public Task<Cuisine> GetCuisineByName(string name);

        public Task<Cuisine> GetCuisineById(int id);

        public Task<IEnumerable<Cuisine>> GetAllCuisines();
    }
}
