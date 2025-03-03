using BuscanMiTragoMvc.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using BuscanMiTragoMvc.Abstract;



namespace BuscanMiTragoMvc.Services
{
    public class CocktailService : BaseCocktailService, ICocktailService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public CocktailService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _baseUrl = configuration["CocktailApi:BaseUrl"];
        }

        public override async Task<CocktailSearchResult> SearchCocktailsByNameAsync(string name)
        {
            var response = await _httpClient.GetStringAsync($"{_baseUrl}search.php?s={name}");
            return JsonConvert.DeserializeObject<CocktailSearchResult>(response);
        }

        public override async Task<CocktailSearchResult> SearchCocktailsByIngredientAsync(string ingredient)
        {
            var response = await _httpClient.GetStringAsync($"{_baseUrl}filter.php?i={ingredient}");
            return JsonConvert.DeserializeObject<CocktailSearchResult>(response);
        }

        public override async Task<CocktailDetail> GetCocktailDetailAsync(string id)
        {
            var response = await _httpClient.GetStringAsync($"{_baseUrl}lookup.php?i={id}");
            var result = JsonConvert.DeserializeObject<CocktailSearchResult>(response).Drinks.FirstOrDefault();

            if (result != null)
            {
                return new CocktailDetail
                {
                    IdDrink = result.IdDrink,
                    StrDrink = result.StrDrink,
                    StrDrinkAlternate = result.StrDrinkAlternate,
                    StrTags = result.StrTags,
                    StrVideo = result.StrVideo,
                    StrCategory = result.StrCategory,
                    StrIBA = result.StrIBA,
                    StrAlcoholic = result.StrAlcoholic,
                    StrGlass = result.StrGlass,
                    StrInstructions = result.StrInstructions,
                    StrInstructionsES = result.StrInstructionsES,
                    StrInstructionsDE = result.StrInstructionsDE,
                    StrInstructionsFR = result.StrInstructionsFR,
                    StrInstructionsIT = result.StrInstructionsIT,
                    StrInstructionsZH_HANS = result.StrInstructionsZH_HANS,
                    StrInstructionsZH_HANT = result.StrInstructionsZH_HANT,
                    StrDrinkThumb = result.StrDrinkThumb,
                    StrIngredient1 = result.StrIngredient1,
                    StrIngredient2 = result.StrIngredient2,
                    StrIngredient3 = result.StrIngredient3,
                    StrIngredient4 = result.StrIngredient4,
                    StrIngredient5 = result.StrIngredient5,
                    StrIngredient6 = result.StrIngredient6,
                    StrIngredient7 = result.StrIngredient7,
                    StrIngredient8 = result.StrIngredient8,
                    StrIngredient9 = result.StrIngredient9,
                    StrIngredient10 = result.StrIngredient10,
                    StrIngredient11 = result.StrIngredient11,
                    StrIngredient12 = result.StrIngredient12,
                    StrIngredient13 = result.StrIngredient13,
                    StrIngredient14 = result.StrIngredient14,
                    StrIngredient15 = result.StrIngredient15,
                    StrMeasure1 = result.StrMeasure1,
                    StrMeasure2 = result.StrMeasure2,
                    StrMeasure3 = result.StrMeasure3,
                    StrMeasure4 = result.StrMeasure4,
                    StrMeasure5 = result.StrMeasure5,
                    StrMeasure6 = result.StrMeasure6,
                    StrMeasure7 = result.StrMeasure7,
                    StrMeasure8 = result.StrMeasure8,
                    StrMeasure9 = result.StrMeasure9,
                    StrMeasure10 = result.StrMeasure10,
                    StrMeasure11 = result.StrMeasure11,
                    StrMeasure12 = result.StrMeasure12,
                    StrMeasure13 = result.StrMeasure13,
                    StrMeasure14 = result.StrMeasure14,
                    StrMeasure15 = result.StrMeasure15,
                    StrImageSource = result.StrImageSource,
                    StrImageAttribution = result.StrImageAttribution,
                    StrCreativeCommonsConfirmed = result.StrCreativeCommonsConfirmed,
                    DateModified = result.DateModified
                };
            }

            return null;
        }
    }
}
