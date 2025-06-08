using Pokemon.Application.Pokemons.Results;
using Pokemon.Domain.Contracts.Repositories;
using Pokemon.Domain.Entities;

namespace Pokemon.Application.Pokemons.UseCases
{
    public class GetCapturedPokemonsPagedUseCase
    {
        private readonly IGenericRepository<PokemonEntity> _repository;

        public GetCapturedPokemonsPagedUseCase(IGenericRepository<PokemonEntity> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CapturedPokemonResult>> ExecuteAsync(int page = 1, int pageSize = 10)
        {
            var paged = await _repository.GetPagedAsync(page, pageSize);
            return paged.
                Select(p => new CapturedPokemonResult
                {
                    Id = p.Id,
                    Name = p.Name,
                    MestrePokemonId = p.MestrePokemonId
                })
                .ToList();
        }
    }
}
