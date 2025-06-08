using Pokemon.Domain.Contracts;
using Pokemon.Domain.Entities;

namespace Pokemon.Infrastructure.PokeClient
{
    public class PokemonService : IPokemonService
    {
        private readonly IPokeApiRefit _pokeApi;

        public PokemonService(IPokeApiRefit pokeApi)
        {
            _pokeApi = pokeApi;
        }

        public async Task<PokemonList> GetPokemonListAsync(int offset = 0, int limit = 20)
        {
            var apiResponse = await _pokeApi.GetPokemonListAsync(offset, limit);

            var items = apiResponse.results
                .Select(r => new PokemonListItem(r.name, r.url))
                .ToList();

            return new PokemonList(apiResponse.count, apiResponse.next, apiResponse.previous, items);
        }

        public async Task<PokemonEntity?> GetPokemonByNameAsync(string name)
        {
            try
            {
                var apiResponse = await _pokeApi.GetPokemonByNameAsync(name);

                var abilities = apiResponse.abilities
                    .Select(a => new PokemonAbility(a.ability.name, a.is_hidden, a.slot))
                    .ToList();

                var types = apiResponse.types
                    .Select(t => new PokemonType(t.type.name, t.slot))
                    .ToList();

                var stats = apiResponse.stats
                    .Select(s => new PokemonStat(s.stat.name, s.base_stat, s.effort))
                    .ToList();

                var moves = apiResponse.moves
                    .Select(m => new PokemonMove(m.move.name))
                    .ToList();

                return new PokemonEntity(
                    apiResponse.id,
                    apiResponse.name,
                    apiResponse.base_experience,
                    apiResponse.height,
                    apiResponse.weight,
                    apiResponse.is_default,
                    abilities,
                    types,
                    stats,
                    moves,
                    apiResponse.sprites.front_default
                );
            }
            catch
            {
                return null;
            }
        }
    }
}
