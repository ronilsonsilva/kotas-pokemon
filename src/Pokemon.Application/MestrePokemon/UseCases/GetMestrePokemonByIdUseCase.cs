using Pokemon.Application.MestrePokemon.Results;
using Pokemon.Domain.Contracts.Repositories;

namespace Pokemon.Application.MestrePokemon.UseCases
{
    public class GetMestrePokemonByIdUseCase
    {
        private readonly IGenericRepository<Domain.Entities.MestrePokemon> _repository;

        public GetMestrePokemonByIdUseCase(IGenericRepository<Domain.Entities.MestrePokemon> repository)
        {
            _repository = repository;
        }

        public async Task<MestrePokemonResult?> ExecuteAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return null;

            return new MestrePokemonResult
            {
                Id = entity.Id,
                Nome = entity.Nome,
                Idade = entity.Idade,
                Cpf = entity.Cpf
            };
        }
    }
}
