using Pokemon.Application.MestrePokemon.Results;
using Pokemon.Domain.Contracts.Repositories;

namespace Pokemon.Application.MestrePokemon.UseCases
{
    public class GetMestrePokemonsPagedUseCase
    {
        private readonly IGenericRepository<Domain.Entities.MestrePokemon> _repository;

        public GetMestrePokemonsPagedUseCase(IGenericRepository<Domain.Entities.MestrePokemon> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<MestrePokemonResult>> ExecuteAsync(int page = 1, int pageSize = 10)
        {
            var paged = await _repository.GetPagedAsync(page, pageSize);
            return paged.Select(entity => new MestrePokemonResult
            {
                Id = entity.Id,
                Nome = entity.Nome,
                Idade = entity.Idade,
                Cpf = entity.Cpf
            }).ToList();
        }
    }
}
