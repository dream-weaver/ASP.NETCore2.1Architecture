using OdeToFood.Entity;
using System.Collections.Generic;

namespace OdeToFood.Persistence
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetRestaurantByID(int Id);
        Restaurant Update(Restaurant updatedRestaurant);
        Restaurant Add(Restaurant newRestaurant);
        Restaurant Delete(int Id);
        int CountOfRestaurants();
        int Commit();
    }
    
}
