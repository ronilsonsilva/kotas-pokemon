using Pokemon.Application.Pokemons.Requests;
using Pokemon.Application.Pokemons.Results;
using Pokemon.Domain.Contracts.Repositories;
using Pokemon.Domain.Contracts.Services;
using Pokemon.Domain.Entities;

namespace Pokemon.Application.Pokemons.UseCases
{
    public class CapturePokemonUseCase
    {
        private readonly IPokemonService _pokemonService;
        private readonly IGenericRepository<PokemonEntity> _pokemonRepository;

        public CapturePokemonUseCase(
            IPokemonService pokemonService,
            IGenericRepository<PokemonEntity> pokemonRepository)
        {
            _pokemonService = pokemonService;
            _pokemonRepository = pokemonRepository;
        }

        public async Task<CapturePokemonResult?> ExecuteAsync(CapturePokemonRequest request)
        {
            var pokemon = await _pokemonService.GetPokemonByNameAsync(request.Name);
            if (pokemon == null)
                return null;

            var entity = new PokemonEntity(pokemon.Id,
                pokemon.Name, 
                pokemon.BaseExperience, 
                pokemon.Height, 
                pokemon.Weight, 
                pokemon.IsDefault, 
                pokemon.Abilities, 
                pokemon.Types, 
                pokemon.Stats, 
                pokemon.Moves, 
                pokemon.SpriteFrontDefault,
                request.MestrePokemonId);

            await _pokemonRepository.AddAsync(entity);

            return new CapturePokemonResult
            {
                Id = entity.Id,
                Name = entity.Name,
                MestrePokemonId = entity.MestrePokemonId
            };
        }
    }
}
