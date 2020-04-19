using OdeToFood.Entity;
using OdeToFood.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Service.Implementation
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant{Id = 1, Name = "Scott's Pizza", Location = "Maryland", Cuisine = CuisineType.Italian},
                new Restaurant{Id = 2, Name = "Cinnamon Club ", Location = "New York", Cuisine = CuisineType.American},
                new Restaurant{Id = 3, Name = "La Costa", Location = "New Jersey", Cuisine = CuisineType.Mexican},
                new Restaurant{Id = 4, Name = "Pizza Burg", Location = "Forest Green", Cuisine = CuisineType.None}

            };
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(x => x.Id == updatedRestaurant.Id);
            if (restaurant!=null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }
            return restaurant;
        }

        public int Commit()
        {
            return 0;
        }

        Restaurant IRestaurantData.GetRestaurantByID(int Id)
        {
            return restaurants.SingleOrDefault(x => x.Id == Id);
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            return newRestaurant;
        }

        public Restaurant Delete(int Id)
        {
            var restaurant = restaurants.FirstOrDefault(x => x.Id == Id);
            if (restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public int CountOfRestaurants()
        {
            return restaurants.Count();
        }
    }
}
