using Microsoft.AspNetCore.Mvc;
using OdeToFood.Persistence;

namespace OdeToFood.ViewComponents
{
    public class RestaurantCountViewComponent : ViewComponent
    {
        private readonly IRestaurantData restaurantData;
        
        public RestaurantCountViewComponent(IRestaurantData _restaurantData)
        {
            restaurantData = _restaurantData;
        }

        public IViewComponentResult Invoke()
        {
            var count = restaurantData.CountOfRestaurants();
            return View(count);
        }
    }
}
