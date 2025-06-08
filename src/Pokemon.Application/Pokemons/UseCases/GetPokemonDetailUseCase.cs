using Pokemon.Application.Pokemons.Results;
using Pokemon.Domain.Contracts.Services;

namespace Pokemon.Application.Pokemons.UseCases
{
    public class GetPokemonDetailUseCase
    {
        private readonly IPokemonService _pokemonService;

        public GetPokemonDetailUseCase(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        public async Task<PokemonDetailResult?> ExecuteAsync(string name)
        {
            var domainPokemon = await _pokemonService.GetPokemonByNameAsync(name);
            if (domainPokemon == null)
                return null;

            return new PokemonDetailResult
            {
                Id = domainPokemon.Id,
                Name = domainPokemon.Name,
                BaseExperience = domainPokemon.BaseExperience,
                Height = domainPokemon.Height,
                Weight = domainPokemon.Weight,
                IsDefault = domainPokemon.IsDefault,
                SpriteFrontDefault = domainPokemon.SpriteFrontDefault,
                Abilities = domainPokemon.Abilities
                    .Select(a => new PokemonAbilityResult
                    {
                        Name = a.Name,
                        IsHidden = a.IsHidden,
                        Slot = a.Slot
                    })
                    .ToList(),
                Types = domainPokemon.Types
                    .Select(t => new PokemonTypeResult
                    {
                        Name = t.Name,
                        Slot = t.Slot
                    })
                    .ToList(),
                Stats = domainPokemon.Stats
                    .Select(s => new PokemonStatResult
                    {
                        Name = s.Name,
                        BaseStat = s.BaseStat,
                        Effort = s.Effort
                    })
                    .ToList(),
                Moves = domainPokemon.Moves
                    .Select(m => new PokemonMoveResult
                    {
                        Name = m.Name
                    })
                    .ToList()
            };
        }
    }
}
