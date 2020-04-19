using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Entity;
using OdeToFood.Persistence;

namespace OdeToFood.Pages
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        private readonly IHtmlHelper htmlHelper;

        public EditModel(IRestaurantData _restaurantData, IHtmlHelper _htmlHelper)
        {
            this.restaurantData = _restaurantData;
            this.htmlHelper = _htmlHelper;
        }
        [BindProperty]
        public Restaurant restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }
        public int restaurantId { get; set; }

        public IActionResult OnGet(int? restaurantId)
        {
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
            if(restaurantId.HasValue){
                restaurant = restaurantData.GetRestaurantByID(restaurantId.Value);
            }else{
               restaurant = new Restaurant();
            }          
            if (restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {         
            if(!ModelState.IsValid){
                Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
                return Page();
            }
            if (restaurant.Id > 0){ 
                restaurantData.Update(restaurant);
            }else{ 
                restaurantData.Add(restaurant);
            }
           
            restaurantData.Commit();
            TempData["Message"] = "Restaurant Saved";
            return RedirectToPage("./Details", new { restaurantId = restaurant.Id });
        }
    }
}