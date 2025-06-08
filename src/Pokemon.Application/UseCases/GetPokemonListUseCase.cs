using Pokemon.Application.Results;
using Pokemon.Domain.Contracts;

namespace Pokemon.Application.UseCases
{
    public class GetPokemonListUseCase
    {
        private readonly IPokemonService _pokemonService;

        public GetPokemonListUseCase(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        public async Task<PokemonListResult> ExecuteAsync(int offset = 0, int limit = 20)
        {
            var domainList = await _pokemonService.GetPokemonListAsync(offset, limit);

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
