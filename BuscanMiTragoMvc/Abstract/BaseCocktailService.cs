using BuscanMiTragoMvc.Models;

namespace BuscanMiTragoMvc.Abstract
{
    public abstract class BaseCocktailService
    {
        public abstract Task<CocktailSearchResult> SearchCocktailsByNameAsync(string name);
        public abstract Task<CocktailSearchResult> SearchCocktailsByIngredientAsync(string ingredient);
        public abstract Task<CocktailDetail> GetCocktailDetailAsync(string id);
    }
}
