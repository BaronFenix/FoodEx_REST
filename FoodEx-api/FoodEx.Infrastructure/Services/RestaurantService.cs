using FoodEx.Application;
using FoodEx.Application.IServices;
using FoodEx.Domain;
using FoodEx.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodEx.Infrastructure.Services
{
    public class RestaurantService : IRestaurantService
    {

        private readonly IRestaurantRepository _restaurantRepository;
        private readonly ICuisineRepository _cuisineRepository;
        private readonly IRestaurantCuisineRepository _restaurantCuisineRepository;

        public RestaurantService(
            ApplicationContext contetx,
            IRestaurantRepository restaurantRepository,
            ICuisineRepository cuisineRepository,
            IRestaurantCuisineRepository restaurantCuisineRepository)
        {
            _restaurantRepository = restaurantRepository;
            _cuisineRepository = cuisineRepository;
            _restaurantCuisineRepository = restaurantCuisineRepository;
        }

        public async Task<Cuisine> AddCuisine(Cuisine cuisine)
        {
            return await _cuisineRepository.Insert(cuisine);
        }

        public async Task<Restaurant> AddRestaurant(Restaurant restaurant)
        {
            return await _restaurantRepository.Insert(restaurant);
        }

        public async Task editCuisine(Cuisine cuisine)
        {
            await _cuisineRepository.Update(cuisine);
        }

        public async Task EditRestaurant(Restaurant restaurant)
        {
            await _restaurantRepository.Update(restaurant);
        }

        public async Task<IEnumerable<Cuisine>> GetAllCuisines()
        {
            return await _cuisineRepository.FindAll();
        }

        public async Task<IEnumerable<Restaurant>> GetAllRestaurants()
        {
            return await _restaurantRepository.FindAll();
        }

        public async Task<IEnumerable<RestaurantCuisine>> GetCusinesAndRestaurants()
        {
            return await _restaurantCuisineRepository.FindCuisinesAndRestaurants();
        }

        public async Task<Cuisine> GetCuisineById(int id)
        {
            return await _cuisineRepository.FindById(id);
        }

        public async Task<Cuisine> GetCuisineByName(string name)
        {
            return await _cuisineRepository.FindByName(name);
        }

        public async Task<Restaurant> GetRestaurantById(int id)
        {
            return await _restaurantRepository.FindById(id);
        }

        public async Task<IEnumerable<Restaurant>> SearchRestaurant(string query)
        {
            return await _restaurantRepository.SearchByName(query);
        }

        public async Task<Restaurant> GetRestaurantByName(string name)
        {
            return await _restaurantRepository.FindByName(name);
        }

        public async Task<IEnumerable<Restaurant>> GetRestaurantsByCuisine(string cuisine)
        {
            return await _restaurantRepository.FindAllByCuisine(cuisine);
        }

        public async Task RemoveCuisine(Cuisine cuisine)
        {
            await _cuisineRepository.Delete(cuisine);
        }

        public async Task RemoveCuisineById(int id)
        {
            await _cuisineRepository.Delete(id);
        }

        public async Task RemoveRestaurant(Restaurant restaurant)
        {
            await _restaurantRepository.Delete(restaurant);
        }

        public async Task RemoveRestaurantById(int id)
        {
            await _restaurantRepository.Delete(id);
        }
    }
}
