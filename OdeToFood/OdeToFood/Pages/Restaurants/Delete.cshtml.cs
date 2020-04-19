using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Entity;
using OdeToFood.Persistence;

namespace OdeToFood.Pages.Restaurants
{
    public class DeleteModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        public Restaurant restaurant { get; set; }

        public DeleteModel(IRestaurantData _restaurantData)
        {
            restaurantData = _restaurantData;
        }
        public ActionResult OnGet(int restaurantID)
        {
            restaurant = restaurantData.GetRestaurantByID(restaurantID);
            if (restaurant==null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
        public ActionResult OnPost(int restaurantID)
        {
            var restaurant = restaurantData.Delete(restaurantID);
            restaurantData.Commit();
            if (restaurant==null)
            {
                return RedirectToPage("./NotFound");
            }
            TempData["Message"] = $"{ restaurant.Name} deleted ";
            return RedirectToPage("./List");
        }
    }
}