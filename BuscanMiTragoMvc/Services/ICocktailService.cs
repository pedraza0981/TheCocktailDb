using System.Threading.Tasks;
using BuscanMiTragoMvc.Models;

namespace BuscanMiTragoMvc.Services
{
    public interface ICocktailService
    {
        Task<CocktailSearchResult> SearchCocktailsByNameAsync(string name);
        Task<CocktailSearchResult> SearchCocktailsByIngredientAsync(string ingredient);
        Task<CocktailDetail> GetCocktailDetailAsync(string id);
    }
}
