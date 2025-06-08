using Pokemon.Infrastructure.PokeClient.Models;
using Refit;

namespace Pokemon.Infrastructure.PokeClient
{
    public interface IPokeApiRefit
    {
        [Get("/pokemon")]
        Task<PokeApiListResponse> GetPokemonListAsync([Query] int offset = 0, [Query] int limit = 20);

        [Get("/pokemon/{name}")]
        Task<PokeApiDetailResponse> GetPokemonByNameAsync(string name);
    }
}
