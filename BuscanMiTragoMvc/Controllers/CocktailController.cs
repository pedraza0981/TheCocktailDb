using BuscanMiTragoMvc.Models;
using BuscanMiTragoMvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace BuscanMiTragoMvc.Controllers
{
    public class CocktailController : Controller
    {
        private readonly ICocktailService _cocktailService;

        public CocktailController(ICocktailService cocktailService)
        {
            _cocktailService = cocktailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(string searchTerm, string searchType)
        {
            CocktailSearchResult result = null;

            if (searchType == "name")
            {
                result = await _cocktailService.SearchCocktailsByNameAsync(searchTerm);
            }
            else if (searchType == "ingredient")
            {
                result = await _cocktailService.SearchCocktailsByIngredientAsync(searchTerm);
            }

            if (result == null || result.Drinks == null || !result.Drinks.Any())
            {
                ViewBag.ErrorMessage = "No se encontraron cócteles con el término de búsqueda proporcionado.";
            }

            return View("Index", result);
        }

        public async Task<IActionResult> Detail(string id)
        {
            var result = await _cocktailService.GetCocktailDetailAsync(id);
            return View(result);
        }
    }
}