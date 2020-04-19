using Microsoft.EntityFrameworkCore;
using OdeToFood.Entity;
using OdeToFood.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFood.Service.Implementation
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext db;

        public SqlRestaurantData(OdeToFoodDbContext _db)
        {
            db = _db;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            db.restaurants.Add(newRestaurant);
            return newRestaurant;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public int CountOfRestaurants()
        {
            return db.restaurants.Count();
        }

        public Restaurant Delete(int Id)
        {
            var restaurant = GetRestaurantByID(Id);
            if (restaurant!=null)
            {
                db.restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public Restaurant GetRestaurantByID(int Id)
        {
            return db.restaurants.Find(Id);   
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            var query = from r in db.restaurants
                        where r.Name.StartsWith(name) || String.IsNullOrEmpty(name)
                        orderby r.Name
                        select r;
            return query;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var entity = db.restaurants.Attach(updatedRestaurant);
            entity.State = EntityState.Modified;
            return updatedRestaurant;
        }
    }
}
