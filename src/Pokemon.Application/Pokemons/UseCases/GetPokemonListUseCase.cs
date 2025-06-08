using Pokemon.Application.Pokemons.Results;
using Pokemon.Domain.Contracts.Services;

namespace Pokemon.Application.Pokemons.UseCases
{
    public class GetPokemonListUseCase
    {
        private readonly IPokemonService _pokemonService;

        public GetPokemonListUseCase(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        public async Task<PokemonListResult> ExecuteAsync()
        {
            var aleatoryOffset = new Random().Next(0, 10000);
            var domainList = await _pokemonService.GetPokemonListAsync(offset: aleatoryOffset, limit: 10);

            return new PokemonListResult
            {
                Count = domainList.Count,
                Next = domainList.Next,
                Previous = domainList.Previous,
                Results = domainList.Results
                    .Select(item => new PokemonListItemResult
                    {
                        Name = item.Name,
                        Url = item.Url
                    })
                    .ToList()
            };
        }
    }
}
