using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Entity;
using OdeToFood.Persistence;

namespace OdeToFood.Pages.Restaurants
{
    public class DetailsModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        public DetailsModel(IRestaurantData _restaurantData)
        {
            this.restaurantData = _restaurantData;
        }

        public Restaurant restaurant { get; set; }
        public int restaurantId { get; set; }
        [TempData]
        public string Message { get; set; }

        public IActionResult OnGet(int restaurantId)
        {
            restaurant = restaurantData.GetRestaurantByID(restaurantId);
            if(restaurant==null){
               return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}